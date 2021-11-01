using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NgStore.Framework.Logs
{
    public interface ILoggerService : IDisposable
    {
        public void Info(string info);
        public void Warning(string warn);
        public void Debug(string debug);
        public void Error(string error);
    }
}
