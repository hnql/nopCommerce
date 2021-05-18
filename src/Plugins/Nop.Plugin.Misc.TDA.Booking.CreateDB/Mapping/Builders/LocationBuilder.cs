﻿using System.Data;
using Nop.Data.Extensions;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Mapping.Builders
{
    public class LocationBuilder : NopEntityBuilder<Location>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //map the primary key (not necessary if it is Id field)
            table.WithColumn(nameof(Location.Id)).AsInt32().PrimaryKey()
            //map the additional properties as foreign keys
            .WithColumn(nameof(Location.LocationCategoryId)).AsInt32().ForeignKey<LocationCategory>(onDelete: Rule.Cascade)
            //avoiding truncation/failure
            //so we set the same max length used in the product name
            .WithColumn(nameof(Location.Name)).AsString(400)
            //not necessary if we don't specify any rules
            .WithColumn(nameof(Location.Description)).AsString(int.MaxValue)
            .WithColumn(nameof(Location.IsActive)).AsBoolean();
        }

        #endregion
    }
}