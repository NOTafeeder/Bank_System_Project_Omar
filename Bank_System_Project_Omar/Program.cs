namespace Bank_System_Project_Omar
{
     class Program
     {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello and welcome to the bank system! ");
            string[] userNames = { 
                "Omar", 
                "John", 
                "Micheal", 
                "Frank", 
                "Adam" };
            int[] PIN = { 
                1234, 
                4567, 
                8900, 
                4242, 
                3231 };
            string[,] accountTypes = {
                { "Lönekonto", "Sparkonto", "" },
                { "Lönekonto", "Sparkonto", "" },
                { "Sparkonto", "", "" },
                { "Lönekonto", "", "" },
                { "Lönekonto", "Sparkonto", "Resekonto" }
            };
            decimal[,] balances = {
                {4500m, 3240m, 0m},
                {12700m, 32300m, 0m},
                {0m, 19000m, 0m},
                {30000m, 0m, 0m},
                {1400m, 23000m, 40000m},
            };
            int[] accountCounts = { 
                2, 
                2, 
                1, 
                1, 
                3 
            };
            int loggedInUserIndex = login(userNames, PIN);
            if (loggedInUserIndex != -1) // Check if the login was successful
            {
                ShowMenu(loggedInUserIndex); // Show the menu for the logged-in user
            }
        }
        static int login(string[] userNames, int[] PIN) // Method to handle user login
        {
            Console.Write("Användarnamn: ");
            string? username = Console.ReadLine();
            int userIndex = -1; // Initialize userIndex to -1 to indicate that the user has not been found yet
            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i] == username) // Check if the entered username matches any of the stored usernames
                {
                    userIndex = i; // Store the index of the found user
                    break; // Exit the loop since we found the user
                }
            }  
            if (userIndex == -1) // If the user was not found, print an error message and return -1
            {
                    Console.WriteLine("Felaktigt användarnamn eller PIN. Försök igen.");
                    return -1;
            }
                int attempts = 0; // Initialize attempts to 0 to keep track of the number of PIN entry attempts

            while (attempts < 3) // Allow the user to enter their PIN up to 3 times
            {
                Console.Write("PIN: ");
                int pinInput = int.TryParse(Console.ReadLine(), out int pin) ? pin : -1; // Read the entered PIN and convert it to an integer, or set it to -1 if the input is invalid
                if (pinInput == PIN[userIndex]) // Check if the entered PIN matches the stored PIN for the user
                {
                    Console.WriteLine("Inloggning lyckades!");
                    return userIndex;
                }
                    attempts++;
                if(attempts < 3)
                {
                    Console.WriteLine("Felaktigt användarnamn eller PIN. Försök igen. Du har " + (3 - attempts) + " försök kvar.");
                }
             }
            Console.WriteLine("För många misslyckade försök. Programmet avslutas.");
            return -1; // Return -1 to indicate that the login failed after 3 attempts
        }
        static void ShowMenu(int userIndex)
        {
            while (true)
            {
                Console.WriteLine("Väkommen till Bankomaten! Välj ett alternativ:");
                Console.WriteLine("1. Visa konton och saldo");
                Console.WriteLine("2. Överför pengar mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Du valde Visa konton och saldo");
                        break;
                    case "2":
                        Console.WriteLine("Du valde Överför pengar mellan konton");
                        break;
                    case "3":
                        Console.WriteLine("Du valde Ta ut pengar");
                        break;
                    case "4":
                        Console.WriteLine("Du Loggas ut... ");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
     }
}
