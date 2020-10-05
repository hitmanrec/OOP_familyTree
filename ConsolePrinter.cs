using System;

namespace OOP_familyTree
{
    public class ConsolePrinter : IPrint
    {
        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }

        public void Write(string s)
        {
            Console.Write(s);
        }
    }

}
