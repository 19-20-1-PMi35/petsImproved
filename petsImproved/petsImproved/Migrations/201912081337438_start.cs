namespace petsImproved.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class start : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAnimal",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        image = c.Binary(),
                        age = c.Int(nullable: false),
                        sex = c.String(nullable: false),
                        sizeId = c.Int(nullable: false),
                        breed = c.String(),
                        description = c.String(),
                        typeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblSize", t => t.sizeId, cascadeDelete: true)
                .ForeignKey("dbo.tblType", t => t.typeId, cascadeDelete: true)
                .Index(t => t.sizeId)
                .Index(t => t.typeId);
            
            CreateTable(
                "dbo.tblOrder",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        surname = c.String(nullable: false),
                        pnone = c.String(nullable: false),
                        animalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.tblAnimal", t => t.animalId, cascadeDelete: true)
                .Index(t => t.animalId);
            
            CreateTable(
                "dbo.tblSize",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        size = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.tblType",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblAnimal", "typeId", "dbo.tblType");
            DropForeignKey("dbo.tblAnimal", "sizeId", "dbo.tblSize");
            DropForeignKey("dbo.tblOrder", "animalId", "dbo.tblAnimal");
            DropIndex("dbo.tblOrder", new[] { "animalId" });
            DropIndex("dbo.tblAnimal", new[] { "typeId" });
            DropIndex("dbo.tblAnimal", new[] { "sizeId" });
            DropTable("dbo.tblType");
            DropTable("dbo.tblSize");
            DropTable("dbo.tblOrder");
            DropTable("dbo.tblAnimal");
        }
    }
}
