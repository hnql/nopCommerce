using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Data.Migrations;
using Nop.Plugin.Booking.DB.Domains;
using Nop.Services.Catalog;
using Nop.Core.Domain.Vendors;

namespace Nop.Plugin.Booking.DB.Migrations.AddVendorAttribute
{
    [SkipMigrationOnUpdate] // If you want to re-install plugin, please remove [SkipMigrationOnUpdate]
    [NopMigration("2021/06/01 21:30:01:1234567", "Add data for vendor attribute table")]
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
            var vendorAttributeTable = _dataProvider.GetTable<VendorAttribute>();
            if (!vendorAttributeTable.Any(vat => string.Compare(vat.Name, "Type", true) == 0))
            {
                #region Insert data to VendorAttribute table

                var vatEntity = _dataProvider.InsertEntity(
                    new VendorAttribute
                    {
                        Name = "Type",
                        IsRequired = true,
                        AttributeControlTypeId = (int)AttributeControlType.DropdownList
                    }
                );

                #endregion

                #region Insert data to VendortAttributeValue table

                var vendorAttributeValueTable = _dataProvider.GetTable<VendorAttributeValue>();
                if (!vendorAttributeValueTable.Any(vavt => string.Compare(vavt.Name, "Biệt thự hồ bơi") == 0))
                {
                    _dataProvider.InsertEntity(
                        new VendorAttributeValue
                        {
                            VendorAttributeId = vatEntity.Id,
                            Name = "Biệt thự hồ bơi",
                            IsPreSelected = true,
                            DisplayOrder = 0
                        }
                    );
                }

                if (!vendorAttributeValueTable.Any(vavt => string.Compare(vavt.Name, "Vi vu ngoại thành") == 0))
                {
                    _dataProvider.InsertEntity(
                        new VendorAttributeValue
                        {
                            VendorAttributeId = vatEntity.Id,
                            Name = "Vi vu ngoại thành",
                            IsPreSelected = false,
                            DisplayOrder = 0
                        }
                    );
                }

                if (!vendorAttributeValueTable.Any(vavt => string.Compare(vavt.Name, "Nội thành lãng mạn") == 0))
                {
                    _dataProvider.InsertEntity(
                        new VendorAttributeValue
                        {
                            VendorAttributeId = vatEntity.Id,
                            Name = "Nội thành lãng mạn",
                            IsPreSelected = false,
                            DisplayOrder = 0
                        }
                    );
                }

                if (!vendorAttributeValueTable.Any(vavt => string.Compare(vavt.Name, "Cần là có ngay") == 0))
                {
                    _dataProvider.InsertEntity(
                        new VendorAttributeValue
                        {
                            VendorAttributeId = vatEntity.Id,
                            Name = "Cần là có ngay",
                            IsPreSelected = false,
                            DisplayOrder = 0
                        }
                    );
                }

                #endregion
            }
        }

        public override void Down()
        {
            
        }
    }
}
