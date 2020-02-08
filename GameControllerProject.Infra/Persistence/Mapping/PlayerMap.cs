using GameControllerProject.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace GameControllerProject.Infra.Persistence.Mapping
{
    public class PlayerMap : EntityTypeConfiguration<Player>
    {
        public PlayerMap()
        {
            ToTable("Player");

            Property(p => p.Email.Address)
                .HasMaxLength(250)
                .IsRequired()
                .HasColumnName("Email");

            Property(p => p.Name.FirstName)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("FirstName");

            Property(p => p.Name.LastName)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("LastName");

            Property(p => p.Password)
                .HasMaxLength(100)
                .IsRequired()
                .HasColumnName("Password");

            Property(p => p.Status)
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnName("PlayerStatus");
        }
    }
}
