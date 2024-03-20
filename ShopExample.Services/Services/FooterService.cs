using ShopExample.Common.Common;
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
    

    public class FooterService : IFooterService
    {
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;

        public FooterService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.MainFooterID);
        }
    }
}
