using ShopExample.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopExample.Services.interfaces
{
    public interface IErrorService
    {
        Error Created(Error error);
        void SaveChanged();
        void SaveChangedAsync();
    }
}
