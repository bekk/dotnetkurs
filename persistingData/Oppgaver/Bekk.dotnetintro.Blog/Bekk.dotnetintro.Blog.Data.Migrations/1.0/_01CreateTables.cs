using FluentMigrator;

namespace Bekk.dotnetintro.Blog.Data.Migrations._1._0
{
    [Migration(1)]
    public  class _01CreateTables : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("BlogPost")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("Title").AsString().Nullable()
                .WithColumn("Content").AsString().Nullable()
                .WithColumn("Published").AsDateTime().Nullable();

            Create.Table("Comment")
                .WithColumn("Id").AsInt32().Identity()
                .WithColumn("Text").AsString().Nullable()
                .WithColumn("BlogPostId").AsInt32().ForeignKey("CommentToBlogPost", "BlogPost", "Id");
        }
    }
}
