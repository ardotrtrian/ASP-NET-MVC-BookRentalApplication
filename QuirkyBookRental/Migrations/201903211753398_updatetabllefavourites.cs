namespace QuirkyBookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetabllefavourites : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Favourites", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Favourites", "UserId", c => c.Int(nullable: false));
        }
    }
}
