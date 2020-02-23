using GameControllerProject.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace GameControllerProject.Infra.Persistence.Mapping
{
    public class GamePlatformMap : EntityTypeConfiguration<GamePlatform>
    {
        public GamePlatformMap()
        {
            ToTable("GamePlatform");

            Property(p => p.GameId)
                .IsRequired();
            Property(p => p.PlatformId)
                .IsRequired();
        }
    }
}
