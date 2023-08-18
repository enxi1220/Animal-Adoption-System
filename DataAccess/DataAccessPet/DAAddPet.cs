using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessPet
{
    public class DAAddPet : BaseDataAccess<PET, object>
    {
        protected override object Execute(PETADOPTIONEntities entity, PET input, object[] additionalParameters)
        {
            entity.PETs.Add(input);
            
            return entity.SaveChanges();
        }
    }
}