namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mymig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPwd = c.String(),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emps", t => t.EmpsId, cascadeDelete: true)
                .Index(t => t.EmpsId);
            
            CreateTable(
                "dbo.Emps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentsId = c.Int(nullable: false),
                        Ename = c.String(),
                        Esex = c.String(),
                        Papersnum = c.String(),
                        Ephone = c.String(),
                        Eduty = c.String(),
                        Email = c.String(),
                        Tracttype = c.String(),
                        Etype = c.String(),
                        ERemark = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentsId, cascadeDelete: true)
                .Index(t => t.DepartmentsId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BName = c.String(),
                        Bremark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dimissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpsId = c.Int(nullable: false),
                        LeaveType = c.String(),
                        Yleavedate = c.String(),
                        Xsettledate = c.String(),
                        Remark = c.String(),
                        Applydate = c.String(),
                        LeaveReason = c.String(),
                        Lastworkdate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emps", t => t.EmpsId, cascadeDelete: true)
                .Index(t => t.EmpsId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PermissionName = c.String(),
                        pid = c.Int(nullable: false),
                        Permission = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Paymessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpsId = c.Int(nullable: false),
                        Papersnum = c.String(),
                        Entrydate = c.String(),
                        TryMoney = c.Double(nullable: false),
                        RegularMoney = c.Double(nullable: false),
                        PresentMoney = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emps", t => t.EmpsId, cascadeDelete: true)
                .Index(t => t.EmpsId);
            
            CreateTable(
                "dbo.Punchcards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpsId = c.Int(nullable: false),
                        Signindate = c.String(),
                        Signoutdate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emps", t => t.EmpsId, cascadeDelete: true)
                .Index(t => t.EmpsId);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ename = c.String(),
                        Transfertype = c.String(),
                        Transferdate = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpsId = c.Int(nullable: false),
                        Name = c.String(),
                        Cause = c.String(),
                        Remark = c.String(),
                        VacateState = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emps", t => t.EmpsId, cascadeDelete: true)
                .Index(t => t.EmpsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacates", "EmpsId", "dbo.Emps");
            DropForeignKey("dbo.Punchcards", "EmpsId", "dbo.Emps");
            DropForeignKey("dbo.Paymessages", "EmpsId", "dbo.Emps");
            DropForeignKey("dbo.Dimissions", "EmpsId", "dbo.Emps");
            DropForeignKey("dbo.Attendances", "EmpsId", "dbo.Emps");
            DropForeignKey("dbo.Emps", "DepartmentsId", "dbo.Departments");
            DropIndex("dbo.Vacates", new[] { "EmpsId" });
            DropIndex("dbo.Punchcards", new[] { "EmpsId" });
            DropIndex("dbo.Paymessages", new[] { "EmpsId" });
            DropIndex("dbo.Dimissions", new[] { "EmpsId" });
            DropIndex("dbo.Emps", new[] { "DepartmentsId" });
            DropIndex("dbo.Attendances", new[] { "EmpsId" });
            DropTable("dbo.Vacates");
            DropTable("dbo.Transfers");
            DropTable("dbo.Punchcards");
            DropTable("dbo.Paymessages");
            DropTable("dbo.Menus");
            DropTable("dbo.Dimissions");
            DropTable("dbo.Departments");
            DropTable("dbo.Emps");
            DropTable("dbo.Attendances");
            DropTable("dbo.Admins");
        }
    }
}
