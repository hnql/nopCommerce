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
