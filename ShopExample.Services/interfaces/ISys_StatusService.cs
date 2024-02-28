using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services.interfaces
{
    public interface ISys_StatusService
    {
        Task<IEnumerable<Sys_Status>> Get(int status_of);
    }
}
