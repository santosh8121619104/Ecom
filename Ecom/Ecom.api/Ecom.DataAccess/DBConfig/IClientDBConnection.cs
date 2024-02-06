using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.DBConfig
{
    public interface IClientDBConnection
    {
        void SetEfDBString(string EfDBString);
        string getEfDBString();
    }
}
