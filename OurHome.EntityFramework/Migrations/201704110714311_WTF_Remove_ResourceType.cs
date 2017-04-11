namespace OurHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WTF_Remove_ResourceType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registrators", "Resource_Id", "dbo.ResourceTypes");
            DropIndex("dbo.Registrators", new[] { "Resource_Id" });
            DropColumn("dbo.Registrators", "ResourceId");
            DropColumn("dbo.Registrators", "Resource_Id");
            DropTable("dbo.ResourceTypes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResourceTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        DisplayText = c.String(nullable: false, maxLength: 32),
                        Unit = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Registrators", "Resource_Id", c => c.String(maxLength: 10));
            AddColumn("dbo.Registrators", "ResourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrators", "Resource_Id");
            AddForeignKey("dbo.Registrators", "Resource_Id", "dbo.ResourceTypes", "Id");
        }
    }
}
