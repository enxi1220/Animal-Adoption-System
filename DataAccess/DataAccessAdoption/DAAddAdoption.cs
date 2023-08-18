using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAdoption
{
    public class DAAddAdoption : BaseDataAccess<ADOPTION, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, ADOPTION input, object[] additionalParameters)
        {
            entity.ADOPTIONs.Add(input);
            return entity.SaveChanges();
        }
    }
}