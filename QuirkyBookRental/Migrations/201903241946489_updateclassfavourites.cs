namespace QuirkyBookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateclassfavourites : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Favourites", "bookId");
            AddForeignKey("dbo.Favourites", "bookId", "dbo.Books", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "bookId", "dbo.Books");
            DropIndex("dbo.Favourites", new[] { "bookId" });
        }
    }
}
