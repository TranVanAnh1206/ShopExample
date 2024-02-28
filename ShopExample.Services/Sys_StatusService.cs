using ShopExample.Data.Infrastructure;
using ShopExample.Data.IRepositories;
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
    public class Sys_StatusService : ISys_StatusService
    {
        readonly IUnitOfWork _unitOfWork;
        readonly ISys_StatusRepository _sys_StatusRepository;

        public Sys_StatusService(IUnitOfWork unitOfWork, ISys_StatusRepository sys_StatusRepository)
        {
            _unitOfWork = unitOfWork;
            _sys_StatusRepository = sys_StatusRepository;
        }

        public async Task<IEnumerable<Sys_Status>> Get(int status_of)
        {
            return await _sys_StatusRepository.GetManyAsync(x => x.Status_Of == status_of, "");
        }
    }
}
