using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Byteology.GoogleApiModule.EntityFrameworkCore;

public class GoogleApiModuleHttpApiHostMigrationsDbContext : AbpDbContext<GoogleApiModuleHttpApiHostMigrationsDbContext>
{
    public GoogleApiModuleHttpApiHostMigrationsDbContext(DbContextOptions<GoogleApiModuleHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureGoogleApiModule();
    }
}
