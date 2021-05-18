using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Services
{
    class RoomTypeService : IRoomTypeService
    {
        private readonly IRepository<RoomType> _roomTypeRepository;

        public RoomTypeService(IRepository<RoomType> roomTypeRecordRepository)
        {
            _roomTypeRepository = roomTypeRecordRepository;
        }

        public virtual void Log(RoomType record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _roomTypeRepository.InsertAsync(record);
        }
    }
}
