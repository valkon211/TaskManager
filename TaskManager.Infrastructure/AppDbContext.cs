using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;

namespace TaskManager.Infrastructure;

public class AppDbContext : DbContext
{
    public DbSet<TaskEntity> Tasks { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        try
        {
            if (Database.CanConnect() == false)
                throw new InvalidOperationException("Database not found.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Error connecting to Database: {ex.Message}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("tasks");
            entity.Property(t => t.Id)
                .IsRequired()
                .HasColumnName("task_id");
            entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(70);
            entity.Property(t => t.Description)
                .HasMaxLength(200);
            entity.Property(t => t.Status)
                .HasConversion<int>();

            entity.HasKey(t => t.Id);
        });
    }
}