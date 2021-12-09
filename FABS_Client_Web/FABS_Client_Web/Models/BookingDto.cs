using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace FABS_Client_Web.Models
{
    public class BookingDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        public int PersonId { get; set; }

        //Should we remove this? Was for spike testing
        public BookingLineDto BookingLine { get; set; }

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
