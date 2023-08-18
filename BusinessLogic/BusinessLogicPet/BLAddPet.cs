using AnimalAdoptionSystem.DataAccess.DataAccessPet;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicPet
{
    public class BLAddPet : BaseBusinessLogic<PET, object>
    {
        protected override object Execute(PET input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            PET lastPet = dataAccessExecutor.Execute<DAGetPet, PET, IEnumerable<PET>>(input, additionalParameters).FirstOrDefault();
            string petNo = UniqueNoGenerator.generator(lastPet.PETNO, "PET");
            input.PETNO = petNo;
            dataAccessExecutor.Execute<DAAddPet, PET>(input);
            return null;
        }

        protected override void Initialize(PET input, object[] additionalParameters)
        {
            input.STATUS = Constant.getPetStatus(Constant.PetStatusEnum.New);
            input.CREATEDDATE = DateTime.Now;
        }
    }
}