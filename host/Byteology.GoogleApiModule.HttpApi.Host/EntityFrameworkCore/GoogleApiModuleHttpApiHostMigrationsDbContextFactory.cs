using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Byteology.GoogleApiModule.EntityFrameworkCore;

public class GoogleApiModuleHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<GoogleApiModuleHttpApiHostMigrationsDbContext>
{
    public GoogleApiModuleHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<GoogleApiModuleHttpApiHostMigrationsDbContext>()
            .UseSqlServer(configuration.GetConnectionString("GoogleApiModule"));

        return new GoogleApiModuleHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
