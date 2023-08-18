using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAudit
{
    public class DAAddAudit : BaseDataAccess<AUDIT, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, AUDIT input, object[] additionalParameters)
        {
            entity.AUDITs.Add(input);
            //query sample
            //entity.Database.ExecuteSqlCommand("INSERT INTO ?????");
            //entity.Database.SqlQuery<AUDIT>("SELECT * FROM AUDIT");
            return entity.SaveChanges();
        }
    }
}