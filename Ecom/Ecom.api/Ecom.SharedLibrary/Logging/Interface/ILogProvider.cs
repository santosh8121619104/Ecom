using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.SharedLibrary.Logging.Interface
{
    public interface ILogProvider
    {
        void LogError(string error, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null); // 0 is Error
        void LogError(Exception exception, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null); // 0 is Error
        void LogWarning(string warning, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null); // 1 is Warning
        void LogInformation(string information, string correlationId = "", string userName = "", IDictionary<string, string> extraProperty = null); // 2 is Information
        void Flush();
    }
}
