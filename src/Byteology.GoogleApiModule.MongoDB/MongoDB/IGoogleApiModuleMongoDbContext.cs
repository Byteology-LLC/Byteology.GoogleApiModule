using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Byteology.GoogleApiModule.MongoDB;

[ConnectionStringName(GoogleApiModuleDbProperties.ConnectionStringName)]
public interface IGoogleApiModuleMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
