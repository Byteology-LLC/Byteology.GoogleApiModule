using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Byteology.GoogleApiModule.EntityFrameworkCore;

[ConnectionStringName(GoogleApiModuleDbProperties.ConnectionStringName)]
public interface IGoogleApiModuleDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
