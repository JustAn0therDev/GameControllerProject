using GameControllerProject.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GameControllerProject.Infra.Persistence.Mapping
{
    public class PlatformMap : EntityTypeConfiguration<Platform>
    {
        public PlatformMap()
        {
            ToTable("Platform");

            Property(p => p.Name)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
