using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Helper
{
    public class Constant
    {
        public enum StatusEnum
        {
            Activate,
            Deactivate,
        }

        public enum UserRoleEnum
        {
            Staff,
            Admin
        }

        public enum PetStatusEnum
        {
            New,
            Adopted,
            Euthanasia,
            PendingAdoption,
            Deactivate
        }

        public enum PetAgeEnum
        {
            Adult,
            Kid
        }

        public enum PetSizeEnum
        {
            Small,
            Big
        }

        public enum AdoptStatusEnum
        {
            New,
            Approved,
            Rejected,
            Canceled
        }

        public enum AuditConditionEnum
        {
            Good,
            Sick,
            Abused,
            Dead
        }

        public enum AuditStatusEnum
        {
            New,
            Completed
        }

        public static string getStatus(StatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case StatusEnum.Activate:
                    return "Activate";
                case StatusEnum.Deactivate:
                    return "Deactivate";
                default:
                    return "";
            }
        }

        public static string getUserRole(UserRoleEnum statusEnum)
        {
            switch (statusEnum)
            {
                case UserRoleEnum.Admin:
                    return "Admin";
                case UserRoleEnum.Staff:
                    return "Staff";
                default:
                    return "";
            }
        }

        public static string getPetStatus(PetStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case PetStatusEnum.Adopted:
                    return "Adopted";
                case PetStatusEnum.New:
                    return "New";
                case PetStatusEnum.Deactivate:
                    return "Deactivate";
                case PetStatusEnum.Euthanasia:
                    return "Euthanasia";
                case PetStatusEnum.PendingAdoption:
                    return "Pending Adoption";
                default:
                    return "";
            }
        }

        public static string getPetAge(PetAgeEnum petAgeEnum)
        {
            switch (petAgeEnum)
            {
                case PetAgeEnum.Adult:
                    return "Adult";
                case PetAgeEnum.Kid:
                    return "Kid";
                default:
                    return "";
            }
        }
        public static string getPetSize(PetSizeEnum petSizeEnum)
        {
            switch (petSizeEnum)
            {
                case PetSizeEnum.Small:
                    return "Small";
                case PetSizeEnum.Big:
                    return "Big";
                default:
                    return "";
            }
        }

        public static string getAdoptStatus(AdoptStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case AdoptStatusEnum.New:
                    return "New";
                case AdoptStatusEnum.Approved:
                    return "Approved";
                case AdoptStatusEnum.Rejected:
                    return "Rejected";
                case AdoptStatusEnum.Canceled:
                    return "Canceled";
                default:
                    return "";
            }
        }

        public static string getAuditCondition(AuditConditionEnum statusEnum)
        {
            switch (statusEnum)
            {
                case AuditConditionEnum.Good:
                    return "Good";
                case AuditConditionEnum.Abused:
                    return "Abused";
                case AuditConditionEnum.Sick:
                    return "Sick";
                case AuditConditionEnum.Dead:
                    return "Dead";
                default:
                    return "";
            }
        }

        public static string getAuditStatus(AuditStatusEnum statusEnum)
        {
            switch (statusEnum)
            {
                case AuditStatusEnum.New:
                    return "New";
                case AuditStatusEnum.Completed:
                    return "Completed";
                default:
                    return "";
            }
        }
    }
}