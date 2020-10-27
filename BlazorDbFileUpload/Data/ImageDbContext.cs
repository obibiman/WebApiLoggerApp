using Microsoft.EntityFrameworkCore;

namespace BlazorDbFileUpload.Data
{
    public class ImageDbContext : DbContext
    {
        public ImageDbContext(DbContextOptions<ImageDbContext> options) : base(options)
        { }

        public DbSet<ImgClass> ImgClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ImgClass>()
            //    .Property(p => p.Imgname)
            //    .IsRequired()
            //    .HasMaxLength(100);
        }
    }
}