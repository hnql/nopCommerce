using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Services
{
    class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRecordRepository)
        {
            _roomRepository = roomRecordRepository;
        }

        public virtual void Log(Room record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _roomRepository.InsertAsync(record);
        }
    }
}
