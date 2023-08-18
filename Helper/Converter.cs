using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalAdoptionSystem.Helper
{
    public class Converter
    {
        public static string DateTimeConverter(DateTime? dt)
        {
            //sql to input
            //"22/09/2022T10:28:00" to "2022-09-22T15:51"
            DateTime dateTime = dt.GetValueOrDefault();
            return dateTime.Year.ToString() + '-' + dateTime.Month.ToString("D2") + '-' + dateTime.Day + 'T' + dateTime.Hour + ':' + dateTime.Minute;
        }

        public static DateTime DateTimeConverter(string sDateTime)
        {
            return DateTime.Parse(sDateTime.Replace('T', ' '));
        }
    }
}