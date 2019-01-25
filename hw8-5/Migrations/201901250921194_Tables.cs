namespace hw8_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tables",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        group_id = c.Int(nullable: false),
                        descr = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tables");
        }
    }
}
