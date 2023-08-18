using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAudit
{
    public class DAEditAudit : BaseDataAccess<AUDIT, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, AUDIT input, object[] additionalParameters)
        {
            var data = entity.AUDITs.First(x => x.AUDITID == input.AUDITID);
            data.BOOKINGTIME = input.BOOKINGTIME;
            data.STARTTIME = input.STARTTIME;
            data.COMPLETIONTIME = input.COMPLETIONTIME;
            data.DESC = input.DESC;
            data.CONDITION = input.CONDITION;
            data.STATUS = String.IsNullOrEmpty(input.STATUS) ? data.STATUS: input.STATUS;
            data.UPDATEDBY = input.UPDATEDBY;
            data.UPDATEDDATE = input.UPDATEDDATE;
            return entity.SaveChanges();
        }
    }
}