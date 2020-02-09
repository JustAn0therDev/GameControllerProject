namespace GameControllerProject.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Productor = c.String(maxLength: 100, unicode: false),
                        Publisher = c.String(maxLength: 100, unicode: false),
                        Genre = c.String(maxLength: 100, unicode: false),
                        Website = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Platform",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 100, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        Password = c.String(nullable: false, maxLength: 100, unicode: false),
                        PlayerStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Player");
            DropTable("dbo.Platform");
            DropTable("dbo.Game");
        }
    }
}
