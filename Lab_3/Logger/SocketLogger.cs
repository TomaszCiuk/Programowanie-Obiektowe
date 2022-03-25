using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Logger
{
    class SocketLogger : ILogger
    {
        private ClientSocket clientSocket;

        public SocketLogger(string host, int port)
        {
            this.clientSocket = new ClientSocket(host, port);
        }

        ~SocketLogger()
        {
            this.clientSocket.Dispose();
        }
        public void Log(params string[] messages)
        {
            string time = DateTime.Now.ToString("yyyy - MM - ddTHH:mm: ssZ");

            for (int  i=  0; i < messages.Length; i++)
            {

                string requestText = time + ": "+messages[i] +"\n";
                byte[] requestByte = Encoding.UTF8.GetBytes(requestText);

                this.clientSocket.Send(requestByte);
            }
        }
        public void Dispose()
        {
            this.clientSocket.Dispose();
        }
    }
}
