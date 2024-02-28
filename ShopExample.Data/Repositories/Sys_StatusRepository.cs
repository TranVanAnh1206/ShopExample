using ShopExample.Data.Infrastructure;
using ShopExample.Data.IRepositories;
using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Data.Repositories
{
    public class Sys_StatusRepository : RepositoryBase<Sys_Status>, ISys_StatusRepository
    {
        public Sys_StatusRepository(IDbFactory bFactory) : base(bFactory)
        {

        }
    }
}
