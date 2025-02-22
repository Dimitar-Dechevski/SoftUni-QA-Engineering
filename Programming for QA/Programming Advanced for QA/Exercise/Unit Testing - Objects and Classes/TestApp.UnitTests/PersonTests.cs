using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person person;

    [SetUp]
    public void SetUp()
    {
        person = new Person();
    }

    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] people = { "Simeon TTU5 33", "Georgi CY8D 46", "Simeon TTU5 18" };
        List<Person> expected = new List<Person>();

        for (int i = 0; i < people.Length; i++)
        {
            string[] tokens = people[i].Split(" ");
            Person currentPerson = new Person();
            currentPerson.Name = tokens[0];
            currentPerson.Id = tokens[1];
            currentPerson.Age = int.Parse(tokens[2]);

            if (expected.Any(p => p.Id.Equals(currentPerson.Id)))
            {
                int index = expected.IndexOf(expected.First(p => p.Id.Equals(currentPerson.Id)));
                expected[index].Name = currentPerson.Name;
                expected[index].Age = currentPerson.Age;
            }
            else
            {
                expected.Add(currentPerson);
            }

        }

        // Act
        List<Person> actual = person.AddPeople(people);

        // Assert
        Assert.AreEqual(expected.Count, actual.Count);

        for (int i = 0; i < actual.Count; i++)
        {
            Assert.AreEqual(expected[i].Name, actual[i].Name);
            Assert.AreEqual(expected[i].Id, actual[i].Id);
            Assert.AreEqual(expected[i].Age, actual[i].Age);
        }

    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        string[] people = { "Ivan 4CXC 33", "Georgi CY8D 46", "Simeon TTU5 18" };
        List<Person> listOfPeople = person.AddPeople(people);
        string expected = $"Simeon with ID: TTU5 is 18 years old.{Environment.NewLine}" +
                          $"Ivan with ID: 4CXC is 33 years old.{Environment.NewLine}" +
                          $"Georgi with ID: CY8D is 46 years old.";

        // Act
        string actual = person.GetByAgeAscending(listOfPeople);

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
