namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionsandspeakers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SessionId = c.Int(nullable: false),
                        Title = c.String(),
                        DescriptionShort = c.String(),
                        Description = c.String(),
                        Tenant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.Tenant_Id)
                .Index(t => t.Tenant_Id);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ImageUrl = c.String(),
                        WebSite = c.String(),
                        Bio = c.String(),
                        AllowHtml = c.Boolean(nullable: false),
                        PictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SpeakerSessions",
                c => new
                    {
                        Speaker_Id = c.Int(nullable: false),
                        Session_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Speaker_Id, t.Session_Id })
                .ForeignKey("dbo.Speakers", t => t.Speaker_Id, cascadeDelete: true)
                .ForeignKey("dbo.Sessions", t => t.Session_Id, cascadeDelete: true)
                .Index(t => t.Speaker_Id)
                .Index(t => t.Session_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sessions", "Tenant_Id", "dbo.Tenants");
            DropForeignKey("dbo.SpeakerSessions", "Session_Id", "dbo.Sessions");
            DropForeignKey("dbo.SpeakerSessions", "Speaker_Id", "dbo.Speakers");
            DropIndex("dbo.SpeakerSessions", new[] { "Session_Id" });
            DropIndex("dbo.SpeakerSessions", new[] { "Speaker_Id" });
            DropIndex("dbo.Sessions", new[] { "Tenant_Id" });
            DropTable("dbo.SpeakerSessions");
            DropTable("dbo.Speakers");
            DropTable("dbo.Sessions");
        }
    }
}
