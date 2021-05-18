using System.Data;
using Nop.Data.Extensions;
using FluentMigrator.Builders.Create.Table;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;
using Nop.Data.Mapping.Builders;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Mapping.Builders
{
    public class RoomBuilder : NopEntityBuilder<Room>
    {
        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            //table.WithColumn(nameof(Room.Id)).AsInt32().PrimaryKey().ForeignKey<Product>(onDelete: Rule.Cascade)
            table.WithColumn(nameof(Room.Id)).AsInt32().PrimaryKey()
            .WithColumn(nameof(Room.LocationId)).AsInt32().ForeignKey<Location>()
            .WithColumn(nameof(Room.RoomTypeId)).AsInt32().ForeignKey<RoomType>()
            .WithColumn(nameof(Room.Name)).AsString(400)
            .WithColumn(nameof(Room.Description)).AsString(int.MaxValue)
            .WithColumn(nameof(Room.Price)).AsDecimal(18, 4)
            .WithColumn(nameof(Room.MaximumDate)).AsInt32()
            .WithColumn(nameof(Room.IsActive)).AsBoolean();
        }
    }
}
