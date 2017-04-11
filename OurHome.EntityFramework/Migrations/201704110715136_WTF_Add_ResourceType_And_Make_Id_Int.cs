namespace OurHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WTF_Add_ResourceType_And_Make_Id_Int : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(nullable: false, maxLength: 10),
                        DisplayText = c.String(nullable: false, maxLength: 32),
                        Unit = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Registrators", "ResourceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Registrators", "ResourceId");
            AddForeignKey("dbo.Registrators", "ResourceId", "dbo.ResourceTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrators", "ResourceId", "dbo.ResourceTypes");
            DropIndex("dbo.Registrators", new[] { "ResourceId" });
            DropColumn("dbo.Registrators", "ResourceId");
            DropTable("dbo.ResourceTypes");
        }
    }
}
