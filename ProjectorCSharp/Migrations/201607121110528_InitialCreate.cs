namespace ProjectorCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectID = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectID, cascadeDelete: true)
                .Index(t => t.ProjectID)
                .Index(t => t.PersonID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Lastname = c.String(),
                        Firstname = c.String(),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Remarks = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignments", "ProjectID", "dbo.Projects");
            DropForeignKey("dbo.Assignments", "PersonID", "dbo.People");
            DropIndex("dbo.Assignments", new[] { "PersonID" });
            DropIndex("dbo.Assignments", new[] { "ProjectID" });
            DropTable("dbo.Projects");
            DropTable("dbo.People");
            DropTable("dbo.Assignments");
        }
    }
}
