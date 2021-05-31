using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Booking.DB.Models;

namespace Nop.Plugin.Booking.DB.Factories
{
    class CustomCommonModelFactory : ICustomCommonModelFactory
    {
        private readonly IWorkContext _workContext;

        public CustomCommonModelFactory(IWorkContext workContent)
        {
            _workContext = workContent;
        }

        #region Methods
        public virtual async Task<SelectedCurrencyLanguageModel> PrepareSelectedCurrencyLanguageModelAsync()
        {
            var model = new SelectedCurrencyLanguageModel
            {
                SelectedCurrency = (await _workContext.GetWorkingCurrencyAsync()).Name,
                SelectedLanguageCulture = (await _workContext.GetWorkingLanguageAsync()).LanguageCulture
            };

            return model;
        }

        #endregion
    }
}
