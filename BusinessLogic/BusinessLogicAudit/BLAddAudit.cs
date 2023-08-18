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
    public class BLAddAudit : BaseBusinessLogic<AUDIT, object>
    {
        protected override object Execute(AUDIT input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            AUDIT lastAudit = dataAccessExecutor.Execute<DAGetAudit, AUDIT, IEnumerable<AUDIT>>(input, additionalParameters).FirstOrDefault();
            string auditNo = UniqueNoGenerator.generator(lastAudit.AUDITNO, "AUD");
            input.AUDITNO = auditNo;
            dataAccessExecutor.Execute<DAAddAudit, AUDIT>(input);
            return null;
        }

        protected override void Initialize(AUDIT input, object[] additionalParameters)
        {
            input.STATUS = Constant.getAuditStatus(Constant.AuditStatusEnum.New);
            input.CREATEDDATE = DateTime.Now;
        }
    }
}