using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAudit
{
    public class DADeleteAudit : BaseDataAccess<AUDIT, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, AUDIT input, object[] additionalParameters)
        {
            var data = entity.AUDITs.First(x => x.AUDITID == input.AUDITID);
            entity.AUDITs.Remove(data);
            return entity.SaveChanges();
        }
    }
}