using FluentMigrator;

namespace Restaurant.Postgres.Migration.Migrations;

[Migration(4)]
public class M0004_CreateMenuItemsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("menu_items")
            .WithColumn("id").AsInt32().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("menu_id").AsInt32().NotNullable()
            .WithColumn("dish_id").AsInt32().NotNullable()
            .WithColumn("price").AsFloat();

        Create.ForeignKey().FromTable("menu_items").ForeignColumn("menu_id").ToTable("menus").PrimaryColumn("id");
        Create.ForeignKey().FromTable("menu_items").ForeignColumn("dish_id").ToTable("dishes").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.ForeignKey().FromTable("menu_items").ForeignColumn("menu_id").ToTable("menus").PrimaryColumn("id");
        Delete.ForeignKey().FromTable("menu_items").ForeignColumn("dish_id").ToTable("dishes").PrimaryColumn("id");
        Delete.Table("menu_items");
    }
}