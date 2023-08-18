using AnimalAdoptionSystem.DataAccess.DataAccessAdoption;
using AnimalAdoptionSystem.DataAccess.DataAccessAudit;
using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;
using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Framework.Models;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicAdoption
{
    public class BLAddAdoption : BaseBusinessLogic<ADOPTION, object>
    {
        protected override object Execute(ADOPTION input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            //get pet latest status, avoid adopted again
            PET pet = dataAccessExecutor.Execute<DAGetPet, PET, IEnumerable<PET>>(new PET() { PETID = input.PETID }).FirstOrDefault();
            if (pet.STATUS.Equals(Constant.getPetStatus(Constant.PetStatusEnum.Adopted)))
            {
                throw new Exception(pet.NAME + " has been adopted.");
            }

            if (pet.STATUS.Equals(Constant.getPetStatus(Constant.PetStatusEnum.PendingAdoption)))
            {
                throw new Exception(pet.NAME + " has been reserved by other user.");
            }

            if (pet.STATUS.Equals(Constant.getPetStatus(Constant.PetStatusEnum.Deactivate)))
            {
                throw new Exception(pet.NAME + " currently is not available.");
            }

            if (pet.STATUS != Constant.getPetStatus(Constant.PetStatusEnum.Adopted))
            {
                ADOPTION lastAdopt = dataAccessExecutor.Execute<DAGetAdoption, ADOPTION, IEnumerable<ADOPTION>>(input, additionalParameters).FirstOrDefault();
                CUSTOMER cust = dataAccessExecutor.Execute<DAGetCust, CUSTOMER, IEnumerable<CUSTOMER>>(new CUSTOMER() { 
                                                                                                            USERNAME = input.USERNAME 
                                                                                                        }).FirstOrDefault();
                input.ADOPTIONNO = UniqueNoGenerator.generator(lastAdopt.ADOPTIONNO, "ADO");
                input.CUSTOMERID = cust.CUSTOMERID;
               
                //assign pet info from pet
                input.PETNO = pet.PETNO;
                input.NAME = pet.NAME;
                input.AGE = pet.AGE;
                input.SIZE = pet.SIZE;
                input.GENDER = pet.GENDER;
                input.BREED = pet.BREED;
                input.TYPE = pet.TYPE;
                input.IMAGE = pet.IMAGE;
                input.DESC = pet.DESC;
                
                //add adopt
                dataAccessExecutor.Execute<DAAddAdoption, ADOPTION>(input);

                //update pet status
                dataAccessExecutor.Execute<DAEditPet, PET>(new PET()
                {
                    PETID = input.PETID,
                    STATUS = Constant.getPetStatus(Constant.PetStatusEnum.PendingAdoption)
                }, additionalParameters);
            }
            return null;
        }

        protected override void Initialize(ADOPTION input, object[] additionalParameters)
        {
            input.STATUS = Constant.getAdoptStatus(Constant.AdoptStatusEnum.New);
            input.CREATEDDATE = DateTime.Now;
        }
    }
}