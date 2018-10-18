namespace NLayerMovie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUpvote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Upvotes",
                c => new
                    {
                        UpvoteID = c.Int(nullable: false, identity: true),
                        CommentID = c.Int(nullable: false),
                        UserID = c.String(maxLength: 128),
                        Created = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UpvoteID)
                .ForeignKey("dbo.Comments", t => t.CommentID, cascadeDelete: true)
                .ForeignKey("dbo.ClientProfiles", t => t.UserID)
                .Index(t => t.CommentID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Comments", "Upvote_count", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Upvotes", "UserID", "dbo.ClientProfiles");
            DropForeignKey("dbo.Upvotes", "CommentID", "dbo.Comments");
            DropIndex("dbo.Upvotes", new[] { "UserID" });
            DropIndex("dbo.Upvotes", new[] { "CommentID" });
            DropColumn("dbo.Comments", "Upvote_count");
            DropTable("dbo.Upvotes");
        }
    }
}
