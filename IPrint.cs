namespace OOP_familyTree
{
    public interface IPrint
    {
        void PrintParents(Person p);
        void PrintUnclesAndAunts(Person p);
        void PrintCousins(Person p);
        void PrintParentsInLaw(Person p);
    }

}
