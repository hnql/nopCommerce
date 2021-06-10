using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Services
{
    public partial interface ILocationCategoryService
    {
        void Log(LocationCategory record);

        Task<IList<LocationCategory>> GetLocationCategoriesAsync();
    }
}
