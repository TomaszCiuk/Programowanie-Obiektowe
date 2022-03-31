using System;
using Lab_3.Logger;

namespace Lab_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger[] loggers = new ILogger[]
            {
                new ConsoleLogger(),
                new FileLogger("log.txt"),
                new SocketLogger("google.com", 80)
            };

            loggers[0].Log("Example ")

            using (ILogger logger = new CommonLogger(loggers))
            {
                logger.Log("Example message 1 ...");
                logger.Log("Example message 2 ...");
                logger.Log("Example message 3 ...", "value 1", "value 2", "value 3");
            }
        }
    }
}
