using FABS_DataAccess.Model;
using FABS_DataAccess.Repository;
using FABS_API_Service.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FABS_API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IRepository<Booking> _bookingRepository;

        public BookingsController()
        {
            _bookingRepository = new BookingRepository();
        }



        // GET: api/<BookingsController>
        [HttpGet]
        public ActionResult<IEnumerable<Booking>> Get(int organisationId)
        {
            if (organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            IEnumerable<Booking> listBooking = _bookingRepository.GetAll(organisationId);
            List<BookingDto> bookings = new List<BookingDto>();
            foreach (Booking booking in listBooking)
            {
                bookings.Add(ConvertModelToDto(booking));
            }

            int c = bookings.Count();
            if (c < 0)
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public string Get(int id, int organisationId)
        {
            return "value";
        }

        // POST api/<BookingsController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] BookingDto bDto, int organisationId)
        {
            Booking b = ConvertDtoToModel(bDto);
            int numberOfAffectedRows = _bookingRepository.Create(b);
            if (numberOfAffectedRows > 0)
            {
                return Ok(numberOfAffectedRows);
            }
            else
            {
                return new StatusCodeResult(500);
            }
        }

        

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private BookingDto ConvertModelToDto(Booking booking)
        {
            //TODO: convertModelToBookingLineDto
            List<BookingLineDto> bookingLines = new List<BookingLineDto>();
            foreach (BookingLine bookingLine in booking.BookingLines)
            {
                bookingLines.Add(new BookingLineDto(
                    bookingLine.BookingsId,
                    bookingLine.ItemsId
                    ));
            }
            return new BookingDto(
                booking.Id,
                booking.StartDatetime,
                booking.EndDatetime,
                booking.PeopleId,
                bookingLines,
                booking.StatusesId
                );
        }
        
        private Booking ConvertDtoToModel(BookingDto bDto)
        {
            Booking booking = new Booking(
                bDto.StartDateTime,
                bDto.EndDateTime,
                bDto.PersonId,
                bDto.StatusId
                );
            foreach (BookingLineDto bookingLineDto in bDto.BookingsLines)
            {
                booking.BookingLines.Add(new BookingLine(bookingLineDto.BookingId, bookingLineDto.ItemId));
            }
            return booking;
        }
    }
}
