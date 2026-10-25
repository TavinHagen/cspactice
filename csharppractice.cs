/*
Methods Called Here:
*/

// userNextYearAge();





/*
Goal: Practice input, variables, strings, and type conversion.

Print a prompt asking for the user’s name, then read it with Console.ReadLine() and store it in a string.
Prompt for their age and read it as a string.
Convert the age to an int with int.Parse.
Calculate next year’s age in a new variable.
Print the result using string interpolation ($"...").

Bonus: Use int.TryParse and keep re-asking until the user enters a valid number.
*/
static void userNextYearAge() {
    Console.Write("What is your name? ");
    string name = Console.ReadLine();

    int age;
    while (true)
    {   
        Console.Write("\nHow old are you? ");
        if (int.TryParse(Console.ReadLine(), out age))
        {   
            break;
        }
        else
        {
            Console.WriteLine("\nPlease input a valid age.");
        }
    }

    int nextYearAge = age + 1;
    Console.WriteLine($"\nHello {name}! Next year you'll be {nextYearAge}");
}
