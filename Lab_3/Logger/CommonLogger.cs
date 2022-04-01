using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Logger
{
    class CommonLogger : ILogger
    {
        ILogger[] loggers;

        public CommonLogger(ILogger[] loggers)
        {
            this.loggers = loggers;
        }

        public void Dispose()
        {
        }
        public void Log(params string[] messages)
        {
            for (int i = 0; i < this.loggers.Length; i++)
            {
                this.loggers[i].Log(messages);
            }
        }
    }
}
