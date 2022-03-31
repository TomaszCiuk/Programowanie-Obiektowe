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
            string time = DateTime.Now.ToString("yyyy - MM - ddTHH:mm: ssZ");

            for (int i = 0; i < messages.Length; i++)
            {

                
            }
        }
    }
}
