using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Booking.DB.Domains;

namespace Nop.Plugin.Booking.DB.Migrations
{
    [NopMigration("2021/05/18 21:30:01:1234567", "Nop.Plugin.Booking.DB schema")]
    public class SchemaMigration : Migration
    {
        private readonly IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        /// <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            _migrationManager.BuildTable<RoomType>(Create);
            _migrationManager.BuildTable<LocationCategory>(Create);
            _migrationManager.BuildTable<Location>(Create);
            _migrationManager.BuildTable<Room>(Create);
        }

        public override void Down()
        {
            // Do nothing, we don't want to remove tables
        }
    }
}
