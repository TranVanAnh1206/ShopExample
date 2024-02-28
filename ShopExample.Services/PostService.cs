using ShopExample.Data.Infrastructure;
using ShopExample.Data.Repositories;
using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services
{
    interface IPosrService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(Guid id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(out int totalRow, int page, int pageSize );
        Post GetByID(Guid id);
        IEnumerable<Post> GetAllTagPaging(out int totalRow, string tag, int page, int pageSize );
        IEnumerable<Post> GetAllCategoryPaging(out int totalRow, Guid categoryID, int page, int pageSize );
        void SaveChanged();

    }

    public class PostService : IPosrService
    {
        IPostRepository _postRepository;
        IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Delete(Guid id)
        {
            _postRepository.Delete(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllCategoryPaging(out int totalRow, Guid categoryID, int page, int pageSize)
        {
            return _postRepository.GetMultiPaging(x => x.Status == 1 && x.CategoryID == categoryID, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> GetAllPaging(out int totalRow, int page, int pageSize )
        {
            return _postRepository.GetMultiPaging(x => x.Status == 1, out totalRow, page, pageSize);
        }

        public IEnumerable<Post> GetAllTagPaging(out int totalRow, string tag, int page, int pageSize )
        {
            return _postRepository.GetMultiPaging(x => x.Status == 1, out totalRow, page, pageSize);
        }

        public Post GetByID(Guid id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();   
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }
    }
}
