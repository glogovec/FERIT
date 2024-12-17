using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TvSeriesLibrary
{
    public class FilePrinter: IPrinter
    {
        string filePath;

        public FilePrinter(string filePath)
        {
            this.filePath = filePath;
        }

        public void Print(string message)
        {
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
