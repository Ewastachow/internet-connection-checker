using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace InternetConnectionChecker
{
    class FileManager
    {
        public string Path { get; set; }

        public FileManager()
        {
            Path = "C://";
        }

        public FileManager(string path)
        {
            this.Path = path;
        }
        
        public void GenerateStatus(string ipAddress)
        {
            string newLine = DiagnozeWeb.PingResultString(ipAddress);
            File.AppendAllText(Path, newLine);
        }

        public void GenerateStatus(List<string> ipAddressList)
        {
            foreach(string ipAddress in ipAddressList)
                GenerateStatus(ipAddress);
        }
        
    }
}
