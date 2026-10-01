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
                { "", "Sparkonto", "" },
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
            if(loggedInUserIndex == -1)
            {
                Console.WriteLine("Inloggning misslyckades. Programmet avslutas.");
                return;
            }
        }
        static int login(string[] userNames, int[] PIN)
        {
            Console.Write("Användarnamn: ");
            string username = Console.ReadLine();
            int userIndex = -1;
            for (int i = 0; i < userNames.Length; i++)
            {
                if (userNames[i] == username)
                {
                    userIndex = i;
                    break;
                }
            }  
                if(userIndex == -1)
                {
                    Console.WriteLine("Felaktigt användarnamn eller PIN. Försök igen.");
                    return -1;
                }
                int attempts = 0;

                while(attempts < 3)
                {
                    Console.Write("PIN: ");
                    int pinInput = int.TryParse(Console.ReadLine(), out int pin) ? pin : -1;
                    if(pinInput == PIN[userIndex])
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
            return -1;
        }
     }
}
