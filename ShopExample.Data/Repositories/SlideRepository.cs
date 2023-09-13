using ShopExample.Data.Infrastructure;
using ShopExample.Model.Model;


namespace ShopExample.Data.Repositories
{

    public interface ISlideRepository : IRepository<Slide>
    {

    }

    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
