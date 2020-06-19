namespace SiteAnalyzerDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedHistory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Histories", "SiteURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Histories", "SiteURL");
        }
    }
}
