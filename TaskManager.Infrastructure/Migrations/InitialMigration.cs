using FluentMigrator;

namespace TaskManager.Infrastructure.Migrations;

[Migration(000000000000, "Initial migration: tasks table creation")]
public class InitialMigration: Migration
{
    public override void Up()
    {
        Create
            .Table("tasks")
            .InSchema("task_manager")
            .WithColumn("task_id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("title").AsString().NotNullable()
            .WithColumn("description").AsString().Nullable()
            .WithColumn("status").AsInt16().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("task").InSchema("task_manager");
    }
}