namespace ShopExample.Data.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
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
            CreateProductCategorySample(context);
            CreateProductSample(context);
            CreateFooterSample(context);
            CreateStatusSample(context);
            CreateBrandSample(context);

            //var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ShopExampleDBContext()));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ShopExampleDBContext()));
            //var user = new ApplicationUser()
            //{
            //    UserName = "TranVanAnh",
            //    Address = "Định Tân - Yên Định - Thanh Hóa",
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
        }

        private void CreateBrandSample(ShopExampleDBContext context)
        {
            if (context.Brands.Count() == 0)
            {
                List<Brand> brands = new List<Brand>
        {
            new Brand() { ID = Guid.NewGuid(), Name = "Canifa", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Loire", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Cocosin", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Gumac", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Bom sister", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Ivy moda", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Just bra", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Sunfly", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Jody", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Vingo", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "Elise", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
            new Brand() { ID = Guid.NewGuid(), Name = "EVA DE EVA", CreatedBy = "TranVanAnh", CreatedDate = DateTime.Now, Status = 1 },
        };
            }
        }

        private void CreateFooterSample(ShopExampleDBContext context)
        {
            if (context.Footers.Count(x => x.ID == "footerTop1") == 0)
            {
                Footer footer = new Footer()
                {
                    ID = "footerTop1",
                    Name = "FooterTop1",
                    Contents = "",
                };

                context.Footers.Add(footer);
                context.SaveChanges();
            }
        }

        private void CreateProductCategorySample(ShopExampleDBContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
        {
            new ProductCategory() {ID = Guid.NewGuid(), Name="Thời trang nam",Alias="thoi-trang-nam", CreatedDate=DateTime.Now, Status=1 },
            new ProductCategory() {ID = Guid.NewGuid(), Name="Thời trang mẹ và bé",Alias="thoi-trang-me-va-be", CreatedDate=DateTime.Now, Status=1 },
            new ProductCategory() {ID = Guid.NewGuid(), Name="Giày dép nữ",Alias="giay-dep-nu", CreatedDate=DateTime.Now, Status=1 },
            new ProductCategory() {ID = Guid.NewGuid(), Name="Giày dép nam",Alias="giay-dep-nam", CreatedDate=DateTime.Now, Status=1 },
            new ProductCategory() {ID = Guid.NewGuid(), Name="Túi ví nư",Alias="tui-vi-nu", CreatedDate=DateTime.Now, Status=1 }
        };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }

        }

        private void CreateProductSample(ShopExampleDBContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> listProd = new List<Product>()
        {
            new Product() {ID = Guid.NewGuid(),
                Name="IPhone 15 Pro Max 258GB",
                Alias="IPhone15, Apple, IPhone",
                Price=35990000,
                Quantity=165,
                CreatedDate=DateTime.Now,
                CreatedBy="TranVanAnh - Admin", },
            new Product() {ID = Guid.NewGuid(),
                Name="Samsung galaxy",
                Alias="samsung-galaxy, samsung",
                Price=2990000,
                Quantity=15,
                CreatedDate=DateTime.Now,
                CreatedBy="TranVanAnh - Admin", },
            new Product() {ID = Guid.NewGuid(),
                Name="TV OSny",
                Alias="TV, Sony, TVSony",
                Price=12990000,
                Quantity=165,
                CreatedDate=DateTime.Now,
                CreatedBy="TranVanAnh - Admin", },
        };
                context.Products.AddRange(listProd);
                context.SaveChanges();
            }

        }

        private void CreateStatusSample(ShopExampleDBContext context)
        {
            if (context.Sys_Statuses.Count() == 0)
            {
                List<Sys_Status> sys_Statuses = new List<Sys_Status>()
        {
            new Sys_Status { ID = 1, Name = "Sử dụng", Status_Of = 1, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 2, Name = "Không sử dụng", Status_Of = 1,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 3, Name = "Chờ duyệt", Status_Of = 1, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 0, Name = "Nháp", Status_Of = 1,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },

            new Sys_Status { ID = 11, Name = "Chưa giao", Status_Of = 2, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 12, Name = "Đang giao", Status_Of = 2,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 13, Name = "Đã giao", Status_Of = 2, CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 10, Name = "Hủy đơn", Status_Of = 2,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
            new Sys_Status { ID = 14, Name = "Chờ xác nhận", Status_Of = 2,  CreatedBy = "Admin", CreatedDate = DateTime.Now, ModifiedBy = "Admin", ModifiedDate = DateTime.Now, Status = 1 },
        };

                context.Sys_Statuses.AddRange(sys_Statuses);
                context.SaveChanges();
            }
        }
    }
}
