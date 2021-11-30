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
        public List<BookingLineDto> BookingsLine { get; set; }

        public BookingDto()
        {

        }
        public BookingDto(int id, DateTime startDateTime, DateTime endDateTime, int personId, List<BookingLineDto> bookingsLine)
        {
            Id = id;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PersonId = personId;
            BookingsLine = bookingsLine;
        }

        public BookingDto(DateTime startDateTime, DateTime endDateTime, int personId, List<BookingLineDto> bookingsLine)
        {
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            PersonId = personId;
            BookingsLine = bookingsLine;
        }
    }

}
