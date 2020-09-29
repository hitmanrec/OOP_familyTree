using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_familyTree
{
    public class Person
    {
        public String name, sex;
        public int age;
        public List<Person> childrens;
        public Person married, mother, father;

        public Person(string _name, string _sex, int _age)
        {
            name = _name;
            if(_sex != "Male" && _sex != "Female")
                throw new ArgumentException("Person's sex has to be Male or Female!");
            sex = _sex;
            if(_age <= 0 || _age > 150)
                throw new ArgumentException("Person's age cannot be less than zero or greater than 150 years (people can't live for so long nowadays)!");
            age = _age;
            childrens = new List<Person>();
        }

        public void setMarriage(Person other)
        {
            if(this.married != null || other.married != null)
                throw new ArgumentException("Person already married!");
            if(this == other)
                throw new ArgumentException("Person can't marry himself!");
            else
            {
                this.married = other;
                other.married = this;
            }
        }
        public Person divorce()
        {
            if(this.married == null)
                throw new Exception("Person not married!");
            var other = this.married;
            other.married = null;
            this.married = null;
            return other;
        }
        public void setChildrens(List<Person> babies, Person secondParent = null)
        {
            if (this.sex == secondParent.sex)
                throw new ArgumentException("Parents are have the same sex! This class accepts only heterosexual parents (want to represent LGBT? find another way).");
            foreach (var baby in babies)
            {
                if(baby.age >= this.age)
                    throw new Exception("Childrens cannot be older than their parents!");
                if (baby == this || baby == secondParent)
                    throw new ArgumentException("Person can't be children of himself!");
                if (this.sex == "Male")
                {
                    baby.father = this;
                    if (secondParent != null)
                        baby.mother = secondParent;
                }
                else
                {
                    baby.mother = this;
                    if (secondParent != null)
                        baby.father = secondParent;
                }
                this.childrens.Add(baby);
            }
        }
        public void printParents()
        {
            if (this.father != null)
                Console.WriteLine(father.name);
            if (this.mother != null)
                Console.WriteLine(mother.name);
        }
        public void printSiblings()
        {
            var sibs = this.getSiblings();
            if(sibs.Count > 0)
            foreach(var sib in sibs)
                Console.WriteLine(sib.name);
            else
                Console.WriteLine("No siblings :(");
        }
        private List<Person> getSiblings()
        {
            List<Person> siblings = new List<Person>();
            if (this.father != null)
                foreach (var sibling in this.father.childrens)
                    if (sibling != this)
                        siblings.Add(sibling);
            if (this.mother != null)
                foreach (var sibling in this.mother.childrens)
                    if (sibling != this)
                        siblings.Add(sibling);
            List<Person> _siblings = siblings.Distinct().ToList();
            return _siblings;
        }
        public void printUnclesAndAunts()
        {
            var relatives = this.getUnclesAndAunts();
            if(relatives.Count > 0)
                foreach(var relative in relatives)
                    Console.WriteLine(relative.name);
            else
                Console.WriteLine("No aunts or uncles :(");
        }

        private List<Person> getUnclesAndAunts()
        {
            List<Person> relatives = new List<Person>();
            if (this.father != null)
            {
                var sibF = this.father.getSiblings();
                if(sibF.Count > 0)
                foreach (var relative in sibF)
                        relatives.Add(relative);
            }
            if (this.mother != null)
            {
                var sibM = this.mother.getSiblings();
                if(sibM.Count > 0)
                foreach (var relative in sibM)
                    relatives.Add(relative);
            }
            List<Person> _relatives = relatives.Distinct().ToList();
            return _relatives;
        }

        private List<Person> getCousins()
        {
            List<Person> cousins = new List<Person>();

            var relatives = this.getUnclesAndAunts();
            if(relatives.Count > 0)
                foreach(var relative in relatives)
                    foreach(var baby in relative.childrens)
                        cousins.Add(baby);

            List<Person> _cousins = cousins.Distinct().ToList();
            return _cousins;
        }

        public void printCousins()
        {
            var cousins = this.getCousins();
            if(cousins.Count > 0)
            foreach(var cousin in cousins)
            {
                Console.WriteLine(cousin.name);
            }
            else
            {
                Console.WriteLine("No cousins :(");
            }
        }

        public void printParentsInLaw()
        {
            if (this.married == null)
                Console.WriteLine("Person not married.");
            else
            {
                if (this.married.father != null)
                    Console.WriteLine(this.married.father.name);
                if (this.married.mother != null)
                    Console.WriteLine(this.married.mother.name);
            }
        }
    }
}
