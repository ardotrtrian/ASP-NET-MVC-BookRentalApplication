namespace QuirkyBookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemembershiptypetable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "ChargeRateTwoweeks", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "ChargeRateTwoMonth", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "ChargeRateThreeMonth", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "ChargeRateFourMonth", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "ChargeRateFiveMonth", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "ChargeRateFiveMonth", c => c.Byte());
            AlterColumn("dbo.MembershipTypes", "ChargeRateFourMonth", c => c.Byte());
            AlterColumn("dbo.MembershipTypes", "ChargeRateThreeMonth", c => c.Byte());
            AlterColumn("dbo.MembershipTypes", "ChargeRateTwoMonth", c => c.Byte());
            AlterColumn("dbo.MembershipTypes", "ChargeRateTwoweeks", c => c.Byte());
        }
    }
}
