using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services.interfaces
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory pc);
        PostCategory Delete(Guid id);
        void Update(PostCategory pc);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllByParentId(Guid parentId);
        PostCategory GetById(Guid id);
        void SaveChanged();
    }
}
