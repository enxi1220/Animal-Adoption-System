using AnimalAdoptionSystem.Framework.Bases;
using AnimalAdoptionSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.DataAccess.DataAccessCustomer
{
    public class DAEditCust : BaseDataAccess<CUSTOMER, object>
    {
        public const string EditAcc = "editAcc";
        public const string EditPwd = "editPwd";
        public const string EditOTP = "editOTP";

        string getMethod = string.Empty;
        protected override object Execute(PETADOPTIONEntities entity, CUSTOMER input, object[] additionalParameters)
        {
            switch (getMethod)
            {
                case EditAcc:
                    return EditAccMethod(entity, input);
                case EditPwd:
                    return EditPwdMethod(entity, input);
                case EditOTP:
                    return EditOTPMethod(entity, input);
                default:
                    return null;
            }
        }

        protected object EditAccMethod(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs.First(x => x.USERNAME == input.USERNAME);
            data.NAME = input.NAME;
            data.PHONE = input.PHONE;
            data.MAIL = input.MAIL;
            data.IMAGE = input.IMAGE;
            data.UPDATEDDATE = input.UPDATEDDATE;
            data.UPDATEDBY = input.UPDATEDBY;
            return entity.SaveChanges();
        } 
        
        protected object EditPwdMethod(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs.First(x => x.USERNAME == input.USERNAME);

            data.PASSWORD = input.PASSWORD;
            data.UPDATEDDATE = input.UPDATEDDATE;
            data.UPDATEDBY = input.UPDATEDBY;
            return entity.SaveChanges();
        }
        
        protected object EditOTPMethod(PETADOPTIONEntities entity, CUSTOMER input)
        {
            var data = entity.CUSTOMERs.First(x => x.MAIL == input.MAIL);

            data.OTP = input.OTP;
         
            return entity.SaveChanges();
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