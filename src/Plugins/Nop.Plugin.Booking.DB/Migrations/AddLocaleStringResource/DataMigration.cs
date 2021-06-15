using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Localization;
using Nop.Data;
using Nop.Data.Migrations;

namespace Nop.Plugin.Booking.DB.Migrations.AddLocaleStringResource
{
    [SkipMigrationOnUpdate] // If you want to re-install plugin, please remove [SkipMigrationOnUpdate]
    [NopMigration("2021/06/01 21:31:01:1234567", "Add data for locale string resource table")]
    public class DataMigration : Migration
    {
        private readonly INopDataProvider _dataProvider;

        public DataMigration(INopDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            #region Insert data to LocaleStringResource table

            var localeStringResourceTable = _dataProvider.GetTable<LocaleStringResource>();
            int englishId = 1;
            int vietnameseId = 2;
            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "search.enterdates", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "search.enterdates",
                        ResourceValue = "Dates",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "search.enterdates", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "search.enterdates",
                        ResourceValue = "Ngày",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "search.enterguests", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "search.enterguests",
                        ResourceValue = "Guests",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "search.enterguests", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "search.enterguests",
                        ResourceValue = "Khách",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture1", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture1",
                        ResourceValue = "Picture 1",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture1", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture1",
                        ResourceValue = "Hình ảnh 1",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture2", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture2",
                        ResourceValue = "Picture 2",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture2", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture2",
                        ResourceValue = "Hình ảnh 2",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture3", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture3",
                        ResourceValue = "Picture 3",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture3", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture3",
                        ResourceValue = "Hình ảnh 3",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture4", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture4",
                        ResourceValue = "Picture 4",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture4", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture4",
                        ResourceValue = "Hình ảnh 4",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture5", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture5",
                        ResourceValue = "Picture 5",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture5", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture5",
                        ResourceValue = "Hình ảnh 5",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture",
                        ResourceValue = "Picture",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.picture", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.picture",
                        ResourceValue = "Hình ảnh",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.text", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.text",
                        ResourceValue = "Comment",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.text", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.text",
                        ResourceValue = "Văn bản",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.alttext", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.alttext",
                        ResourceValue = "Image alternate text",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.alttext", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.alttext",
                        ResourceValue = "Văn bản thay thế hình ảnh",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.link", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.link",
                        ResourceValue = "Link",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.bookinghomebanner.link", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.bookinghomebanner.link",
                        ResourceValue = "Liên kết",
                        LanguageId = vietnameseId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.homepopup.showdate", true) == 0 && lsrt.LanguageId == englishId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.homepopup.showdate",
                        ResourceValue = "Show Date",
                        LanguageId = englishId
                    }
                );
            }

            if (!localeStringResourceTable.Any(lsrt => string.Compare(lsrt.ResourceName, "plugins.widgets.homepopup.showdate", true) == 0 && lsrt.LanguageId == vietnameseId))
            {
                _dataProvider.InsertEntity(
                    new LocaleStringResource
                    {
                        ResourceName = "plugins.widgets.homepopup.showdate",
                        ResourceValue = "Hiển thị ngày",
                        LanguageId = vietnameseId
                    }
                );
            }

            #endregion
        }

        public override void Down()
        {
            //var localeStringResourceTable = _dataProvider.GetTable<LocaleStringResource>();
            //var localeStringResourceRecords = localeStringResourceTable.Where(pat => pat.ResourceName == "search.enterdates" || pat.ResourceName == "search.enterguests");
            //foreach (var localeStringResourceRecord in localeStringResourceRecords)
            //{
            //    _dataProvider.DeleteEntityAsync(localeStringResourceRecord);
            //}
        }
    }
}
