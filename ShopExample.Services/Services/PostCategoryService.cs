using ShopExample.Data.Infrastructure;
using ShopExample.Data.Repositories;
using ShopExample.Model.Model;
using ShopExample.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services
{
    public class PostCategoryService : IPostCategoryService
    {
        IPostCategoryRepository _postCategoryRepository;
        IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory pc)
        {
            return _postCategoryRepository.Add(pc);
        }

        public PostCategory Delete(Guid id)
        {
            return _postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(Guid parentId)
        {
            return _postCategoryRepository.GetMulti(x => x.Status == 1 && x.ParentID == parentId);
        }

        public PostCategory GetById(Guid id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public void Update(PostCategory pc)
        {
            _postCategoryRepository.Update(pc);
        }
    }
}
