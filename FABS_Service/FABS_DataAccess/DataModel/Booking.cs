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

        public Booking(int id, DateTime startDatetime, DateTime endDatetime, int peopleId, int statusId) :this()
        {
            Id = id;
            StartDatetime = startDatetime;
            EndDatetime = endDatetime;
            PeopleId = peopleId;
            StatusesId = statusId;
        }

        public Booking(DateTime startDatetime, DateTime endDatetime, int peopleId, int statusesId) : this()
        {
            StartDatetime = startDatetime;
            EndDatetime = endDatetime;
            PeopleId = peopleId;
            StatusesId = statusesId;
        }
    }
}
