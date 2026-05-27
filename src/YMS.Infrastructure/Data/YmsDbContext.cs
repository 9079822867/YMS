using Microsoft.EntityFrameworkCore;
using YMS.Domain.Entities;

namespace YMS.Infrastructure.Data;

public class YmsDbContext : DbContext
{
    public YmsDbContext(DbContextOptions<YmsDbContext> options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Yard> Yards => Set<Yard>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<Report> Reports => Set<Report>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Vehicle>(e =>
        {
            e.HasQueryFilter(v => !v.IsDeleted);
            e.HasOne(v => v.Client).WithMany(c => c.Vehicles).HasForeignKey(v => v.ClientId);
            e.HasOne(v => v.Yard).WithMany(y => y.Vehicles).HasForeignKey(v => v.YardId);
            e.Property(v => v.ParkingCharges).HasColumnType("decimal(10,2)");
            e.Property(v => v.TowingCharges).HasColumnType("decimal(10,2)");
            e.Property(v => v.MiscCharges).HasColumnType("decimal(10,2)");
        });

        modelBuilder.Entity<Report>(e =>
        {
            e.HasQueryFilter(r => !r.IsDeleted);
            e.HasOne(r => r.Vehicle).WithMany(v => v.Reports).HasForeignKey(r => r.VehicleId);
        });

        modelBuilder.Entity<User>(e =>
        {
            e.HasQueryFilter(u => !u.IsDeleted);
            e.HasIndex(u => u.Email).IsUnique();
        });

        SeedData(modelBuilder);
    }

    private static void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            FullName = "Admin User",
            Email = "admin@yms.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
            Role = "Admin",
            IsActive = true
        });

        modelBuilder.Entity<Client>().HasData(
            new Client { Id = 1, Name = "HDFC Bank", ContactPerson = "HDFC Manager", Phone = "9000000001", Email = "hdfc@yms.com" },
            new Client { Id = 2, Name = "ICICI Bank", ContactPerson = "ICICI Manager", Phone = "9000000002", Email = "icici@yms.com" },
            new Client { Id = 3, Name = "Axis Bank", ContactPerson = "Axis Manager", Phone = "9000000003", Email = "axis@yms.com" }
        );

        modelBuilder.Entity<Yard>().HasData(
            new Yard { Id = 1, Name = "Mumbai Yard", Address = "Andheri West", ManagerName = "Ravi Kumar", ContactNumber = "9111111111", City = "Mumbai", State = "Maharashtra" },
            new Yard { Id = 2, Name = "Pune Yard", Address = "Kharadi", ManagerName = "Suresh Patil", ContactNumber = "9222222222", City = "Pune", State = "Maharashtra" },
            new Yard { Id = 3, Name = "Jaipur Yard", Address = "Malviya Nagar", ManagerName = "Ramesh Sharma", ContactNumber = "9333333333", City = "Jaipur", State = "Rajasthan" }
        );
    }
}
