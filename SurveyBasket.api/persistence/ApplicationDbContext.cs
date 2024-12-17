
using System.Reflection;
using System.Security.Claims;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public DbSet<Poll> Polls { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entris = ChangeTracker.Entries<AutibaleEntity>();
        foreach (var entr in entris) {
            var currentUserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            if (entr.State == EntityState.Added)
            {
                entr.Property(x => x.CreatedById).CurrentValue = currentUserId;
            }
            if(entr.State == EntityState.Modified)
            {
                entr.Property(x => x.UpdatedById).CurrentValue = currentUserId;
                entr.Property(x => x.UpdatedOn).CurrentValue = DateTime.UtcNow;
            }
        }
        return base.SaveChangesAsync( cancellationToken);
    }
}
