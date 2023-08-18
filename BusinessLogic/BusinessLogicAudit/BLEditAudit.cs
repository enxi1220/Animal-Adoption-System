using AnimalAdoptionSystem.DataAccess.DataAccessAudit;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicAudit
{
    public class BLEditAudit : BaseBusinessLogic<AUDIT, object>
    {
        protected override object Execute(AUDIT input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            dataAccessExecutor.Execute<DAEditAudit, AUDIT>(input);
            return null;
        }

        protected override void Initialize(AUDIT input, object[] additionalParameters)
        {
            if (input.COMPLETIONTIME.HasValue)
            {
                input.STATUS = Constant.getAuditStatus(Constant.AuditStatusEnum.Completed);
            }
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}