using FABS_DataAccess.Model;
using FABS_DataAccess.Repository;
using FABS_API_Service.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FABS_API_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        // TODO: use the interface!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        private readonly BookingRepository _bookingRepository;

        public BookingsController()
        {
            _bookingRepository = new BookingRepository("Hildur");
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

        [HttpGet, Route("OnlyFuture")]
        public ActionResult<IEnumerable<ItemWithBookingInfoDto>> GetOnlyFuture(int organisationId)
        {
            List<Booking> bookings = _bookingRepository.FindAllFutureBookings(organisationId);
            List<ItemWithBookingInfoDto> items = ConvertBookingsToItemWithBookingInfoDto(bookings);
            return items;
        }

        [HttpGet, Route("OnlyFutureNotInDateRange")]
        public ActionResult<IEnumerable<ItemWithBookingInfoDto>> GetOnlyFutureNotInDateRange(int organisationId, DateTime startDatetime, DateTime endDatetime)
        {
            List<Booking> bookings = _bookingRepository.FindNotOverlappingFutureBookingsInDaterange(startDatetime, endDatetime, organisationId);
            List<ItemWithBookingInfoDto> items = ConvertBookingsToItemWithBookingInfoDto(bookings);
            return items;
        }

        [HttpGet, Route("OnlyFutureInDateRange")]
        public ActionResult<IEnumerable<ItemWithBookingInfoDto>> GetOnlyFutureInDateRange(int organisationId, DateTime startDatetime, DateTime endDatetime)
        {
            List<Booking> bookings = _bookingRepository.FindOverlappingFutureBookingsInDaterange(startDatetime, endDatetime, organisationId);
            List<ItemWithBookingInfoDto> items = ConvertBookingsToItemWithBookingInfoDto(bookings);
            return items;
        }

        private List<ItemWithBookingInfoDto> ConvertBookingsToItemWithBookingInfoDto(List<Booking> bookings)
        {
            List<ItemWithBookingInfoDto> items = new List<ItemWithBookingInfoDto>();
            foreach (Booking booking in bookings)
            {
                foreach (BookingLine bookingLine in booking.BookingLines)
                {
                    DateTime[] datetimeRange = new DateTime[] { booking.StartDatetime, booking.EndDatetime };
                    if (items.Any(i => i.item.Id == bookingLine.Items.Id))
                    {
                        items.Where(i => i.item.Id == bookingLine.Items.Id)
                             .Single().DatetimeRanges
                             .Add(datetimeRange);
                    }
                    else
                    {
                        Item item = booking.BookingLines.First().Items;

                        ItemTypeDto itemTypeDto = new ItemTypeDto(item.ItemTypes.Id, item.ItemTypes.Name);
                        itemTypeDto.Id = item.ItemTypes.Id;
                        KayakTypeDto kayakTypeDto = new KayakTypeDto(
                            itemTypeDto,
                            item.ItemTypes.KayakType.Description,
                            item.ItemTypes.KayakType.WeightLimit,
                            item.ItemTypes.KayakType.LengthMeter,
                            item.ItemTypes.KayakType.PersonCapacity);
                        itemTypeDto.KayakTypeDto = kayakTypeDto;

                        ItemDto itemDto = new ItemDto(item.OrganisationsId, itemTypeDto);
                        itemDto.Id = item.Id;

                        ItemWithBookingInfoDto itemWithBookingInfoDto = new ItemWithBookingInfoDto(itemDto);
                        itemWithBookingInfoDto.DatetimeRanges.Add(datetimeRange);
                        items.Add(itemWithBookingInfoDto);
                    }

                }
            }
            return items;
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id, int organisationId)
        {
            if (organisationId <= 0)
            {
                return new StatusCodeResult(422);
            }
            Booking booking = _bookingRepository.Get(id, organisationId);
            BookingDto bookingDto = ConvertModelToDto(booking);
         
            return Ok(bookingDto);
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
                return new StatusCodeResult(403);
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
            foreach (BookingLineDto bookingLineDto in bDto.BookingLines)
            {
                booking.BookingLines.Add(new BookingLine(bookingLineDto.BookingId, bookingLineDto.ItemId));
            }
            // statuses not implemented correctly for now, so temporary fix
            booking.StatusesId = 4;
            return booking;
        }
    }
}
