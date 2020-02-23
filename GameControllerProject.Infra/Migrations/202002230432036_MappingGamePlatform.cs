namespace GameControllerProject.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MappingGamePlatform : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GamePlatform",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GameId = c.Guid(nullable: false),
                        PlatformId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GamePlatform");
        }
    }
}
