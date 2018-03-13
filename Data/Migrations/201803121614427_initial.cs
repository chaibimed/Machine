namespace MachineCafe.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MachineStates",
                c => new
                    {
                        TypeOfGrain = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TypeOfGrain);
            
            CreateTable(
                "dbo.UserPreferences",
                c => new
                    {
                        Type = c.Int(nullable: false, identity: true),
                        Sucre = c.Int(nullable: false),
                        SelfMug = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Type);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserPreferences");
            DropTable("dbo.MachineStates");
        }
    }
}
