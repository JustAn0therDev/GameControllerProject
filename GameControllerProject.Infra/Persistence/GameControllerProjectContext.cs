using GameControllerProject.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GameControllerProject.Infra.Persistence
{
    public class GameControllerProjectContext : DbContext
    {
        public GameControllerProjectContext() : base("GameControllerProject")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<Player> Players { get; set; }
        public IDbSet<Game> Games { get; set; }
        public IDbSet<Platform> Platforms { get; set; }
        public IDbSet<GamePlatform> GamePlatforms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Seta o schema default
            //modelBuilder.HasDefaultSchema("Apoio");

            //Remove a apluralizacao dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Remove exclusao em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Setar para usar varchar ou inves de nvarchar 
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Caso o tamanho do campo nao seja informado, seta o valor maximo de varchar para 100
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            #region Adiciona entidades mapeadas de forma automatica via assembly

            modelBuilder.Configurations.AddFromAssembly(typeof(GameControllerProjectContext).Assembly);

            #endregion

            base.OnModelCreating(modelBuilder);

        }

    }
}
