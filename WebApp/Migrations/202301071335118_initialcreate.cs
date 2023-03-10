namespace WebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.__MigrationHistory",
                c => new
                    {
                        MigrationId = c.String(nullable: false, maxLength: 150),
                        ContextKey = c.String(nullable: false, maxLength: 300),
                        Model = c.Binary(nullable: false),
                        ProductVersion = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => new { t.MigrationId, t.ContextKey });
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        CandidateNumber = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        MiddleName = c.String(),
                        LastName = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        NativeLanguage = c.String(nullable: false),
                        CountryOfResidence = c.String(nullable: false),
                        Birthdate = c.DateTime(nullable: false),
                        Email = c.String(nullable: false),
                        LandLineNumber = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        PostalCode = c.String(nullable: false),
                        Town = c.String(nullable: false),
                        Province = c.String(nullable: false),
                        PhotoIdType = c.String(nullable: false),
                        PhotoIdNumber = c.String(nullable: false),
                        PhotoIdDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CandidateNumber);
            
            CreateTable(
                "dbo.Certificates",
                c => new
                    {
                        CertificateId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 128),
                        CandidateNumber = c.Int(nullable: false),
                        AssessmentTestCode = c.Int(nullable: false),
                        ExaminationDate = c.DateTime(nullable: false),
                        ScoreReportDate = c.DateTime(nullable: false),
                        CandidateScore = c.Int(nullable: false),
                        MaximumScore = c.Int(nullable: false),
                        AssessmentResultLabel = c.String(),
                        PercentageScore = c.String(),
                    })
                .PrimaryKey(t => t.CertificateId)
                .ForeignKey("dbo.Candidates", t => t.CandidateNumber, cascadeDelete: true)
                .ForeignKey("dbo.CertificateTitle", t => t.Title, cascadeDelete: true)
                .Index(t => t.Title)
                .Index(t => t.CandidateNumber);
            
            CreateTable(
                "dbo.CertificateTitle",
                c => new
                    {
                        Title = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Title);
            
            CreateTable(
                "dbo.CertificateTopic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        Mark = c.Int(nullable: false),
                        CertificateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Certificates", t => t.CertificateId, cascadeDelete: true)
                .Index(t => t.CertificateId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CertificateTopic", "CertificateId", "dbo.Certificates");
            DropForeignKey("dbo.Certificates", "Title", "dbo.CertificateTitle");
            DropForeignKey("dbo.Certificates", "CandidateNumber", "dbo.Candidates");
            DropIndex("dbo.CertificateTopic", new[] { "CertificateId" });
            DropIndex("dbo.Certificates", new[] { "CandidateNumber" });
            DropIndex("dbo.Certificates", new[] { "Title" });
            DropTable("dbo.CertificateTopic");
            DropTable("dbo.CertificateTitle");
            DropTable("dbo.Certificates");
            DropTable("dbo.Candidates");
            DropTable("dbo.__MigrationHistory");
        }
    }
}
