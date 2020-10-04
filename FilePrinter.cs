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
        public void PrintCousins(Person p)
        {
            var cousins = p.GetCousins();
            if (cousins.Count > 0)
                cousins.ForEach(item => sw.WriteLine(item.name));
            else
                sw.WriteLine("No cousins :(");
        }

        public void PrintParents(Person p)
        {
            if (p.father != null)
                sw.WriteLine(p.father.name);
            if (p.mother != null)
                sw.WriteLine(p.mother.name);
        }

        public void PrintParentsInLaw(Person p)
        {
            if (p.married == null)
                sw.WriteLine("Person not married.");
            else
            {
                var pil = p.GetParentsInLaw();
                pil.ForEach(item => sw.WriteLine(item.name));
            }
        }

        public void PrintUnclesAndAunts(Person p)
        {
            var relatives = p.GetUnclesAndAunts();
            if (relatives.Count > 0)
                relatives.ForEach(item => sw.WriteLine(item.name));
            else
                sw.WriteLine("No aunts or uncles :(");
        }
    }

}
