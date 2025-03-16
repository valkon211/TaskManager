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
                throw new InvalidOperationException("База данных не обнаружена.");
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException($"Ошибка при подключении к БД: {ex.Message}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskEntity>(entity =>
        {
            entity.ToTable("Tasks");
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(70);
            entity.Property(t => t.Description)
                .HasMaxLength(200);
            entity.Property(t => t.Status)
                .HasConversion<string>(); // Enum -> string в БД
            // entity.HasOne(t => t.User) 
            //     .WithMany(u => u.Tasks)
            //     .HasForeignKey(t => t.UserId)
            //     .OnDelete(DeleteBehavior.Cascade); // Связь "многие к одному"
        });
    }
}