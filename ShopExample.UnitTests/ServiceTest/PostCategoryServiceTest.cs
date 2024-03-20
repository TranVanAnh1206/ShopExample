using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopExample.Data.Infrastructure;
using ShopExample.Data.Repositories;
using ShopExample.Model.Model;
using ShopExample.Services;
using ShopExample.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.UnitTests.ServiceTest
{
    [TestClass]
    class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _postCategoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _postCategoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory() {ID =Guid.NewGuid() ,Name="DM1",Status=1 },
                new PostCategory() {ID =Guid.NewGuid() ,Name="DM2",Status=1 },
                new PostCategory() {ID =Guid.NewGuid() ,Name="DM3",Status=1 },
            };
        }


        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //call action
            var result = _postCategoryService.GetAll() as List<PostCategory>;

            //compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test";
            category.Alias = "test";
            category.Status = 1;

            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
            {
                p.ID = Guid.NewGuid();
                return p;
            });

            var result = _postCategoryService.Add(category);

            Assert.IsNotNull(result);
            Assert.AreEqual(Guid.NewGuid(), result.ID);
        }

    }
}
