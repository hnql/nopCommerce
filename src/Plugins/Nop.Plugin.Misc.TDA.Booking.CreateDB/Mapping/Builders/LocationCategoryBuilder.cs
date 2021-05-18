using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Mapping.Builders
{
    public class LocationCategoryBuilder : NopEntityBuilder<LocationCategory>
    {
        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(LocationCategory.Id)).AsInt32().PrimaryKey()
            .WithColumn(nameof(LocationCategory.Name)).AsString(400);
        }
    }
}
