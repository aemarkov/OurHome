namespace OurHome.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ResourceConsumption_and_Registrators_to_Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourceConsumptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreationTime = c.DateTime(nullable: false),
                        Consumption = c.Single(nullable: false),
                        RegistratorId = c.Int(nullable: false),
                        CreatorUserId = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Registrators", t => t.RegistratorId, cascadeDelete: true)
                .Index(t => t.RegistratorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResourceConsumptions", "RegistratorId", "dbo.Registrators");
            DropIndex("dbo.ResourceConsumptions", new[] { "RegistratorId" });
            DropTable("dbo.ResourceConsumptions");
        }
    }
}
