using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Helper
{
    public class UniqueNoGenerator
    {
        public static string generator(string currNo, string prefix)
        {
            string[] elements = currNo.Split('/');
            int suffix = int.Parse(elements[2]);
            DateTime localDate = DateTime.Now;
            string year = localDate.ToString("yy");
            int month = localDate.Month;
            if (!elements[1].Equals(year + month.ToString("D2")))
            {
                suffix = 1;
            }
            else
            {
                ++suffix;
            }

            string nextNo = prefix + "/" + year + month.ToString("D2") + "/" + suffix.ToString("D5");
            return nextNo;
        }

        public static string imgUniqueName(string filename) {

            string imgUniqueName = DateTime.Now.ToString().Replace("/", "").Replace(":", "") + filename ;
            return imgUniqueName.Trim();
        }
    }
}