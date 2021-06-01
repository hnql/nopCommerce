using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Localization;
using Nop.Data;
using Nop.Data.Migrations;

namespace Nop.Plugin.Booking.DB.Migrations.AddLanguage
{
    [SkipMigrationOnUpdate] // If you want to re-install plugin, please remove [SkipMigrationOnUpdate]
    [NopMigration("2021/06/01 22:31:01:1234567", "Add data for language table")]
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
            #region Insert data to Language table

            var languageTable = _dataProvider.GetTable<Language>();
            if (!languageTable.Any(lt => string.Compare(lt.Name, "VI", true) == 0))
            {
                _dataProvider.InsertEntity(
                    new Language
                    {
                        Name = "VI",
                        LanguageCulture = "vi-VN",
                        UniqueSeoCode = "vi",
                        FlagImageFileName = "vn.png",
                        Rtl = false,
                        DefaultCurrencyId = 0,
                        Published = true,
                        DisplayOrder = 2
                    }
                );
            }

            #endregion
        }

        public override void Down()
        {
            //var languageTable = _dataProvider.GetTable<Language>();
            //var languageRecords = languageTable.Where(lt => lt.Name == "VI");
            //foreach (var languageRecord in languageRecords)
            //{
            //    _dataProvider.DeleteEntityAsync(languageRecord);
            //}
        }
    }
}
