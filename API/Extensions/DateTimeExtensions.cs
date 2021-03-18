﻿namespace API.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class DateTimeExtensions
    {
        /// <summary>Calculates the age.</summary>
        /// <param name="dob">The dob.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int CalculateAge(this DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;
            if (dob.Date > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }
}
