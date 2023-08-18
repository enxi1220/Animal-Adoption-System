using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Helper;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessPet
{
    public class DAGetPet : BaseDataAccess<PET, IEnumerable<PET>>
    {
        public const string GetPetWithNoOwner = "GetPetWithNoOwner";
        public const string GetPetWithOwner = "GetPetWithOwner";
        public const string GetMaxId = "GetMaxById";
        public const string GetStatuses = "GetByStatus";
        public const string GetByAge = "GetByAge";
        public const string GetBySize = "GetBySize";

        string getMethod = string.Empty;
        protected override IEnumerable<PET> Execute(PETADOPTIONEntities entity, PET input, object[] additionalParameters)
        {
            switch (getMethod)
            {
                case GetPetWithNoOwner:
                    return GetPetWithNoOwnerAction(entity, input);
                case GetPetWithOwner:
                    return GetPetWithOwnerAction(entity, input);
                case GetMaxId:
                    return GetMaxById(entity, input);
                case GetStatuses:
                    return GetByStatus(entity, input);
                case GetByAge:
                    return GetByAgeMethod(entity, input);
                case GetBySize:
                    return GetBySizeMethod(entity, input);
                default:
                    return NormalAction(entity, input);
            }
        }

        private IEnumerable<PET> NormalAction(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                    .Where(x => x.PETID == (input.PETID == 0 ? x.PETID : input.PETID))
                    .ToList();
            return data;
        }

        private IEnumerable<PET> GetPetWithNoOwnerAction(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                  .Where(x => x.PETID == (input.PETID == 0 ? x.PETID : input.PETID) &&
                              string.IsNullOrEmpty(x.OWNER))
                  .ToList();
            return data;
        }
        private IEnumerable<PET> GetPetWithOwnerAction(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                  .Where(x => x.PETID == (input.PETID == 0 ? x.PETID : input.PETID) &&
                              !string.IsNullOrEmpty(x.OWNER))
                  .ToList();
            return data;
        }

        private IEnumerable<PET> GetMaxById(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                             .OrderByDescending(x => x.PETID)
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        private IEnumerable<PET> GetByStatus(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                             .Where(x => x.STATUS == input.STATUS)
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        private IEnumerable<PET> GetByAgeMethod(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                             .Where(x => x.AGE == input.AGE && x.STATUS == input.STATUS)
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        private IEnumerable<PET> GetBySizeMethod(PETADOPTIONEntities entity, PET input)
        {
            var data = entity.PETs
                             .Where(x => x.SIZE == input.SIZE && x.STATUS == input.STATUS)
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        protected override void Initialize(PET input, object[] additionalParameters)
        {
            if(additionalParameters.Length > 0)
            {
                if (additionalParameters[0] is string)
                {
                    getMethod = (string)additionalParameters[0];
                }
                else
                {
                    throw new Exception("Invalid additonal parameter");
                }
            }
        }
    }
}