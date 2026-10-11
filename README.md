# Bank_System_Project_Omar

A simple bank/ATM system built in **C# and .NET 10** as a Console Application.

## Features

- Login with username and PIN
- View accounts and balances
- Transfer money between accounts
- Withdraw money with PIN verification
- Input validation
- Logout and login again

## Structure

The program uses arrays, loops, conditions, and separate methods for the different functions.

## Reflection

I chose to divide the program into several methods to make the code easier to understand and give each part a specific responsibility. Since custom classes are not allowed in this course, I used arrays to store users, accounts, PINs and balances.

An alternative solution would be to use classes such as `User` and `Account`. This would make the program more organized and easier to expand, but it was not allowed for this assignment.

Another improvement would be to use a database instead of hardcoded arrays. This would allow user information and account balances to be saved even after the program is closed.

Overall, I think the current solution works well for the requirements of the assignment, but using classes and a database would make it more suitable for a larger and more realistic banking system.


## Technologies

- C#
- .NET 10
- Visual Studio
- Git & GitHub
