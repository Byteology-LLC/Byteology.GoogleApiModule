using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Byteology.GoogleApiModule.MongoDB;

public static class GoogleApiModuleMongoDbContextExtensions
{
    public static void ConfigureGoogleApiModule(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
