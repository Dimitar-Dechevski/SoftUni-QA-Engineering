using NUnit.Framework;
using System;

namespace TestApp.Tests;

[TestFixture]
public class BankAccountTests
{
    [Test]
    public void Test_Constructor_InitialBalanceIsSet()
    {
        // Arrange
        double balance = 250;
        double expected = 250;

        // Act
        BankAccount actual = new BankAccount(balance);

        // Assert
        Assert.AreEqual(expected, actual.Balance);
    }

    [Test]
    public void Test_Deposit_PositiveAmount_IncreasesBalance()
    {
        // Arrange
        double balance = 250;
        double amount = 150;
        double expected = 400;

        // Act
        BankAccount actual = new BankAccount(balance);
        actual.Deposit(amount);

        // Assert
        Assert.AreEqual(expected, actual.Balance);
    }

    [Test]
    public void Test_Deposit_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double balance = 250;
        double amount = -150;

        // Act
        BankAccount actual = new BankAccount(balance);

        // Assert
        Assert.Throws<ArgumentException>(() => actual.Deposit(amount));
    }

    [Test]
    public void Test_Withdraw_ValidAmount_DecreasesBalance()
    {
        // Arrange
        double balance = 250;
        double amount = 150;
        double expected = 100;

        // Act
        BankAccount actual = new BankAccount(balance);
        actual.Withdraw(amount);

        // Assert
        Assert.AreEqual(expected, actual.Balance);
    }

    [Test]
    public void Test_Withdraw_NegativeAmount_ThrowsArgumentException()
    {
        // Arrange
        double balance = 250;
        double amount = -150;

        // Act
        BankAccount actual = new BankAccount(balance);

        // Assert
        Assert.Throws<ArgumentException>(() => actual.Withdraw(amount));
    }

    [Test]
    public void Test_Withdraw_AmountGreaterThanBalance_ThrowsArgumentException()
    {
        // Arrange
        double balance = 250;
        double amount = 300;

        // Act
        BankAccount actual = new BankAccount(balance);

        // Assert
        Assert.Throws<ArgumentException>(() => actual.Withdraw(amount));
    }
}
