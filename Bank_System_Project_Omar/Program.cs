namespace Bank_System_Project_Omar
{
     class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = { "Omar", "John", "Micheal", "Frank", "Adam" };
            int[] PIN = { 1234, 4567, 8900, 4242, 3231 };
            decimal[,] balances = {
                {4500m, 3240m},
                {12700m, 32300m},
                {14500m, 19000m},
                {30000m, 23000m},
                {1400m, 0m},
            };
            Console.WriteLine("Hello and welcome to the bank system! ");
        }
    }
}
