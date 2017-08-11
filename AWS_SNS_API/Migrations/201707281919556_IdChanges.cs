namespace AWS_SNS_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SNS_Alarm_Action", "typeName_typeNameId", "dbo.SNS_Action");
            RenameColumn(table: "dbo.SNS_Alarm_Action", name: "typeName_typeNameId", newName: "typeSNSAction_typeName");
            RenameIndex(table: "dbo.SNS_Alarm_Action", name: "IX_typeName_typeNameId", newName: "IX_typeSNSAction_typeName");
            DropPrimaryKey("dbo.SNS_Action");
            AddColumn("dbo.SNS_Action", "typeName", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.SNS_Action", "typeName");
            AddForeignKey("dbo.SNS_Alarm_Action", "typeSNSAction_typeName", "dbo.SNS_Action", "typeName");
            DropColumn("dbo.SNS_Action", "typeNameId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SNS_Action", "typeNameId", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.SNS_Alarm_Action", "typeSNSAction_typeName", "dbo.SNS_Action");
            DropPrimaryKey("dbo.SNS_Action");
            DropColumn("dbo.SNS_Action", "typeName");
            AddPrimaryKey("dbo.SNS_Action", "typeNameId");
            RenameIndex(table: "dbo.SNS_Alarm_Action", name: "IX_typeSNSAction_typeName", newName: "IX_typeName_typeNameId");
            RenameColumn(table: "dbo.SNS_Alarm_Action", name: "typeSNSAction_typeName", newName: "typeName_typeNameId");
            AddForeignKey("dbo.SNS_Alarm_Action", "typeName_typeNameId", "dbo.SNS_Action", "typeNameId");
        }
    }
}
