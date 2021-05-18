using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Data;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Services
{
    class LocationCategoryService : ILocationCategoryService
    {
        private readonly IRepository<LocationCategory> _locationCategoryRepository;

        public LocationCategoryService(IRepository<LocationCategory> locationCategoryRecordRepository)
        {
            _locationCategoryRepository = locationCategoryRecordRepository;
        }

        public virtual void Log(LocationCategory record)
        {
            if (record == null)
                throw new ArgumentNullException(nameof(record));
            _locationCategoryRepository.InsertAsync(record);
        }
    }
}
