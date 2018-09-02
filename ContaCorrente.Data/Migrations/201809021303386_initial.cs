namespace ContaCorrente.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountCode = c.String(nullable: false, maxLength: 56, unicode: false),
                        CurrentBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AccountTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionDateTime = c.DateTime(nullable: false),
                        TransactionType = c.Int(nullable: false),
                        TransactionValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.AccountId)
                .Index(t => t.AccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountTransaction", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Account", "ClientId", "dbo.Client");
            DropIndex("dbo.AccountTransaction", new[] { "AccountId" });
            DropIndex("dbo.Account", new[] { "ClientId" });
            DropTable("dbo.AccountTransaction");
            DropTable("dbo.Client");
            DropTable("dbo.Account");
        }
    }
}
