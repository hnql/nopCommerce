using Nop.Data.Migrations;
using Nop.Plugin.Demo.Database.Domains;

namespace Nop.Plugin.Demo.Database.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2021/05/12 12:00:00:2000001", "dbo.LocationCategory base schema")]
    public class LocationCategorySchemaMigration : FluentMigrator.Migration
    {
        private readonly IMigrationManager _migrationManager;

        public LocationCategorySchemaMigration(IMigrationManager migrationManager)
        {
            _migrationManager = migrationManager;
        }

        // <summary>
        /// Collect the UP migration expressions
        /// </summary>
        public override void Up()
        {
            _migrationManager.BuildTable<LocationCategory>(Create);
        }

        public override void Down()
        {
            Delete.Table("LocationCategory");
        }
    }
}