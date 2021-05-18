using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Services
{
    public partial interface IRoomTypeService
    {
        void Log(RoomType record);
    }
}
