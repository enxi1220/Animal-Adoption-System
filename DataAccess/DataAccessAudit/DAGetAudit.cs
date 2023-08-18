using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessAudit
{
    public class DAGetAudit : BaseDataAccess<AUDIT, IEnumerable<AUDIT>>
    {
        public const string GetLargerThanId = "GetLargerThanId";
        public const string GetInStatus = "GetInStatus";
        public const string GetMaxId = "GetMaxById";

        string getMethod = string.Empty;
        protected override IEnumerable<AUDIT> Execute(PETADOPTIONEntities entity, AUDIT input, object[] additionalParameters)
        {
            switch (getMethod)
            {
                case GetLargerThanId:
                    return GetByLargerThanId(entity, input);
                case GetInStatus:
                    return GetByStatuses(entity, input);
                case GetMaxId:
                    return GetMaxById(entity, input);
                default:
                    return GetByNormalFilter(entity, input);
            }
        }

        private IEnumerable<AUDIT> GetByStatuses(PETADOPTIONEntities entity, AUDIT input)
        {
            var data = entity.AUDITs
                             .Where(x => input.Statuses.Any(y => y == x.STATUS))
                             .AsEnumerable()
                             .Select(audit => { audit.PETNO = audit.PET.PETNO; return audit; })
                             .ToList();
            return data;
        }

        private IEnumerable<AUDIT> GetByLargerThanId(PETADOPTIONEntities entity, AUDIT input)
        {
            var data = entity.AUDITs
                             .Where(x => x.AUDITID > input.AUDITID)
                             .AsEnumerable()
                             .Select(audit => { audit.PETNO = audit.PET.PETNO; return audit; })
                             .ToList();
            return data;
        }

        private IEnumerable<AUDIT> GetMaxById(PETADOPTIONEntities entity, AUDIT input)
        {
            var data = entity.AUDITs
                             .OrderByDescending(x => x.AUDITID)
                             //.FirstOrDefault()
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        private IEnumerable<AUDIT> GetByNormalFilter(PETADOPTIONEntities entity, AUDIT input)
        {
            var data = entity.AUDITs
                                 .Where(x => x.AUDITID == (input.AUDITID == 0 ? x.AUDITID : input.AUDITID) &&
                                             x.AUDITNO == (string.IsNullOrEmpty(input.AUDITNO) ? x.AUDITNO : input.AUDITNO))
                                 .AsEnumerable()
                                 .Select(audit => { audit.PETNO = audit.PET.PETNO; audit.PETNAME = audit.PET.NAME; return audit; })
                                 .ToList();
            return data;
        }

        protected override void Initialize(AUDIT input, object[] additionalParameters)
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