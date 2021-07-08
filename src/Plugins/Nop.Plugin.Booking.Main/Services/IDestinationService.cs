﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Nop.Plugin.Booking.Main.Models;

namespace Nop.Plugin.Booking.Main.Services
{
    public partial interface IDestinationService
    {
        Task<IList<DestinationModel>> GetDestinationAsync();
    }
}
