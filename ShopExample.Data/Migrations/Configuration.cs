namespace ShopExample.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ShopExample.Model.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopExample.Data.ShopExampleDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ShopExample.Data.ShopExampleDBContext context)
        {
            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopExampleDBContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopExampleDBContext()));

            //var user = new ApplicationUser()
            //{
            //    UserName = "TranVanAnh",
            //    Email = "anh038953@gmail.com",
            //    Birthday = DateTime.Now,
            //    Fullname = "Trần Văn Anh đẹp trai"

            //};

            //manager.Create(user, "12345$");

            //if (!roleManager.Roles.Any())
            //{
            //    roleManager.Create(new IdentityRole { Name = "Admin" });
            //    roleManager.Create(new IdentityRole { Name = "User" });
            //}

            //var adminUser = manager.FindByEmail("anh038953@gmail.com");

            //manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });

            CreateProductCategorySample(context);
        }

        private void CreateProductCategorySample(ShopExampleDBContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Điện lạnh",Alias="dien-lanh", CreatedDate=DateTime.Now, Status=true },
                    new ProductCategory() { Name="Viễn thông",Alias="vien-thong", CreatedDate=DateTime.Now, Status=true },
                    new ProductCategory() { Name="Đồ gia dụng",Alias="do-gia-dung", CreatedDate=DateTime.Now, Status=true },
                    new ProductCategory() { Name="Mỹ phẩm",Alias="my-pham", CreatedDate=DateTime.Now, Status=true }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }
    }
}
