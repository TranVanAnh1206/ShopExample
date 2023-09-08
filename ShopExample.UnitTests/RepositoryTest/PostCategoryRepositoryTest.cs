using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopExample.Data.Infrastructure;
using ShopExample.Data.Repositories;
using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.UnitTests.RepositoryTest
{
    [TestClass]
    class PostCategoryRepositoryTest
    {
        IPostCategoryRepository objRepository;
        IDbFactory dbFactory;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void  Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);

        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create ()
        {
            PostCategory pc = new PostCategory();
            pc.Name = "Test category";
            pc.Alias = "Test-category";
            pc.Status = true;

            var result = objRepository.Add(pc);
            unitOfWork.Commit();

            Assert.IsNotNull(result); // kiểm tra có null hay không
            Assert.AreEqual(106352, result.ID); 
        }
    }
}
