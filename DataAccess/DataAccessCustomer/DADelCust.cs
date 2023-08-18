using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using AnimalAdoptionSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessCustomer
{
    public class DADelCust : BaseDataAccess<CUSTOMER, object>
    {
        string getMethod = string.Empty;
        protected override object Execute(PETADOPTIONEntities entity, CUSTOMER input, object[] additionalParameters)
        {
            var data = entity.CUSTOMERs.First(x => x.USERNAME == input.USERNAME);
            data.STATUS = Constant.getStatus(Constant.StatusEnum.Deactivate);
            data.UPDATEDDATE = input.UPDATEDDATE;
            data.UPDATEDBY = input.UPDATEDBY;
            return entity.SaveChanges();
        }
    }

}