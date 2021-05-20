using FluentMigrator;
using Nop.Data.Migrations;
using Nop.Plugin.Database.UserRelated.Domains;

namespace Nop.Plugin.Database.UserRelated.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("2021/05/17 12:00:00:6000001", "User schema")]
    public class SchemaMigration : FluentMigrator.Migration
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
            _migrationManager.BuildTable<User>(Create);
        }
        public override void Down()
        {
        }
    }
}
