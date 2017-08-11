namespace AWS_SNS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SNSAlarms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Type = c.String(),
                        TopicArn = c.String(),
                        Subject = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        eventDateTime = c.String(nullable: false, maxLength: 128),
                        source = c.String(),
                        message = c.String(),
                        exceptionNFO = c.Boolean(nullable: false),
                        eveType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.eventDateTime);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        dType = c.Int(nullable: false),
                        value = c.String(),
                    })
                .PrimaryKey(t => t.name);

            CreateTable(
                "dbo.SNS_Action",
                c => new
                {
                    assemblyName = c.String(),
                    cName = c.Int(nullable: false),
                });
            
            CreateTable(
                "dbo.SNS_Alarm_Action",
                c => new
                    {
                        name = c.String(nullable: false, maxLength: 128),
                        type = c.String(),
                        subject = c.String(),
                        priorityOrder = c.Int(nullable: false),
                        typeName_typeNameId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.name)
                .ForeignKey("dbo.SNS_Action", t => t.typeName_typeNameId)
                .Index(t => t.typeName_typeNameId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SNS_Alarm_Action", "typeName_typeNameId", "dbo.SNS_Action");
            DropIndex("dbo.SNS_Alarm_Action", new[] { "typeName_typeNameId" });
            DropTable("dbo.SNS_Alarm_Action");
            DropTable("dbo.SNS_Action");
            DropTable("dbo.Settings");
            DropTable("dbo.Events");
            DropTable("dbo.SNSAlarms");
        }
    }
}
