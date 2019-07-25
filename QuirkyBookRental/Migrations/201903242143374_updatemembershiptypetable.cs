namespace QuirkyBookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemembershiptypetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "ChargeRateTwoweeks", c => c.Byte());
            AddColumn("dbo.MembershipTypes", "ChargeRateTwoMonth", c => c.Byte());
            AddColumn("dbo.MembershipTypes", "ChargeRateThreeMonth", c => c.Byte());
            AddColumn("dbo.MembershipTypes", "ChargeRateFourMonth", c => c.Byte());
            AddColumn("dbo.MembershipTypes", "ChargeRateFiveMonth", c => c.Byte());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "ChargeRateFiveMonth");
            DropColumn("dbo.MembershipTypes", "ChargeRateFourMonth");
            DropColumn("dbo.MembershipTypes", "ChargeRateThreeMonth");
            DropColumn("dbo.MembershipTypes", "ChargeRateTwoMonth");
            DropColumn("dbo.MembershipTypes", "ChargeRateTwoweeks");
        }
    }
}
