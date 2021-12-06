using FABS_DataAccess.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FABS_DataAccess.BusinessLogic
{
    public static class BookingLogic
    {
        /// <summary>
        /// Checks for past dates and if start and end date is correct 
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns>True if dates are correctly valdiated</returns>
       
        public static bool DateRangeValidator(DateTime date1, DateTime date2)
        {
            bool value = false;

            if (date1 < date2 && date1 >= DateTime.Now)
            {
                value = true;
            }
            return value;
        }
    }
}

