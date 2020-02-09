namespace GameControllerProject.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatformMapping : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Platform", "Name", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Platform", "Name", c => c.String(maxLength: 100, unicode: false));
        }
    }
}
