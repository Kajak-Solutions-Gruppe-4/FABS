using System;
using System.Collections.Generic;
using System.Text;

namespace FABS_DataAccess.Model
{
    public partial class Booking
    {
        public Booking(DateTime startDatetime, DateTime endDatetime, Person people, Status statuses) : this()
        {
            StartDatetime = startDatetime;
            EndDatetime = endDatetime;
            People = people;
            Statuses = statuses;
        }
    }
}
