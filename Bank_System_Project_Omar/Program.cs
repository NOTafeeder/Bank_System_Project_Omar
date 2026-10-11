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
                {19000m, 0m, 0m},
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
            while (true)
            {
                int loggedInUserIndex = login(userNames, PIN);

                if (loggedInUserIndex != -1)
                {
                    ShowMenu(loggedInUserIndex, accountTypes, balances, accountCounts, PIN);
                }
                else
                {
                    break;
                }
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
                if (attempts < 3)
                {
                    Console.WriteLine("Felaktigt användarnamn eller PIN. Försök igen. Du har " + (3 - attempts) + " försök kvar.");
                }
            }
            Console.WriteLine("För många misslyckade försök. Programmet avslutas.");
            return -1; // Return -1 to indicate that the login failed after 3 attempts
        }
        static void ShowMenu(int userIndex, string[,] accountTypes, decimal[,] balances, int[] accountCounts, int[] PIN)
        {
            while (true)
            {
                Console.WriteLine("Välkommen till Bankomaten! Välj ett alternativ:");
                Console.WriteLine("1. Visa konton och saldo");
                Console.WriteLine("2. Överför pengar mellan konton");
                Console.WriteLine("3. Ta ut pengar");
                Console.WriteLine("4. Logga ut");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ShowAccounts(userIndex, accountTypes, balances, accountCounts);
                        break;
                    case "2":
                        TransferMoney(userIndex, accountTypes, balances, accountCounts);
                        break;
                    case "3":
                        WithdrawMoney(userIndex, accountTypes, balances, accountCounts, PIN);
                        break;
                    case "4":
                        Console.WriteLine("Du loggas ut... ");
                        return;
                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }
        static void ShowAccounts(int userIndex, string[,] accountTypes, decimal[,] balances, int[] accountCounts) // Method to display the user's accounts and balances
        {
            Console.WriteLine("Dina konton och saldon:");
            for (int i = 0; i < accountCounts[userIndex]; i++) // Loop through the number of accounts the user has
            {
                Console.WriteLine($"{accountTypes[userIndex, i]}: {balances[userIndex, i]:F2} kr"); // Display the account type and balance for each account the user has
            }
            Console.WriteLine("Klick enter för att gå tillbaka till menyn.");
            Console.ReadLine();
        }
        static void TransferMoney(int userIndex, string[,] accountTypes, decimal[,] balances, int[] accountCounts) // Method to handle money transfers between accounts
        {
            Console.WriteLine("Välj kontot du vill överföra pengar från:");
            for (int i = 0; i < accountCounts[userIndex]; i++) // Loop through the number of accounts the user has
            {
                Console.WriteLine($"{i + 1}. {accountTypes[userIndex, i]}: {balances[userIndex, i]:F2} kr"); // Display the account type and balance for each account the user has
            }
            int fromAccount = int.TryParse(Console.ReadLine(), out fromAccount) ? fromAccount - 1 : -1; // Read the user's choice for the account to transfer from and convert it to an index
            if (fromAccount < 0 || fromAccount >= accountCounts[userIndex])
            {
                Console.WriteLine("Ogiltigt konto val.");
                Console.WriteLine("Tryck Enter för att gå tillbaka till menyn.");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Välj kontot du vill överföra pengar till:");
            for (int i = 0; i < accountCounts[userIndex]; i++) // Loop through the number of accounts the user has again to display the options for the account to transfer to
            {
                if (i != fromAccount)
                {
                    Console.WriteLine($"{i + 1}. {accountTypes[userIndex, i]}: {balances[userIndex, i]:F2} kr"); // Display the account type and balance for each account the user has, excluding the account they are transferring from
                }
            }
            int toAccount = int.TryParse(Console.ReadLine(), out toAccount) ? toAccount - 1 : -1; // Read the user's choice for the account to transfer to and convert it to an index
            if (toAccount < 0 || toAccount >= accountCounts[userIndex] || toAccount == fromAccount)
            {
                Console.WriteLine("Ogiltigt konto val.");
                Console.WriteLine("Tryck Enter för att gå tillbaka till menyn.");
                Console.ReadLine();
                return;
            }
            Console.Write("Ange belopp att överföra: ");
            decimal amount = decimal.TryParse(Console.ReadLine(), out amount) ? amount : 0; // Read the amount to transfer and convert it to a decimal, or set it to 0 if the input is invalid
            if ( amount <= 0) // Check if the amount is greater than the balance of the fromAccount or less than or equal to 0
            {
                Console.WriteLine("Ogiltigt belopp. Återgår till menyn.");
            }
            else if (amount > balances[userIndex, fromAccount]) // Check if the amount is greater than the balance of the fromAccount
            {
                Console.WriteLine("Otillräckligt saldo för att genomföra överföringen.");
            }
            else
            {
                balances[userIndex, fromAccount] -= amount; // Deduct the amount from the fromAccount balance
                balances[userIndex, toAccount] += amount; // Add the amount to the toAccount balance
                Console.WriteLine($"Överföring av {amount:F2} kr från {accountTypes[userIndex, fromAccount]} till {accountTypes[userIndex, toAccount]} lyckades.");
            }
            Console.WriteLine("Klick enter för att gå tillbaka till menyn.");
            Console.ReadLine();
        }
        static void WithdrawMoney(int userIndex, string[,] accountTypes, decimal[,] balances, int[] accountCounts, int[] PIN) // Method to handle money withdrawals
        {
            Console.WriteLine("Välj kontot du vill ta ut pengar från:");
            for (int i = 0; i < accountCounts[userIndex]; i++) // Loop through the number of accounts the user has
            {
                Console.WriteLine($"{i + 1}. {accountTypes[userIndex, i]}: {balances[userIndex, i]:F2} kr"); // Display the account type and balance for each account the user has
            }
            int fromAccount = int.TryParse(Console.ReadLine(), out fromAccount) ? fromAccount - 1 : -1; // Read the user's choice for the account to withdraw from and convert it to an index
            if (fromAccount < 0 || fromAccount >= accountCounts[userIndex])
            {
                Console.WriteLine("Ogiltigt konto val.");
                Console.WriteLine("Tryck Enter för att gå tillbaka till menyn.");
                Console.ReadLine();
                return;
            }
            Console.Write("Ange belopp att ta ut: ");
            decimal amount = decimal.TryParse(Console.ReadLine(), out amount) ? amount : 0; // Read the amount to withdraw and convert it to a decimal, or set it to 0 if the input is invalid
            if (amount <= 0) // Check if the amount is greater than the balance of the fromAccount or less than or equal to 0
            {
                Console.WriteLine("Ogiltigt belopp. Återgår till menyn.");
            }
            else if(amount > balances[userIndex, fromAccount]) // Check if the amount is greater than the balance of the fromAccount
            {
                Console.WriteLine("Otillräckligt saldo för att genomföra uttaget.");
            }
            else
            {
                Console.Write("Ange din PIN för att bekräfta uttaget: ");
                int enteredPin = int.TryParse(Console.ReadLine(), out int pin) ? pin : -1;
                if (enteredPin != PIN[userIndex])
                {
                    Console.WriteLine("Felaktig PIN. Uttaget avbröts.");
                    Console.WriteLine("Tryck Enter för att gå tillbaka till menyn.");
                    Console.ReadLine();
                    return;
                }
                balances[userIndex, fromAccount] -= amount; // Deduct the amount from the fromAccount balance
                Console.WriteLine($"Uttag av {amount:F2} kr från {accountTypes[userIndex, fromAccount]} lyckades.");
            }
            Console.WriteLine("Klick enter för att gå tillbaka till menyn.");
            Console.ReadLine();

        }
    }
}
