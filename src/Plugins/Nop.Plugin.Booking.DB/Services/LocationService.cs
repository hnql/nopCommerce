using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Services
{
    public partial class LocationService : ILocationService
    {
        private readonly IRepository<Location> _locationRepository;

        public LocationService(IRepository<Location> locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public virtual void Log(Location record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _locationRepository.InsertAsync(record);
        }

        public virtual async Task<IList<Location>> GetLocationsAsync()
        {
            var query = from location in _locationRepository.Table
                        select location;
            var locations = await query.ToListAsync();

            return locations;
        }
    }
}
