using FluentMigrator;

namespace Restaurant.Postgres.Migration.Migrations;

[Migration(1)]
public class M0001_CreateOrdersTable : FluentMigrator.Migration
{
    public override void Up()
    {
        Create.Table("orders")
            .WithColumn("id").AsInt32().Identity().NotNullable().Unique().PrimaryKey()
            .WithColumn("table_number").AsInt32().NotNullable()
            .WithColumn("status").AsInt16().NotNullable()
            .WithColumn("total_price").AsFloat()
            .WithColumn("created_time").AsDateTime();
    }

    public override void Down()
    {
        Delete.Table("orders");
    }
}