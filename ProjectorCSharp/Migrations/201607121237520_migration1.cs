namespace ProjectorCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Lastname", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.Projects", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Name", c => c.String());
            AlterColumn("dbo.Projects", "Code", c => c.String());
            AlterColumn("dbo.People", "Password", c => c.String());
            AlterColumn("dbo.People", "Username", c => c.String());
            AlterColumn("dbo.People", "Firstname", c => c.String());
            AlterColumn("dbo.People", "Lastname", c => c.String());
        }
    }
}
