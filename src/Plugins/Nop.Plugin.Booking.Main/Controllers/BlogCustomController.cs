using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Nop.Core;
using Nop.Core.Domain.Blogs;
using Nop.Core.Domain.Localization;
using Nop.Core.Domain.Security;
using Nop.Core.Events;
using Nop.Services.Blogs;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Services.Seo;
using Nop.Services.Stores;
using Nop.Web.Factories;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc;
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Models.Blogs;

namespace Nop.Plugin.Booking.Main.Controllers
{
    [AutoValidateAntiforgeryToken]
    class BlogCustomController : BasePluginController
    {
        #region Fields

        private readonly BlogSettings _blogSettings;
        private readonly CaptchaSettings _captchaSettings;
        private readonly IBlogModelFactory _blogModelFactory;
        private readonly IBlogService _blogService;
        private readonly ICustomerActivityService _customerActivityService;
        private readonly ICustomerService _customerService;
        private readonly IEventPublisher _eventPublisher;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly IStoreContext _storeContext;
        private readonly IStoreMappingService _storeMappingService;
        private readonly IUrlRecordService _urlRecordService;
        private readonly IWebHelper _webHelper;
        private readonly IWorkContext _workContext;
        private readonly IWorkflowMessageService _workflowMessageService;
        private readonly LocalizationSettings _localizationSettings;

        #endregion

        #region Ctor

        public BlogCustomController(BlogSettings blogSettings,
            CaptchaSettings captchaSettings,
            IBlogModelFactory blogModelFactory,
            IBlogService blogService,
            ICustomerActivityService customerActivityService,
            ICustomerService customerService,
            IEventPublisher eventPublisher,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            IStoreContext storeContext,
            IStoreMappingService storeMappingService,
            IUrlRecordService urlRecordService,
            IWebHelper webHelper,
            IWorkContext workContext,
            IWorkflowMessageService workflowMessageService,
            LocalizationSettings localizationSettings)
        {
            _blogSettings = blogSettings;
            _captchaSettings = captchaSettings;
            _blogModelFactory = blogModelFactory;
            _blogService = blogService;
            _customerActivityService = customerActivityService;
            _customerService = customerService;
            _eventPublisher = eventPublisher;
            _localizationService = localizationService;
            _permissionService = permissionService;
            _storeContext = storeContext;
            _storeMappingService = storeMappingService;
            _urlRecordService = urlRecordService;
            _webHelper = webHelper;
            _workContext = workContext;
            _workflowMessageService = workflowMessageService;
            _localizationSettings = localizationSettings;
        }

        #endregion

        #region Methods
        public virtual async Task<IActionResult> ListHomeAsync(BlogPagingFilteringModel command)
        {
            var language = await _workContext.GetWorkingLanguageAsync();
            var store = await _storeContext.GetCurrentStoreAsync();
            var blogPosts = await _blogService.GetAllBlogPostsByTagAsync(store.Id, language.Id, tag : "discovery");

            var result = (from b in blogPosts
                          select new
                          {
                              label = b.Title,
                              metatitle=b.MetaTitle,
                              tags=b.Tags,
                          })
                .ToList();
            return Json(result);
        }
        #endregion
    }
}
