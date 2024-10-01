using FluentMigrator;

namespace Restaurant.Postgres.Migration.Migrations;

[Migration(2)]
public class M0002_CreateOrderItemsTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("order_items")
            .WithColumn("id").AsInt32().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("order_id").AsInt32().NotNullable()
            .WithColumn("dish_id").AsInt32().NotNullable()
            .WithColumn("status").AsInt16()
            .WithColumn("price").AsFloat();

        Create.ForeignKey().FromTable("order_item").ForeignColumn("order_id").ToTable("orders").PrimaryColumn("id");
        Create.ForeignKey().FromTable("order_item").ForeignColumn("dish_id").ToTable("dishes").PrimaryColumn("id");
    }

    public override void Down()
    {
        Delete.ForeignKey().FromTable("order_item").ForeignColumn("order_id").ToTable("orders").PrimaryColumn("id");
        Delete.ForeignKey().FromTable("order_item").ForeignColumn("dish_id").ToTable("dishes").PrimaryColumn("id");
        Delete.Table("order_items");
    }
}