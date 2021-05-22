using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Common;

namespace Nop.Plugin.Booking.DB.Models
{
    public partial record SelectedCurrencyLanguageModel : BaseNopModel
    {
        public string SelectedCurrency { set; get; }

        public string SelectedLanguageCulture { set; get; }
    }
}
