using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Services
{
    class RoomService : IRoomService
    {
        private readonly IRepository<Room> _roomRepository;

        public RoomService(IRepository<Room> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public virtual void Log(Room record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _roomRepository.InsertAsync(record);
        }
    }
}
