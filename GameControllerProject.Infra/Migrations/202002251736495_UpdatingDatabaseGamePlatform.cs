namespace GameControllerProject.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingDatabaseGamePlatform : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Platform", "Game_Id", "dbo.Game");
            DropIndex("dbo.Platform", new[] { "Game_Id" });
            DropColumn("dbo.Platform", "Game_Id");

            //DropForeignKey("dbo.Platform", "Game_Id1", "dbo.Game");
            //DropIndex("dbo.Platform", new[] { "Game_Id1" });
            //DropColumn("dbo.Platform", "Game_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Platform", "Game_Id1", c => c.Guid());
            AddColumn("dbo.Platform", "Game_Id", c => c.Guid());
            CreateIndex("dbo.Platform", "Game_Id1");
            AddForeignKey("dbo.Platform", "Game_Id1", "dbo.Game", "Id");
        }
    }
}
