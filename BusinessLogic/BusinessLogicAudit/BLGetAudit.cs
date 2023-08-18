using AnimalAdoptionSystem.DataAccess.DataAccessAudit;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Framework.Models;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicAudit
{
    public class BLGetAudit : BaseBusinessLogic<AUDIT, IEnumerable<AUDIT>>
    {
        protected override IEnumerable<AUDIT> Execute(AUDIT input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters)
        {
            return dataAccessExecutor.Execute<DAGetAudit, AUDIT, IEnumerable<AUDIT>>(input, additionalParameters);
        }
    }
}