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
    public interface IErrorService
    {
        Error Created(Error error);
        void SaveChanged();
        void SaveChangedAsync();
    }

    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Created(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void SaveChanged()
        {
            _unitOfWork.Commit();
        }

        public void SaveChangedAsync()
        {
            _unitOfWork.Commit();
        }
    }
}
