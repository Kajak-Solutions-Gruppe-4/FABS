using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FABS_API_Service.DTO
{
    public class ItemWithBookingInfoDto
    {
        public ItemDto item { get; set; }
        public List<DateTime[]> DatetimeRanges { get; set; }

        public ItemWithBookingInfoDto(ItemDto item)
        {
            this.item = item;
            DatetimeRanges = new List<DateTime[]>();
        }
    }
}
