using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Plugin.Tutorial.DistOfCustByCountry.Models;
using Nop.Services.Common;
using Nop.Services.Customers;
using Nop.Services.Directory;

namespace Nop.Plugin.Tutorial.DistOfCustByCountry.Services
{
    public class CustomersByCountry : ICustomersByCountry
    {
        private readonly IAddressService _addressService;
        private readonly ICountryService _countryService;
        private readonly ICustomerService _customerService;

        public CustomersByCountry(IAddressService addressService,
            ICountryService countryService,
            ICustomerService customerService)
        {
            _addressService = addressService;
            _countryService = countryService;
            _customerService = customerService;
        }

        public async Task<List<CustomersDistribution>> GetCustomersDistributionByCountryAsync()
        {
            //List<CustomersDistribution> list = new List<CustomersDistribution>();
            //CustomersDistribution a = new CustomersDistribution();
            //a.Country = "1";
            //a.NoOfCustomers = 1;
            //list.Add(a);
            //return  list;
            return await _customerService.GetAllCustomersAsync().ToAsyncEnumerable()
            .Select(cbc => new CustomersDistribution { Country = "Name", NoOfCustomers = cbc.Count() }).ToListAsync();
            ;
        }
    }
}
