using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Services
{
    public partial class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepository;

        public LocationService(IRepository<Location> locationRecordRepository)
        {
            _locationRepository = locationRecordRepository;
        }

        public virtual void Log(Location record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _locationRepository.InsertAsync(record);
        }
    }
}
