namespace NLayerMovie.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CommentImages",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        contentLength = c.Int(nullable: false),
                        contentType = c.String(),
                        fileName = c.String(),
                        data = c.Binary(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Comments", t => t.ID)
                .Index(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CommentImages", "ID", "dbo.Comments");
            DropIndex("dbo.CommentImages", new[] { "ID" });
            DropTable("dbo.CommentImages");
        }
    }
}
