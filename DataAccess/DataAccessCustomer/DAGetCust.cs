using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessCustomer
{
    public class DAGetCust : BaseDataAccess<CUSTOMER, IEnumerable<CUSTOMER>>
    {
        public const string GetByUsername = "getByUsername";
        public const string GetByEmail = "getByEmail";
        public const string GetByEmailExist = "getByEmailExist";
        public const string GetAllCustomer = "getAll";

        string getMethod = string.Empty;
        protected override IEnumerable<CUSTOMER> Execute(PETADOPTIONEntities entity, CUSTOMER input, object[] additionalParameters)
        {
            switch (getMethod)
            {
                case GetByUsername:
                    return GetByUsernameMethod(entity, input);
                case GetByEmail:
                    return GetByEmailMethod(entity, input);
                case GetByEmailExist:
                    return GetByEmailExistMethod(entity, input);
                case GetAllCustomer:
                    return GetAll(entity, input);
                default:
                    return GetByUsernameMethod(entity, input);

            }
        }

        private IEnumerable<CUSTOMER> GetAll(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs
                             .Where(x => x.USERNAME == (string.IsNullOrEmpty(input.USERNAME) ? x.USERNAME : input.USERNAME))
                             .AsEnumerable()
                             .ToList();
            return data;
        }

        protected IEnumerable<CUSTOMER> GetByUsernameMethod(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs
                                .Where(x => x.USERNAME == (input.USERNAME == "" ? x.USERNAME : input.USERNAME) &&
                                            x.USERNAME == (string.IsNullOrEmpty(input.USERNAME) ? x.USERNAME : input.USERNAME))
                                .AsEnumerable()
                                .Select(customer => { customer.USERNAME = customer.USERNAME; return customer; })
                                .ToList();
            return data;
        }

        //for edit account avoid changing email to other users' email
        private IEnumerable<CUSTOMER> GetByEmailMethod(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs
                                .Where(x => x.MAIL == (input.MAIL == "" ? x.MAIL : input.MAIL) &&
                                            x.USERNAME != (string.IsNullOrEmpty(input.USERNAME) ? x.USERNAME : input.USERNAME))
                                .AsEnumerable()
                                .Select(customer => { customer.USERNAME = customer.USERNAME; return customer; })
                                .ToList();
            return data;
        }

        private IEnumerable<CUSTOMER> GetByEmailExistMethod(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs
                                .Where(x => x.MAIL == (input.MAIL == "" ? x.MAIL : input.MAIL))
                                .AsEnumerable()
                                .Select(customer => { customer.USERNAME = customer.USERNAME; return customer; })
                                .ToList();
            return data;
        }

        protected override void Initialize(CUSTOMER input, object[] additionalParameters)
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