﻿namespace GuessThePassword
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (password.Equals("s3cr3t!"))
            {    
                Console.WriteLine("Welcome");
            } 
            else 
            {    
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
