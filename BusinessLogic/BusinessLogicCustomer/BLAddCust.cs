using AnimalAdoptionSystem.DataAccess.DataAccessCustomer;
using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Framework.Executors;
using AnimalAdoptionSystem.Framework.Models;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.BusinessLogic.BusinessLogicCustomer
{
    public class BLAddCust : BaseBusinessLogic<CUSTOMER, object>
    {
        protected override object Execute(CUSTOMER input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters) {
            dataAccessExecutor.Execute<DAAddCust, CUSTOMER>(input, additionalParameters);
            return null;
        }

        protected override void Initialize(CUSTOMER input, object[] additionalParameters)
        {
            input.STATUS = Constant.getStatus(Constant.StatusEnum.Activate);

            input.CREATEDBY = input.USERNAME;
            input.CREATEDDATE = DateTime.Now;
            input.UPDATEDBY = input.USERNAME;
            input.UPDATEDDATE = DateTime.Now;
        }
    }
}