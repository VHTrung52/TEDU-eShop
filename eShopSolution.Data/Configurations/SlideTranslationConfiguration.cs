using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShopSolution.Data.Configurations
{
    public class SlideTranslationConfiguration : IEntityTypeConfiguration<SlideTranslation>
    {
        public void Configure(EntityTypeBuilder<SlideTranslation> builder)
        {
            builder.ToTable("SlideTranslations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.SlideId).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Url).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired();
            builder.Property(x => x.LanguageId).IsUnicode(false).HasMaxLength(5).IsRequired();
            builder.HasOne(x => x.Language).WithMany(x => x.SlideTranslations).HasForeignKey(x => x.LanguageId);
            builder.HasOne(x => x.Slide).WithMany(x => x.SlideTranslations).HasForeignKey(x => x.SlideId);
        }
    }
}
