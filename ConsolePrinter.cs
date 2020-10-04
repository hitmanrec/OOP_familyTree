using System;

namespace OOP_familyTree
{
    public class ConsolePrinter : IPrint
    {
        public void PrintCousins(Person p)
        {
            var cousins = p.GetCousins();
            if (cousins.Count > 0)
                cousins.ForEach(item => Console.WriteLine(item.name));
            else
                Console.WriteLine("No cousins :(");
        }

        public void PrintParents(Person p)
        {
            if (p.father != null)
                Console.WriteLine(p.father.name);
            if (p.mother != null)
                Console.WriteLine(p.mother.name);
        }

        public void PrintParentsInLaw(Person p)
        {
            if (p.married == null)
                Console.WriteLine("Person not married.");
            else
            {
                var pil = p.GetParentsInLaw();
                pil.ForEach(item => Console.WriteLine(item.name));
            }
        }

        public void PrintUnclesAndAunts(Person p)
        {
            var relatives = p.GetUnclesAndAunts();
            if (relatives.Count > 0)
                relatives.ForEach(item => Console.WriteLine(item.name));
            else
                Console.WriteLine("No aunts or uncles :(");
        }
    }

}
