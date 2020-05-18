namespace Assignment4_ALI_K_MOHAMAD.N.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransactionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Single(nullable: false),
                        CheckingAccountId = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionSource = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckingAccounts", t => t.CheckingAccountId, cascadeDelete: true)
                .Index(t => t.CheckingAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CheckingAccountId", "dbo.CheckingAccounts");
            DropIndex("dbo.Transactions", new[] { "CheckingAccountId" });
            DropTable("dbo.Transactions");
        }
    }
}
