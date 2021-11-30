using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class BookingDto
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int PersonId { get; set; }
        public List<BookingLineDto> BookingsLines { get; set; }

        public int StatusId { get; set; }

        public BookingDto()
        {

        }

        public BookingDto(DateTime startDateTime, DateTime endDateTime, int personId, List<BookingLineDto> bookingsLine, int statusId)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PersonId = personId;
            BookingsLines = bookingsLine;
            StatusId = statusId;
        }

        public BookingDto(DateTime startDateTime, DateTime endDateTime, int personId, int statusId)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PersonId = personId;
            StatusId = statusId;
        }

        public BookingDto(int id, DateTime startDateTime, DateTime endDateTime, int personId, List<BookingLineDto> bookingsLines, int statusId)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PersonId = personId;
            BookingsLines = bookingsLines;
            StatusId = statusId;
        }
    }

}
