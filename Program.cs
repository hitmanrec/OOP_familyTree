using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace OOP_familyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            bool writeToFile = false;
            List<Person> family = new List<Person>();
            family.Add(new Person("Jan Simon", Person.genders.Female, 80));//0
            family.Add(new Person("John Hamilton", Person.genders.Male, 84));
            family.Add(new Person("Abby Hamilton", Person.genders.Female, 58));//2
            family.Add(new Person("Steve Smith", Person.genders.Male, 64));
            family.Add(new Person("John Hamilton jr.", Person.genders.Male, 60));//4
            family.Add(new Person("Gabi Julian", Person.genders.Female, 58));
            family.Add(new Person("Barb Hamilton", Person.genders.Female, 55));//6
            family.Add(new Person("Dale Celebs", Person.genders.Male, 58));
            family.Add(new Person("Fae Smith", Person.genders.Female, 36));//8
            family.Add(new Person("Cami Smith", Person.genders.Female, 32));
            family.Add(new Person("Dale Marx", Person.genders.Male, 38));//10
            family.Add(new Person("Meg Hamilton", Person.genders.Female, 39));
            family.Add(new Person("Pam Celebs", Person.genders.Female, 30));//12
            family.Add(new Person("Mark Grant", Person.genders.Male, 32));
            family.Add(new Person("Alex Jones", Person.genders.Female, 33));//14
            family.Add(new Person("Mike Celebs", Person.genders.Male, 33));
            family.Add(new Person("Angie Grant", Person.genders.Female, 10));//16
            family.Add(new Person("Mary Celebs", Person.genders.Female, 12));

            family[0].SetMarriage(family[1]);
            family[0].SetChildrens(new List<Person> { family[2], family[4], family[6] }, family[1]);

            family[2].SetMarriage(family[3]);
            family[4].SetMarriage(family[5]);
            family[6].SetMarriage(family[7]);

            family[2].SetChildrens(new List<Person> { family[8], family[9] }, family[3]);
            family[4].SetChildrens(new List<Person> { family[11] }, family[5]);
            family[6].SetChildrens(new List<Person> { family[12], family[15] }, family[7]);

            family[9].SetMarriage(family[10]);
            family[12].SetMarriage(family[13]);
            family[14].SetMarriage(family[15]);

            family[12].SetChildrens(new List<Person> { family[16] }, family[13]);
            family[15].SetChildrens(new List<Person> { family[17] }, family[14]);
            IPrint printer;
            if (writeToFile)
                printer = new FilePrinter("result.txt");
            else printer = new ConsolePrinter();

            printer.WriteLine("Cousins of " + family[12].name);
            PrintCousins(family[12], printer);
            printer.WriteLine("\nParents of " + family[12].name);
            PrintParents(family[12], printer);
            printer.WriteLine("\nUncles and aunts of " + family[12].name);
            PrintUnclesAndAunts(family[12], printer);
            printer.WriteLine("\nParents in law of " + family[13].name);
            PrintParentsInLaw(family[13], printer);
            
        }

        static public void PrintCousins(Person p, IPrint printer)
        {
            var cousins = p.GetCousins();
            if (cousins.Count > 0)
                cousins.ForEach(item => printer.WriteLine(item.name));
            else
                printer.WriteLine("No cousins :(");
        }

        static public void PrintParents(Person p, IPrint printer)
        {
            if (p.father != null)
                printer.WriteLine(p.father.name);
            if (p.mother != null)
                printer.WriteLine(p.mother.name);
        }

        static public void PrintParentsInLaw(Person p, IPrint printer)
        {
            if (p.married == null)
                printer.WriteLine("Person not married.");
            else
            {
                var pil = p.GetParentsInLaw();
                pil.ForEach(item => printer.WriteLine(item.name));
            }
        }

        static public void PrintUnclesAndAunts(Person p, IPrint printer)
        {
            var relatives = p.GetUnclesAndAunts();
            if (relatives.Count > 0)
                relatives.ForEach(item => printer.WriteLine(item.name));
            else
                printer.WriteLine("No aunts or uncles :(");
        }
    }

}
