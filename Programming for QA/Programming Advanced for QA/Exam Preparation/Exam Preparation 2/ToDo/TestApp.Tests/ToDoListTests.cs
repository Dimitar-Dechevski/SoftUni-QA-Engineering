using System;

using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList toDoList = null!;

    [SetUp]
    public void SetUp()
    {
        toDoList = new ToDoList();
    }

    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        // Arrange
        string title = "Concert";
        DateTime date = new DateTime(2024, 09, 17);
        string expected = $"To-Do List:{Environment.NewLine}" +
                          $"[ ] Concert - Due: {date.ToString("MM/dd/yyyy")}";

        // Act
        toDoList.AddTask(title, date);
        string actual = toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        // Arrange
        string title = "Concert";
        DateTime date = new DateTime(2024, 09, 17);
        string expected = $"To-Do List:{Environment.NewLine}" +
                          $"[✓] Concert - Due: {date.ToString("MM/dd/yyyy")}";

        // Act
        toDoList.AddTask(title, date);
        toDoList.CompleteTask(title);
        string actual = toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        // Arrange
        string title = "Concert";
        DateTime date = new DateTime(2024, 09, 17);

        // Act
        toDoList.AddTask(title, date);

        // Assert
        Assert.Throws<ArgumentException>(() => toDoList.CompleteTask("Test"));
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        // Arrange
        string expected = $"To-Do List:";

        // Act
        string actual = toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        // Arrange
        string firstTitle = "Concert";
        DateTime firstDate = new DateTime(2024, 09, 17);
        string secondTitle = "Opera";
        DateTime secondDate = new DateTime(2024, 11, 28);
        string expected = $"To-Do List:{Environment.NewLine}" +
                          $"[✓] Concert - Due: {firstDate.ToString("MM/dd/yyyy")}{Environment.NewLine}" +
                          $"[ ] Opera - Due: {secondDate.ToString("MM/dd/yyyy")}";

        // Act
        toDoList.AddTask(firstTitle, firstDate);
        toDoList.AddTask(secondTitle, secondDate);
        toDoList.CompleteTask(firstTitle);
        string actual = toDoList.DisplayTasks();

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
