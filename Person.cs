using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_familyTree
{
    public class Person
    {
        public enum genders
        {
            Male,
            Female
        }
        public String name { get; }
        public genders gender { get; }
        public int age { get; }
        public List<Person> childrens { get; private set; }
        public Person married { get; private set; }
        public Person mother { get; private set; }
        public Person father { get; private set; }

        public Person(string _name, genders _gender, int _age)
        {
            name = _name;
            gender = _gender;
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
            if (this.gender == secondParent.gender)
                throw new ArgumentException("Parents are the same gender! This class accepts only heterosexual parents (want to represent LGBT? find another way).");
            foreach (var baby in babies)
            {
                if(baby.age >= this.age)
                    throw new Exception("Childrens cannot be older than their parents!");
                if (baby == this || baby == secondParent)
                    throw new ArgumentException("Person can't be children of himself!");
                if (this.gender == genders.Male)
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
            sibs.ForEach(item => Console.WriteLine(item.name));
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
                relatives.ForEach(item => Console.WriteLine(item.name));
            else
                Console.WriteLine("No aunts or uncles :(");
        }

        private List<Person> getUnclesAndAunts()
        {
            List<Person> relatives = new List<Person>();
            if (this.father != null)
                relatives.AddRange(this.father.getSiblings());
            if (this.mother != null)
                relatives.AddRange(this.mother.getSiblings());
            List<Person> _relatives = relatives.Distinct().ToList();
            return _relatives;
        }

        private List<Person> getCousins()
        {
            List<Person> cousins = new List<Person>();

            var relatives = this.getUnclesAndAunts();
            if(relatives.Count > 0)
                foreach(var relative in relatives)
                    cousins.AddRange(relative.childrens);

            List<Person> _cousins = cousins.Distinct().ToList();
            return _cousins;
        }

        public void printCousins()
        {
            var cousins = this.getCousins();
            if(cousins.Count > 0)
                cousins.ForEach(item => Console.WriteLine(item.name));
            else
                Console.WriteLine("No cousins :(");
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
