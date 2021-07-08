using FluentMigrator;
using Nop.Data.Migrations;
using System.Linq;
using Nop.Data;

namespace Nop.Plugin.Booking.Main.Migrations
{
    [NopMigration("2021/05/18 13:46:12:1234567", "Nop.Plugin.Booking.Main schema")]
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
