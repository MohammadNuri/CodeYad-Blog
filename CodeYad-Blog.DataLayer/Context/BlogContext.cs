using CodeYad_Blog.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeYad_Blog.DataLayer.Context
{
    public class BlogContext : DbContext
    {
        //this is the setting of DbContext Option (Setting For Database Class)
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }
        //these are the tables ((Entities Class that we Made Before) (will create the tables that we need in SQL Server))
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostComment> PostComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
