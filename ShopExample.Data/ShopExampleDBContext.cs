using Microsoft.AspNet.Identity.EntityFramework;
using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Data
{
    public class ShopExampleDBContext : IdentityDbContext<ApplicationUser>
    {
        public ShopExampleDBContext() : base("ShopExampleConnection")
        {
            // khi chúng ta load một bẳng cha thì không tự động include thêm bảng con
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Footer> Footers { get; set; }
        public DbSet<Sys_Status> Sys_Statuses { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductsDetail { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<SupportOnline> SupportOnlines { get; set; }
        public DbSet<SystemConfig> SystemConfigs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<VisitorStatistic> VisitorStatistics { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Error> Errors { get; set; }

        public static ShopExampleDBContext Create()
        {
            return new ShopExampleDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId });
            modelBuilder.Entity<IdentityUserLogin>().HasKey(i => i.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
