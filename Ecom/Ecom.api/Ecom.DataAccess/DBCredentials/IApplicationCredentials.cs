using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.DBCredentials
{
    public interface IApplicationCredentials
    {
        Task SetAppDomain();
        string GetEfConnection();
    }
}
