using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Byteology.GoogleApiModule.EntityFrameworkCore;

public static class GoogleApiModuleDbContextModelCreatingExtensions
{
    public static void ConfigureGoogleApiModule(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        /* Configure all entities here. Example:

        builder.Entity<Question>(b =>
        {
            //Configure table & schema name
            b.ToTable(GoogleApiModuleDbProperties.DbTablePrefix + "Questions", GoogleApiModuleDbProperties.DbSchema);

            b.ConfigureByConvention();

            //Properties
            b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);

            //Relations
            b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

            //Indexes
            b.HasIndex(q => q.CreationTime);
        });
        */
    }
}
