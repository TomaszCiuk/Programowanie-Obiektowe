using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Logger
{
    class FileLogger : WriterLogger
    {
        private bool disposed;
        protected FileStream stream;

        public FileLogger(string path)
        {
            this.stream = new FileStream(path, FileMode.Append);
            this.writer = new StreamWriter(stream, Encoding.UTF8);
        }
        ~FileLogger()
            {
            this.stream.Dispose();
        }
        public override void Dispose()
        {
            this.writer.Dispose();
            this.stream.Dispose();
        }
    }
}
