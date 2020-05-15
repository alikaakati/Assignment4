namespace Assignment4_ALI_K_MOHAMAD.N.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CheckingAccounts", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.CheckingAccounts", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CheckingAccounts", "LastName", c => c.String());
            AlterColumn("dbo.CheckingAccounts", "FirstName", c => c.String());
        }
    }
}
