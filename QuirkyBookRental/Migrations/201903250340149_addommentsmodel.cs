namespace QuirkyBookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addommentsmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        bookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Books", t => t.bookId, cascadeDelete: true)
                .Index(t => t.bookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "bookId", "dbo.Books");
            DropIndex("dbo.Comments", new[] { "bookId" });
            DropTable("dbo.Comments");
        }
    }
}
