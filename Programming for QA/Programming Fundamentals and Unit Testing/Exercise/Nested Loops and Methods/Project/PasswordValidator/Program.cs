namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool isValid = CheckPasswordIsValid(password);

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }

        }

        static bool CheckPasswordIsValid(string password)
        {
            bool isValid = true;

            if (!CheckPasswordLength(password))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                isValid = false;
            }
            if (!CheckPasswordContainsOnlyLettersAndDigits(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;
            }
            if (!CheckPasswordContainsEnoughDigits(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            return isValid;
        }

        static bool CheckPasswordLength(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }

            return true;
        }

        static bool CheckPasswordContainsOnlyLettersAndDigits(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];

                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        static bool CheckPasswordContainsEnoughDigits(string password)
        {
            int digitCounter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];

                if (char.IsDigit(symbol))
                {
                    digitCounter++;
                }
            }

            if (digitCounter < 2)
            {
                return false;
            }

            return true;
        }

    }
}

