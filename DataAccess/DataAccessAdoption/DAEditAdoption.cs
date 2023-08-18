using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAdoption
{
    public class DAEditAdoption : BaseDataAccess<ADOPTION, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, ADOPTION input, object[] additionalParameters)
        {
            var data = entity.ADOPTIONs.First(x => x.ADOPTIONID == input.ADOPTIONID);
            data.STATUS = input.STATUS;
            data.REASONOFREJECTION = input.REASONOFREJECTION;
            data.UPDATEDBY = input.UPDATEDBY;
            data.UPDATEDDATE = input.UPDATEDDATE;
            return entity.SaveChanges();
        }
    }
}