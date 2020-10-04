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
        private List<Person> childrens;
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
        public void SetMarriage(Person other)
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
        public Person Divorce()
        {
            if(this.married == null)
                throw new Exception("Person not married!");
            var other = this.married;
            other.married = null;
            this.married = null;
            return other;
        }
        public void SetChildrens(List<Person> babies, Person secondParent = null)
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
        public List<Person> GetChildrens()
        {
            List<Person> _childrens = new List<Person>();
            _childrens.AddRange(childrens);
            return _childrens;
        }
        public List<Person> GetSiblings()
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
        public List<Person> GetUnclesAndAunts()
        {
            List<Person> relatives = new List<Person>();
            if (this.father != null)
            {
                var fSibs = this.father.GetSiblings();
                relatives.AddRange(fSibs);
                foreach(var sib in fSibs)
                {
                    if (sib.married != null)
                    {
                        relatives.Add(sib.married);
                    }
                }
            }
            if (this.mother != null)
            {
                var mSibs = this.mother.GetSiblings();
                relatives.AddRange(mSibs);
                foreach(var sib in mSibs)
                {
                    if (sib.married != null)
                    {
                        relatives.Add(sib.married);
                    }
                }
            }
                

            List<Person> _relatives = relatives.Distinct().ToList();
            return _relatives;
        }
        public List<Person> GetCousins()
        {
            List<Person> cousins = new List<Person>();

            var relatives = this.GetUnclesAndAunts();
            if(relatives.Count > 0)
                foreach(var relative in relatives)
                    cousins.AddRange(relative.childrens);

            List<Person> _cousins = cousins.Distinct().ToList();
            return _cousins;
        }
        public List<Person> GetParentsInLaw()
        {
            List<Person> PIL = new List<Person>();
            if(married != null)
            {
                PIL.Add(married.father);
                PIL.Add(married.mother);
            }
            return PIL;
        }
    }
}
