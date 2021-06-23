using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sport.API.Models;

namespace Sport.API.Contexts.Maps
{
    public class ModalityMap : IEntityTypeConfiguration<Modality>
    { 
        public void Configure(EntityTypeBuilder<Modality> builder)
        {
            builder.ToTable("Modality");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Team).IsRequired();
        }
    }
}
