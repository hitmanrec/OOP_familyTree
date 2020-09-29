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
            List<Person> family = new List<Person>();
            family.Add(new Person("Jan Simon", "Female", 80));//0
            family.Add(new Person("John Hamilton", "Male", 84));
            family.Add(new Person("Abby Hamilton", "Female", 58));//2
            family.Add(new Person("Steve Smith", "Male", 64));
            family.Add(new Person("John Hamilton jr.", "Male", 60));//4
            family.Add(new Person("Gabi Julian", "Female", 58));
            family.Add(new Person("Barb Hamilton", "Female", 55));//6
            family.Add(new Person("Dale Celebs", "Male", 58));
            family.Add(new Person("Fae Smith", "Female", 36));//8
            family.Add(new Person("Cami Smith", "Female", 32));
            family.Add(new Person("Dale Marx", "Male", 38));//10
            family.Add(new Person("Meg Hamilton", "Female", 39));
            family.Add(new Person("Pam Celebs", "Female", 30));//12
            family.Add(new Person("Mark Grant", "Male", 32));
            family.Add(new Person("Alex Jones", "Female", 33));//14
            family.Add(new Person("Mike Celebs", "Male", 33));
            family.Add(new Person("Angie Grant", "Female", 10));//16
            family.Add(new Person("Mary Celebs", "Female", 12));

            family[0].setMarriage(family[1]);
            family[0].setChildrens(new List<Person> { family[2], family[4], family[6] }, family[1]);

            family[2].setMarriage(family[3]);
            family[4].setMarriage(family[5]);
            family[6].setMarriage(family[7]);

            family[2].setChildrens(new List<Person> { family[8], family[9] }, family[3]);
            family[4].setChildrens(new List<Person> { family[11] }, family[5]);
            family[6].setChildrens(new List<Person> { family[12], family[15] }, family[7]);

            family[9].setMarriage(family[10]);
            family[12].setMarriage(family[13]);
            family[14].setMarriage(family[15]);

            family[12].setChildrens(new List<Person> { family[16] }, family[13]);
            family[15].setChildrens(new List<Person> { family[17] }, family[14]);

            Console.WriteLine("Cousins of " + family[12].name);
            family[12].printCousins();
            Console.WriteLine("Parents of " + family[12].name);
            family[12].printParents();
            Console.WriteLine("Uncles and aunts of " + family[12].name);
            family[12].printUnclesAndAunts();
            Console.WriteLine("Parents in law of " + family[13].name);
            family[13].printParentsInLaw();
        }
    }
}
