using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Mapping.Builders
{
    public class RoomTypeBuilder : NopEntityBuilder<RoomType>
    {
        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table.WithColumn(nameof(RoomType.Id)).AsInt32().PrimaryKey()
            .WithColumn(nameof(RoomType.Name)).AsString(400);
        }
    }
}
