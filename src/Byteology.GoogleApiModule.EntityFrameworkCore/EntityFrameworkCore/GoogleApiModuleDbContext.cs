using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Byteology.GoogleApiModule.EntityFrameworkCore;

[ConnectionStringName(GoogleApiModuleDbProperties.ConnectionStringName)]
public class GoogleApiModuleDbContext : AbpDbContext<GoogleApiModuleDbContext>, IGoogleApiModuleDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public GoogleApiModuleDbContext(DbContextOptions<GoogleApiModuleDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureGoogleApiModule();
    }
}
