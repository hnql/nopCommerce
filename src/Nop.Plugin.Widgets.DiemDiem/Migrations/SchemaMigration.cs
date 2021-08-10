using FluentMigrator;
using Nop.Data.Migrations;

namespace Nop.Plugin.Widgets.DiemDiem.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("", "Nop.Plugin.Widgets.DiemDiem schema")]
    public class SchemaMigration : AutoReversingMigration
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
        }
    }
}
