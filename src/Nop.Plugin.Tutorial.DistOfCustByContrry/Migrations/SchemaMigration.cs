using FluentMigrator;
using Nop.Data.Migrations;

namespace Nop.Plugin.Tutorial.DistOfCustByContrry.Migrations
{
    [SkipMigrationOnUpdate]
    [NopMigration("", "Nop.Plugin.Tutorial.DistOfCustByContrry schema")]
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
