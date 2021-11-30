using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class BookingLineDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int ItemId { get; set; }

        public BookingLineDto()
        {

        }

        public BookingLineDto(int id, int bookingId, int itemId)
        {
            Id = id;
            BookingId = bookingId;
            ItemId = itemId;
        }

        public BookingLineDto(int bookingId, int itemId)
        {
            BookingId = bookingId;
            ItemId = itemId;
        }
    }
}
