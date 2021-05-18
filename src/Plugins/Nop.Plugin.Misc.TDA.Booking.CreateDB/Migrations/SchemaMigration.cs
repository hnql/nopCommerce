using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.TDA.Booking.CreateDB.Domains;

namespace Nop.Plugin.Misc.TDA.Booking.CreateDB.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2021/05/18 17:08:01:1234567", "Nop.Plugin.Misc.TDA.Booking.CreateDB schema")]
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
            Delete.Table("RoomType");
        }
    }
}
