using HealthcareClaims.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthcareClaims.Infrastructure.Data;

public class  HealthcareClaimsDbContext:DbContext
{
    public HealthcareClaimsDbContext(DbContextOptions<HealthcareClaimsDbContext> options) :base(options)
    {
        
    }

    public DbSet<Patient> Patients =>Set<Patient>();

    public DbSet<Provider> Providers => Set<Provider>();
    public DbSet<InsurancePolicy> InsurancePolicies => Set<InsurancePolicy>();
    public DbSet<Claim> Claims =>Set<Claim> ();
    public DbSet<ClaimItem> ClaimItems => Set<ClaimItem>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Document> Documents =>Set<Document>();
    public DbSet <User> Users => Set<User> ();
    public DbSet<Role> Roles =>Set <Role>();

    public DbSet<UserRole> UserRoles =>Set <UserRole>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HealthcareClaimsDbContext).Assembly);
    }

    
}
