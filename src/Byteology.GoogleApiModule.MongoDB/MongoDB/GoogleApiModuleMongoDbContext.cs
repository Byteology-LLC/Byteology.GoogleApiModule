using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Byteology.GoogleApiModule.MongoDB;

[ConnectionStringName(GoogleApiModuleDbProperties.ConnectionStringName)]
public class GoogleApiModuleMongoDbContext : AbpMongoDbContext, IGoogleApiModuleMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureGoogleApiModule();
    }
}
