using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessCustomer
{
    public class DAAddCust : BaseDataAccess<CUSTOMER, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, CUSTOMER input, object[] additionalParameters)
        {
            entity.CUSTOMERs.Add(input);
            return entity.SaveChanges();

        }
    }

}