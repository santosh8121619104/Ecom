using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.DataAccess.DBConfig
{
    public class ClientDBConnection:IClientDBConnection
    {
        public string EfDBString {  get; private set; }

        public void SetEfDBString(string EfDBString)
        {
            this.EfDBString = EfDBString;
        }

        public string getEfDBString()
        {
            return this.EfDBString;
        }
    }
}
