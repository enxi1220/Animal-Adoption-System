using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessPet
{
    public class DAEditPet : BaseDataAccess<PET, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, PET input, object[] additionalParameters)
        {
            var data = entity.PETs.First(x => x.PETID == input.PETID);
            data.NAME = string.IsNullOrEmpty(input.NAME)? data.NAME: input.NAME;
            data.DESC = string.IsNullOrEmpty(input.DESC) ? data.DESC : input.DESC;
            data.AGE = string.IsNullOrEmpty(input.AGE) ? data.AGE : input.AGE;
            data.SIZE = string.IsNullOrEmpty(input.SIZE) ? data.SIZE : input.SIZE;
            data.BREED = string.IsNullOrEmpty(input.BREED) ? data.BREED : input.BREED;
            data.TYPE = string.IsNullOrEmpty(input.TYPE) ? data.TYPE : input.TYPE;
            data.GENDER = string.IsNullOrEmpty(input.GENDER) ? data.GENDER : input.GENDER;
            data.AUDITPERIOD = string.IsNullOrEmpty(input.AUDITPERIOD.ToString()) ? data.AUDITPERIOD : input.AUDITPERIOD;
            data.IMAGE = string.IsNullOrEmpty(input.IMAGE) ? data.IMAGE : input.IMAGE;
            data.STATUS = string.IsNullOrEmpty(input.STATUS) ? data.STATUS : input.STATUS;
            data.UPDATEDDATE = input.UPDATEDDATE;
            data.UPDATEDBY = input.UPDATEDBY;

            return entity.SaveChanges();
        }
    }
}