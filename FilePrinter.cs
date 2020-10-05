using System.IO;

namespace OOP_familyTree
{
    public class FilePrinter : IPrint
    {
        private StreamWriter sw;
        public FilePrinter(string fileName)
        {
            sw = new StreamWriter(fileName);
        }
        public void WriteLine(string s)
        {
            sw.WriteLine(s);
        }

        public void Write(string s)
        {
            sw.Write(s);
        }
    }
}

