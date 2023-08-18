using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAdoption
{
    public class DAGetAdoption : BaseDataAccess<ADOPTION, IEnumerable<ADOPTION>>
    {
        public const string GetMaxId = "GetMaxById";
        public const string GetInStatus = "GetInStatus";
        public const string GetCustomerId = "GetByCustomerId";

        string getMethod = string.Empty;
        protected override IEnumerable<ADOPTION> Execute(PETADOPTIONEntities entity, ADOPTION input, object[] additionalParameters)
        {
            switch (getMethod)
            {
                case GetMaxId:
                    return GetMaxById(entity, input);
                case GetInStatus:
                    return GetByStatus(entity, input);
                case GetCustomerId:
                    return GetByCustomerId(entity, input);
                default:
                    return GetByNormalFilter(entity, input);
            }
        }

        private IEnumerable<ADOPTION> GetByNormalFilter(PETADOPTIONEntities entity, ADOPTION input)
        {
            var data = entity.ADOPTIONs
                                 .Where(x => x.ADOPTIONID == (input.ADOPTIONID == 0 ? x.ADOPTIONID : input.ADOPTIONID) &&
                                             x.ADOPTIONNO == (string.IsNullOrEmpty(input.ADOPTIONNO) ? x.ADOPTIONNO : input.ADOPTIONNO))
                                 .AsEnumerable()
                                 .Select(adoption => { adoption.USERNAME = adoption.CUSTOMER.USERNAME; return adoption; })
                                 .ToList();
            return data;
        }

        private IEnumerable<ADOPTION> GetByCustomerId(PETADOPTIONEntities entity, ADOPTION input)
        {
            var data = entity.ADOPTIONs
                                 .Where(x => x.CUSTOMERID == input.CUSTOMERID && x.STATUS == input.STATUS)
                                 .AsEnumerable()
                                 .Select(adoption => { adoption.CUSTOMERID = adoption.CUSTOMER.CUSTOMERID; return adoption; })
                                 .ToList();
            return data;
        }
        private IEnumerable<ADOPTION> GetByStatus(PETADOPTIONEntities entity, ADOPTION input)
        {
            var data = entity.ADOPTIONs
                                 .Where(x => x.STATUS == input.STATUS &&
                                             x.CUSTOMERID == (input.CUSTOMERID == 0 ? x.CUSTOMERID : input.CUSTOMERID))
                                 .AsEnumerable()
                                 .Select(adoption => { adoption.CUSTOMER.USERNAME = input.USERNAME; return adoption; })
                                 .ToList();
            return data;
        }

        private IEnumerable<ADOPTION> GetMaxById(PETADOPTIONEntities entity, ADOPTION input)
        {
            var data = entity.ADOPTIONs
                             .OrderByDescending(x => x.ADOPTIONID)
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        protected override void Initialize(ADOPTION input, object[] additionalParameters)
        {
            if (additionalParameters.Length > 0)
            {
                if (additionalParameters[0] is string)
                {
                    getMethod = (string)additionalParameters[0];
                }
            }
        }
    }
}