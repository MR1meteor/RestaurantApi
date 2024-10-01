using FluentMigrator;

namespace Restaurant.Postgres.Migration.Migrations;

[Migration(3)]
public class M0003_CreateMenusTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("menus")
            .WithColumn("id").AsInt32().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("title").AsString().NotNullable()
            .WithColumn("description").AsString();
    }

    public override void Down()
    {
        Delete.Table("menus");
    }
}