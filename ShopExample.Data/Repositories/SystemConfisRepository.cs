using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Data.Repositories
{

    using ShopExample.Data.Infrastructure;
    using ShopExample.Model.Model;

    interface ISystemConfisRepository
    {

    }

    public class SystemConfisRepository : RepositoryBase<SystemConfig>, ISystemConfisRepository
    {
        public SystemConfisRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
