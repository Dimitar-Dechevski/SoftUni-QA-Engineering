using PersonInfo;

using System;
using System.Collections.Generic;
using System.Linq;

int n = int.Parse(Console.ReadLine()!);
List<Person> persons = new List<Person>();

for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(" ");
    string firstName = tokens[0];
    string lastName = tokens[1];
    int age = int.Parse(tokens[2]);
    Person person = new(firstName, lastName, age);
    persons.Add(person);
}

persons = persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList();

foreach (Person person in persons)
{
    Console.WriteLine(person.ToString());
}

