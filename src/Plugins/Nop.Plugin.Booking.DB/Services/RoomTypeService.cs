using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Services
{
    class RoomTypeService : IRoomTypeService
    {
        private readonly IRepository<RoomType> _roomTypeRepository;

        public RoomTypeService(IRepository<RoomType> roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public virtual void Log(RoomType record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _roomTypeRepository.InsertAsync(record);
        }
    }
}
