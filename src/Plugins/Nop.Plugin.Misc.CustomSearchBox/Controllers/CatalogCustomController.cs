using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.Directory;
using Nop.Core.Domain.Media;
using Nop.Core.Domain.Vendors;
using Nop.Data;
using Nop.Services.Catalog;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Security;
using Nop.Services.Stores;
using Nop.Services.Vendors;
using Nop.Web.Controllers;
using Nop.Web.Factories;
using Nop.Web.Framework;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Models.Catalog;
using Nop.Plugin.Misc.CustomSearchBox.Models;
using Nop.Plugin.Misc.CustomSearchBox.Services;
using System.Text.RegularExpressions;
using System.Text;
using LinqToDB.Data;

namespace Nop.Plugin.Misc.CustomSearchBox.Controllers
{

    public class CatalogCustomController : BasePublicController
    {
        private readonly CatalogSettings _catalogSettings;
        private readonly IProductCustomService _productCustomService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly IProductModelFactory _productModelFactory;
        private readonly MediaSettings _mediaSettings;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<StateProvince> _stateProvinceRepository;
        private readonly IRepository<Vendor> _vendorRepository;
        public CatalogCustomController(
            CatalogSettings catalogSettings,
            IProductCustomService productCustomService,
            IStoreContext storeContext,
            IWorkContext workContext,
            IProductModelFactory productModelFactory,
            MediaSettings mediaSettings,
            IRepository<Product> productRepository,
            IRepository<Address> addressRepository,
            IRepository<StateProvince> stateProvinceRepository,
            IRepository<Vendor> vendorRepository)
        {
            _catalogSettings = catalogSettings;
            _productCustomService = productCustomService;
            _storeContext = storeContext;
            _workContext = workContext;
            _productModelFactory = productModelFactory;
            _mediaSettings = mediaSettings;
            _productRepository = productRepository;
            _addressRepository = addressRepository;
            _stateProvinceRepository = stateProvinceRepository;
            _vendorRepository = vendorRepository;
        }
        [CheckLanguageSeoCode(true)]
        public virtual async Task<IActionResult> SearchTermAutoComplete(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return Content("");

            term = term.Trim();

            if (string.IsNullOrWhiteSpace(term) || term.Length < _catalogSettings.ProductSearchTermMinimumLength)
                return Content("");

            //products
            var productNumber = _catalogSettings.ProductSearchAutoCompleteNumberOfProducts > 0 ?
                _catalogSettings.ProductSearchAutoCompleteNumberOfProducts : 10;

            var products = await _productCustomService.SearchProductsAsync(0,
                storeId: (await _storeContext.GetCurrentStoreAsync()).Id,
                keywords: term,
                languageId: (await _workContext.GetWorkingLanguageAsync()).Id,
                visibleIndividuallyOnly: true,
                pageSize: productNumber);

            var provinces = await SearchStateProvincesAsync(term);
            //future: add url to stateProvince page
            if (products.Count < provinces.Count())
            {
                var res = (from p in provinces
                           select new
                           {
                               type = "province",
                               label = p.Name,
                               avaiablelocation = p.AvaiableLocation,
                               showlinktoresultsearch = "a"
                           }).ToList();
                return Json(res);
            }
            var showLinkToResultSearch = _catalogSettings.ShowLinkToAllResultInSearchAutoComplete && (products.Count > productNumber);
            //var models = (await _productModelFactory.PrepareProductOverviewModelsAsync(products, false, _catalogSettings.ShowProductImagesInSearchAutoComplete, _mediaSettings.AutoCompleteSearchThumbPictureSize)).ToList();
            var models = (await _productModelFactory.PrepareProductOverviewModelsAsync(products, false, true, 100)).ToList();
            var productsWithLocation = (await AddLocationToProductOverview(models)).ToList();
            var result = (from p in productsWithLocation
                          select new
                          {
                              type = "product",
                              label = p.Name,
                              producturl = Url.RouteUrl("Product", new { SeName = p.SeName }),
                              productpictureurl = p.DefaultPictureModel.ImageUrl,
                              showlinktoresultsearch = showLinkToResultSearch,
                              location = String.IsNullOrWhiteSpace(p.LocationName) ? "" : p.LocationName

                          })
                .ToList();
            return Json(result);

        }
        private async Task<IEnumerable<ProvinceSearchModel>> SearchStateProvincesAsync(string keywords)
        {
            if (string.IsNullOrEmpty(keywords))
            {
                return null;
            }
            List<ProvinceSearchModel> provinces = await (from v in _vendorRepository.Table
                                                         from p in _productRepository.Table.Where(p => p.VendorId == v.Id).DefaultIfEmpty()
                                                         from a in _addressRepository.Table.Where(a => a.Id == v.AddressId).DefaultIfEmpty()
                                                         from sp in _stateProvinceRepository.Table.Where(sp => sp.Id == a.StateProvinceId).DefaultIfEmpty()
                                                         where !v.Deleted && v.Active
                                                         group new { sp, p } by new { sp.Name } into g
                                                         select new ProvinceSearchModel { Name = g.Key.Name, AvaiableLocation = g.Count(g => !string.IsNullOrEmpty(g.p.Id.ToString()) && g.p.Deleted == false) }
                                                         ).ToListAsync();
            var data = await (from a in provinces
                       where (MiscService.ConvertToUnSign(a.Name).IndexOf(keywords, StringComparison.CurrentCultureIgnoreCase) >= 0)
                       select a).Distinct().ToListAsync();
            return data;
        }
        private async Task<IEnumerable<ProductOverviewModel>> AddLocationToProductOverview(List<ProductOverviewModel> products)
        {
            var locations = await (from v in _vendorRepository.Table
                                   from a in _addressRepository.Table.Where(a => a.Id == v.AddressId).DefaultIfEmpty()
                                   from sp in _stateProvinceRepository.Table.Where(sp => sp.Id == a.StateProvinceId).DefaultIfEmpty()
                                   where !v.Deleted && v.Active
                                   group new { sp, v } by new { Id = v.Id, Name = sp.Name } into g
                                   select new { Id = g.Key.Id, Name = g.Key.Name }
                                   ).Distinct().ToListAsync();
            for (int i = 0; i < products.Count; i++)
            {
                foreach (var location in locations)
                {
                    if (location.Id == products[i].VendorId)
                    {
                        products[i].LocationName = location.Name;
                    }
                }
            }
            return products;
        }

        public virtual async Task<IActionResult> SearchByDate(string q, string arrivalDate, string departureDate)
        {
            DataParameter[] dates = new DataParameter[] {
                new DataParameter(name: "ArrivalDate", value: arrivalDate),
                new DataParameter(name: "DepartureDate", value: departureDate)
            };

            IList<Product> products = await _productRepository.EntityFromSqlAsync("ROOMAVAILABLE", dates);

            IList<object> result = new List<object>();
            foreach(var product in products)
            {
                result.Add(new{
                    product.Id,
                    product.Name,
                    product.AvailableStartDateTimeUtc,
                    product.AvailableEndDateTimeUtc
                });
            }

            return Json(result);
        }

    }
}
