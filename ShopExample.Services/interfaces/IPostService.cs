using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services.interfaces
{
    interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(Guid id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(out int totalRow, int page, int pageSize);
        Post GetByID(Guid id);
        IEnumerable<Post> GetAllTagPaging(out int totalRow, string tag, int page, int pageSize);
        IEnumerable<Post> GetAllCategoryPaging(out int totalRow, Guid categoryID, int page, int pageSize);
        void SaveChanged();

    }
}
