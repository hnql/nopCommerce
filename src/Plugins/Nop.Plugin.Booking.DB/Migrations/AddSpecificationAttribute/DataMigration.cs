using System.Linq;
using FluentMigrator;
using Nop.Core.Domain.Catalog;
using Nop.Data;
using Nop.Data.Migrations;

namespace Nop.Plugin.Booking.DB.Migrations.AddSpecificationAttribute
{
    [SkipMigrationOnUpdate] // If you want to re-install plugin, please remove [SkipMigrationOnUpdate]
    [NopMigration("2021/06/03 21:30:01:1234567", "Add data for specification attribute table")]
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
            var specificationAttributeGroupTable = _dataProvider.GetTable<SpecificationAttributeGroup>();
            if (!specificationAttributeGroupTable.Any(sag => string.Compare(sag.Name, "amenities", true) == 0))
            {
                #region Insert data to SpecificationAttributeGroup table

                var groupEntity = _dataProvider.InsertEntity(
                    new SpecificationAttributeGroup
                    {
                        Name = "amenities",
                        DisplayOrder = 0
                    }
                );

                #endregion

                #region Insert data to SpecificationAttribute table

                var specificationAttribute = _dataProvider.GetTable<SpecificationAttribute>();
                if (!specificationAttribute.Any(sat => string.Compare(sat.Name, "facilities") == 0))
                {
                    var attributeEntity = _dataProvider.InsertEntity(
                        new SpecificationAttribute
                        {
                            Name = "facilities",
                            DisplayOrder = 0,
                            SpecificationAttributeGroupId = groupEntity.Id
                        }
                    );

                    #region Insert data to SpecificationAttributeOption table
                    var specificationAttributeOption = _dataProvider.GetTable<SpecificationAttributeOption>();
                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Wifi") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Wifi",
                                DisplayOrder = 0,
                                ColorSquaresRgb = "#FFFFAF",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "TV") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "TV",
                                DisplayOrder = 1,
                                ColorSquaresRgb = "#FFFFBF",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Điều hòa") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Điều hòa",
                                DisplayOrder = 2,
                                ColorSquaresRgb = "#FFFFFA",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Dầu gội, dầu xả") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Dầu gội, dầu xả",
                                DisplayOrder = 3,
                                ColorSquaresRgb = "#FFFFFB",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Khăn tắm") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Khăn tắm",
                                DisplayOrder = 4,
                                ColorSquaresRgb = "#FFFFFC",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Kem đánh răng") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Kem đánh răng",
                                DisplayOrder = 5,
                                ColorSquaresRgb = "#FFFFFD",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Xà phòng tắm") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Xà phòng tắm",
                                DisplayOrder = 6,
                                ColorSquaresRgb = "#FFFFFE",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Máy sấy") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Máy sấy",
                                DisplayOrder = 7,
                                ColorSquaresRgb = "#FFFFFF",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    #endregion
                }

                if (!specificationAttribute.Any(sat => string.Compare(sat.Name, "facilities.kitchen") == 0))
                {
                    var attributeEntity = _dataProvider.InsertEntity(
                        new SpecificationAttribute
                        {
                            Name = "facilities.kitchen",
                            DisplayOrder = 1,
                            SpecificationAttributeGroupId = groupEntity.Id
                        }
                    );

                    #region Insert data to SpecificationAttributeOption table
                    var specificationAttributeOption = _dataProvider.GetTable<SpecificationAttributeOption>();
                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Bếp điện") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Bếp điện",
                                DisplayOrder = 0,
                                ColorSquaresRgb = "#FFFFFA",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Lò vi sóng") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Lò vi sóng",
                                DisplayOrder = 1,
                                ColorSquaresRgb = "#FFFFFB",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Tủ lạnh") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Tủ lạnh",
                                DisplayOrder = 2,
                                ColorSquaresRgb = "#FFFFFC",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    #endregion
                }

                if (!specificationAttribute.Any(sat => string.Compare(sat.Name, "facilities.special") == 0))
                {
                    var attributeEntity = _dataProvider.InsertEntity(
                        new SpecificationAttribute
                        {
                            Name = "facilities.special",
                            DisplayOrder = 2,
                            SpecificationAttributeGroupId = groupEntity.Id
                        }
                    );

                    #region Insert data to SpecificationAttributeOption table
                    var specificationAttributeOption = _dataProvider.GetTable<SpecificationAttributeOption>();
                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Smart TV") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Smart TV",
                                DisplayOrder = 0,
                                ColorSquaresRgb = "#FFFFFA",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    #endregion
                }

                if (!specificationAttribute.Any(sat => string.Compare(sat.Name, "families") == 0))
                {
                    var attributeEntity = _dataProvider.InsertEntity(
                        new SpecificationAttribute
                        {
                            Name = "families",
                            DisplayOrder = 3,
                            SpecificationAttributeGroupId = groupEntity.Id
                        }
                    );

                    #region Insert data to SpecificationAttributeOption table
                    var specificationAttributeOption = _dataProvider.GetTable<SpecificationAttributeOption>();
                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Phù hợp với trẻ nhỏ") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Phù hợp với trẻ nhỏ",
                                DisplayOrder = 0,
                                ColorSquaresRgb = "#FFFFFA",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    if (!specificationAttributeOption.Any(sao => string.Compare(sao.Name, "Đệm bổ sung") == 0))
                    {
                        _dataProvider.InsertEntity(
                            new SpecificationAttributeOption
                            {
                                Name = "Đệm bổ sung",
                                DisplayOrder = 1,
                                ColorSquaresRgb = "#FFFFFA",
                                SpecificationAttributeId = attributeEntity.Id
                            }
                        );
                    }

                    #endregion
                }

                #endregion
            }
        }

        public override void Down()
        {

        }
    }
}
