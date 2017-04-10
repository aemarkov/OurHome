namespace OurHome.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Models : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CityId = c.Int(nullable: false),
                        Street = c.String(nullable: false, maxLength: 100),
                        Building = c.String(maxLength: 10),
                        Flat = c.String(maxLength: 10),
                        Notes = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Customer_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.AbpUsers", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_News_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registrators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Long(nullable: false),
                        ResourceId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Resource_Id = c.String(maxLength: 10),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Registrator_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ResourceTypes", t => t.Resource_Id)
                .Index(t => t.CustomerId)
                .Index(t => t.Resource_Id);
            
            CreateTable(
                "dbo.ResourceTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 10),
                        DisplayText = c.String(nullable: false, maxLength: 32),
                        Unit = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AbpUsers", "Middlename", c => c.String(maxLength: 32));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registrators", "Resource_Id", "dbo.ResourceTypes");
            DropForeignKey("dbo.Registrators", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Id", "dbo.AbpUsers");
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropIndex("dbo.Registrators", new[] { "Resource_Id" });
            DropIndex("dbo.Registrators", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropIndex("dbo.Customers", new[] { "Id" });
            DropColumn("dbo.AbpUsers", "Middlename");
            DropTable("dbo.ResourceTypes");
            DropTable("dbo.Registrators",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Registrator_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.News",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_News_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Customers",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Customer_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Cities");
        }
    }
}
