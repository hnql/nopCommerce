using FluentMigrator;
using Nop.Data.Migrations;
using System.Linq;
using Nop.Data;

namespace Nop.Plugin.Booking.Main.Migrations
{
    [NopMigration("2021/07/30 20:50:01:1234561", "Nop.Plugin.Booking.Main schema")]
    public class SchemaMigration : AutoReversingMigration
    {
        private readonly IMigrationManager _migrationManager;

        public SchemaMigration(IMigrationManager migrationManager, INopDataProvider dataProvider)
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
