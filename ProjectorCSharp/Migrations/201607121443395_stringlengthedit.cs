namespace ProjectorCSharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stringlengthedit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Lastname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "Firstname", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "Username", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.People", "Password", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Firstname", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Lastname", c => c.String(nullable: false));
        }
    }
}
