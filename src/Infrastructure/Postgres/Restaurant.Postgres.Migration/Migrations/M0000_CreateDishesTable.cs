using FluentMigrator;

namespace Restaurant.Postgres.Migration.Migrations;

[Migration(0)]
public class M0000_CreateDishesTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("dishes")
            .WithColumn("id").AsInt32().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("description").AsString()
            .WithColumn("category").AsString()
            .WithColumn("is_available").AsBoolean();
    }

    public override void Down()
    {
        Delete.Table("dishes");
    }
}