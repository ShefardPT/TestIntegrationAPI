using Microsoft.EntityFrameworkCore;
using TestIntegration.API.DataAccess.Entities;

namespace TestIntegration.API.DataAccess;

public class AppDbContext : DbContext
{
    public DbSet<UsersDataRequestRecord> UsersDataRequestRecords { get; set; }

    public AppDbContext(){ }
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UsersDataRequestRecord>(entity =>
        {
            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .ValueGeneratedOnAdd()
                .HasColumnType("bigint")
                .HasColumnName("id");

            entity.Property(e => e.Login)
                .HasColumnType("text")
                .HasColumnName("login");

            entity.Property(e => e.RequestedOn)
                .HasColumnType("timestamp with time zone")
                .HasColumnName("requested_on");

            entity.HasKey("Id");

            entity.ToTable("users_data_request_records");
        });
    }
}

