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
    public class BLGetCust : BaseBusinessLogic<CUSTOMER, IEnumerable<CUSTOMER>>
    {
        protected override IEnumerable<CUSTOMER> Execute(CUSTOMER input, DataAccessExecutor dataAccessExecutor, object[] additionalParameters) { 
            return dataAccessExecutor.Execute<DAGetCust, CUSTOMER, IEnumerable<CUSTOMER>>(input, additionalParameters);

        } 
        protected override void Initialize(CUSTOMER input, params object[] additionalParameters)
        {
            
        }
    }
}