using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Plugin.Booking.DB.Domains;
using Nop.Services.Catalog;

namespace Nop.Plugin.Booking.DB.Migrations.AddProductAttribute
{
    [SkipMigrationOnUpdate] // If you want to re-install plugin, please remove [SkipMigrationOnUpdate]
    [NopMigration("2021/07/30 20:50:01:1234564", "Add data for product attribute table")]
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
            var productAttributeTable = _dataProvider.GetTable<ProductAttribute>();
            if (!productAttributeTable.Any(pat => string.Compare(pat.Name, "Prices", true) == 0))
            {
                #region Insert data to ProductAttribute table

                var patEntity = _dataProvider.InsertEntity(
                    new ProductAttribute
                    {
                        Name = "Prices",
                        Description = "Show price by date, month, year, people increase"
                    }
                );

                #endregion

                #region Insert data to PredefinedProductAttributeValue table

                var predefinedProductAttributeValueTable = _dataProvider.GetTable<PredefinedProductAttributeValue>();
                if (!predefinedProductAttributeValueTable.Any(ppavt => string.Compare(ppavt.Name, "prices.datesofweek") == 0))
                {
                    _dataProvider.InsertEntity(
                        new PredefinedProductAttributeValue
                        {
                            ProductAttributeId = patEntity.Id,
                            Name = "prices.datesofweek",
                            PriceAdjustment = 100,
                            PriceAdjustmentUsePercentage = false,
                            WeightAdjustment = 0,
                            IsPreSelected = false,
                            DisplayOrder = 0
                        }
                    );
                }

                if (!predefinedProductAttributeValueTable.Any(ppavt => string.Compare(ppavt.Name, "prices.weekend") == 0))
                {
                    _dataProvider.InsertEntity(
                        new PredefinedProductAttributeValue
                        {
                            ProductAttributeId = patEntity.Id,
                            Name = "prices.weekend",
                            PriceAdjustment = 100,
                            PriceAdjustmentUsePercentage = false,
                            WeightAdjustment = 0,
                            IsPreSelected = false,
                            DisplayOrder = 1
                        }
                    );
                }

                if (!predefinedProductAttributeValueTable.Any(ppavt => string.Compare(ppavt.Name, "prices.monthly") == 0))
                {
                    _dataProvider.InsertEntity(
                        new PredefinedProductAttributeValue
                        {
                            ProductAttributeId = patEntity.Id,
                            Name = "prices.monthly",
                            PriceAdjustment = -10,
                            PriceAdjustmentUsePercentage = true,
                            WeightAdjustment = 0,
                            IsPreSelected = false,
                            DisplayOrder = 2
                        }
                    );
                }

                if (!predefinedProductAttributeValueTable.Any(ppavt => string.Compare(ppavt.Name, "prices.peopleincrease") == 0))
                {
                    _dataProvider.InsertEntity(
                        new PredefinedProductAttributeValue
                        {
                            ProductAttributeId = patEntity.Id,
                            Name = "prices.peopleincrease",
                            PriceAdjustment = 150,
                            PriceAdjustmentUsePercentage = false,
                            WeightAdjustment = 0,
                            IsPreSelected = false,
                            DisplayOrder = 3
                        }
                    );
                }

                #endregion
            }
        }

        public override void Down()
        {
            //var productAttributeTable = _dataProvider.GetTable<ProductAttribute>();
            //var productAttributeRecord = productAttributeTable.Where(pat => pat.Name == "Prices").FirstOrDefault();
            //if (productAttributeRecord != null)
            //{
            //    _dataProvider.DeleteEntityAsync(productAttributeRecord);
            //}
        }
    }
}
