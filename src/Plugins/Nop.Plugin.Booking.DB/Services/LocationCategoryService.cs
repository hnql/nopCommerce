using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Services
{
    class LocationCategoryService : ILocationCategoryService
    {
        private readonly IRepository<LocationCategory> _locationCategoryRepository;

        public LocationCategoryService(IRepository<LocationCategory> locationCategoryRepository)
        {
            _locationCategoryRepository = locationCategoryRepository;
        }

        public virtual void Log(LocationCategory record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _locationCategoryRepository.InsertAsync(record);
        }
    }
}
