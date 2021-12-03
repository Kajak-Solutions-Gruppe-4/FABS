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
        //booking can only be made from current date and forward
        //booking start/end dats can only occure same day
        //check if startdate is before enddate time secduleing
        private static bool DateRangeValidator(DateTime date1, DateTime date2)
        {
            bool value = false;

            if (date1 < date2 && date1 > DateTime.Now)
            {
                value = true;
            }
            return value;
        }
    }
}

