using ConsoleApp1.Models;

namespace ConsoleApp1.Extensions;

public static class PersonCollectionExtensionMethods
{
    public static Person OldestPerson(this List<Person> persons)
    {
        var oldPerson = persons[0];
        foreach (var person in persons)
        {
            if (oldPerson.Age < person.Age)
            {
                oldPerson = person;
            }
        }

        return oldPerson;
    }
}
