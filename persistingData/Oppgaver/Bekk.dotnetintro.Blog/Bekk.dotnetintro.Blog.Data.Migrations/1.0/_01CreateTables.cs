using FluentMigrator;

namespace Bekk.dotnetintro.Blog.Data.Migrations._1._0
{
    [Migration(1)]
    public  class _01CreateTables : AutoReversingMigration
    {
        public override void Up()
        {
            // Opprett tabellene du trenger her ved FluentMigrator sitt Fluent-API
            // Create.Table("MyNewTable").WithColumn("MyIdColumn").AsInt32().Identity().NotNullable();
            // Mer info: https://github.com/schambers/fluentmigrator
        }
    }
}
