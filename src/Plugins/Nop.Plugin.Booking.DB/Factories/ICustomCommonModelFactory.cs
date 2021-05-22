using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Booking.DB.Models;

namespace Nop.Plugin.Booking.DB.Factories
{
    public partial interface ICustomCommonModelFactory
    {
        Task<SelectedCurrencyLanguageModel> PrepareSelectedCurrencyLanguageModelAsync();
    }
}
