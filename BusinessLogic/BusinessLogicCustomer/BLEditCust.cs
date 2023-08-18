using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Framework.Models;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer
{
    public class BLEditCust : BaseBusinessLogic<CUSTOMER, object>
    {
        protected override object Execute(CUSTOMER input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters) {
            dataAccessExecutor.Execute<DAEditCust, CUSTOMER>(input, additionalParameters);
            return null;
        }

        protected override void Initialize(CUSTOMER input, object[] additionalParameters)
        {
            input.UPDATEDBY = input.USERNAME;
            input.UPDATEDDATE = DateTime.Now;
        }

    }
}