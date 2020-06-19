namespace SiteAnalyzerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MinResponseTime = c.Int(nullable: false),
                        MaxResponseTime = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
            CreateTable(
                "dbo.Sites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        MinResponseTime = c.Int(nullable: false),
                        MaxResponseTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        ResponseTime = c.Int(nullable: false),
                        SiteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sites", t => t.SiteId, cascadeDelete: true)
                .Index(t => t.SiteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pages", "SiteId", "dbo.Sites");
            DropForeignKey("dbo.Histories", "SiteId", "dbo.Sites");
            DropIndex("dbo.Pages", new[] { "SiteId" });
            DropIndex("dbo.Histories", new[] { "SiteId" });
            DropTable("dbo.Pages");
            DropTable("dbo.Sites");
            DropTable("dbo.Histories");
        }
    }
}
