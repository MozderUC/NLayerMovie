namespace NLayerMovie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addComments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentEntities",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        userID = c.String(maxLength: 128),
                        entityID = c.Int(nullable: false),
                        entityType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.ID)
                .ForeignKey("dbo.ClientProfiles", t => t.userID)
                .Index(t => t.ID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        context = c.String(),
                        parent = c.Int(),
                        created = c.DateTime(nullable: false),
                        modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentEntities", "userID", "dbo.ClientProfiles");
            DropForeignKey("dbo.CommentEntities", "ID", "dbo.Comments");
            DropIndex("dbo.CommentEntities", new[] { "userID" });
            DropIndex("dbo.CommentEntities", new[] { "ID" });
            DropTable("dbo.Comments");
            DropTable("dbo.CommentEntities");
        }
    }
}
