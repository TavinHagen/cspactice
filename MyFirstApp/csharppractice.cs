/*
Methods Called Here:
*/

// userNextYearAge();
Console.WriteLine(simpleMath());

// ==============================================:

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

/*
Goal: Practice methods, parameters, return values, and switch.

Write four static methods: Add, Subtract, Multiply, and Divide. Each takes two double parameters and returns a double.
In Main, ask for a first number, an operator (+ - * /), and a second number.
Use a switch statement on the operator to call the right method.
If the user divides by zero, print an error message instead of a result. Don’t let the program crash.
Wrap steps 2-4 in a while loop that repeats until the user types q for the first input.

Sample run:

Enter first number (or q to quit): 10
Enter operator: /
Enter second number: 0
Error: cannot divide by zero.

Bonus: Add % (modulus) and ^ (power, using Math.Pow).
*/
static double simpleMath()
{   

    bool running = true;
    double numerator = 0;
    while (running)
    {   
        Console.Write("Enter first number (or q to quit): ");
        string input = Console.ReadLine();

        if (input == "q") return 0.0;

        if (double.TryParse(input, out numerator))
        {
            running = false;
        }
    }

    running = true;
    string operatorChoice = "";

    while (running) {
        Console.Write("\nEnter operator: ");

        string input = Console.ReadLine();

        switch (input)
        {
            case "+":
            case "-":
            case "*":
            case "/":
            case "%":
            case "^":
                operatorChoice = input;
                break;
            default:
                Console.WriteLine("\nPlease enter a valid operator.");
                continue;
        }  
        running = false;
    }

    running = true;
    double denominator = 0;

    while (running)
    {   
        Console.Write("\nEnter second number: ");
        string input = Console.ReadLine();

        if (input == "0")
        {
            Console.WriteLine("\nError: Cannot divide by zero.\nPlease enter valid number.");
            continue;
        }

        if (double.TryParse(input, out denominator))
        {
            running = false;
        }
    }

    switch (operatorChoice)
    {
        case "+":
            return numerator + denominator;
        case "-":
            return numerator - denominator;
        case "*":
            return numerator * denominator;
        case "/":
            return numerator / denominator;
        case "%":
            return numerator % denominator;
        case "^":
            return Math.Pow(numerator, denominator);
        default:
            Console.WriteLine("\nError: Couldn't proccess request.");
            return 0.0;
    }
}

/*
Problem 3: FizzBuzz (videos 9-12)

Goal: Practice for loops, if statements, and the modulus operator.

Write a for loop from 1 to 100.
Inside the loop, check divisibility with %.
If the number is divisible by both 3 and 5, print FizzBuzz. Check this condition first, or it will never run.
Else if divisible by 3, print Fizz.
Else if divisible by 5, print Buzz.
Otherwise, print the number.

Expected start of output: 1, 2, Fizz, 4, Buzz, Fizz, 7, 8, Fizz, Buzz, 11, Fizz, 13, 14, FizzBuzz

Bonus: Rewrite it using a switch expression with a tuple pattern (video 88).
*/



/*
Problem 4: Grade Book (videos 14-15, 50, 64, 66)

Goal: Practice List<T>, sorting, and LINQ aggregates.

Create a List<int> scores.
In a loop, ask the user to enter scores until they type done. Reject anything outside 0-100 with a message and ask again.
If the list is empty, print “No scores entered.” and stop. (Calling Average() on an empty List<int> throws an exception.)
Print the scores sorted from lowest to highest.
Use LINQ to print the average (formatted to 1 decimal place), the highest, and the lowest.
Use Any or All to print whether every score is a passing score (60 or higher).

Sample run:

Sorted: 55, 72, 88, 91
Average: 76.5
Highest: 91
Lowest: 55
Everyone passed: False

Bonus: Calculate the average and max again using a foreach loop instead of LINQ, and confirm the results match.
*/



/*
Problem 5: Bank Account (videos 27-31, 37, 40)

Goal: Practice classes, constructors, encapsulation, and ToString.

Create a BankAccount class with a string Owner property and a private decimal balance field.
Expose the balance through a public read-only property: public decimal Balance => _balance;.
Write a constructor that takes an owner name and starting balance. Add a second constructor that takes only the owner and chains to the first with a balance of 0 (: this(owner, 0)).
Write Deposit(decimal amount). Reject amounts of 0 or less.
Write Withdraw(decimal amount) that returns a bool. Return false and don’t change the balance if the amount is invalid or larger than the balance. Otherwise subtract it and return true.
Override ToString() to return something like Alex: $120.50.
In Main, create an account, deposit, withdraw, then try to withdraw too much. Print the account after each step.

Bonus: Add a static int TotalAccounts counter that increases in the constructor (video 31).
*/



/*
Problem 6: Shapes (videos 32-36, 38)

Goal: Practice abstract classes, inheritance, overriding, and polymorphism.

Create an abstract class Shape with an abstract double Area() method and a string Name property.
Create Circle (with a Radius) and Rectangle (with Width and Height). Each inherits Shape and overrides Area(). Use Math.PI for the circle.
Give each a constructor that takes its dimensions and sets Name.
In Main, create a List<Shape> holding at least two circles and two rectangles.
Loop over the list and print each shape’s name and area formatted to 2 decimals.
Print the total area of all shapes.

Sample run:

Circle: 78.54
Rectangle: 24.00
Total area: 102.54

Bonus: Add a Triangle class without changing your loop, then sort the list by area with OrderBy.
*/



/*
Problem 7: Word Counter (videos 42, 71-73, 80-81)

Goal: Practice file reading, dictionaries, and exception handling.

Create a text file named sample.txt with a few sentences. Set it to “Copy to output directory” in the project file, or build the path with Path.Combine(AppContext.BaseDirectory, "sample.txt").
Wrap your file reading in try/catch. Catch FileNotFoundException and print a friendly message.
Read the file with File.ReadAllText (or StreamReader).
Convert the text to lowercase and split it into words. Split on spaces plus punctuation such as .,!? and remove empty entries (StringSplitOptions.RemoveEmptyEntries).
Create a Dictionary<string, int>. For each word, increment its count if it’s already a key, or add it with a count of 1.
Print the 5 most frequent words, sorted by count descending, using OrderByDescending and Take(5).

Sample output:

the: 7
code: 4
is: 3

Bonus: Ask the user for the file path and handle the case where it doesn’t exist.
*/



/*
Problem 8: Student Filter (videos 56-67)

Goal: Practice LINQ filtering, sorting, grouping, and paging.

Create a Student class with Name and Grade (int). Make a list of at least 10 students with varied grades.
Write a helper method string GetLetter(int grade) that returns A (90+), B (80-89), C (70-79), D (60-69), or F.
Use Where to get students with grade 80 or higher, then OrderBy name. Print them.
Use GroupBy with GetLetter to group all students by letter. Print each letter, then the names and the count in that group.
Use Any to check whether any student has failed, and All to check whether everyone has at least 50.
Use OrderByDescending, Take, and Select to print the top 3 students.

Bonus: Print the average grade per letter group using Average inside a Select on the groups.
*/



/*
Problem 9: Inventory with JSON (videos 77, 89, 90, 95)

Goal: Practice records, nullable reference types, and JSON serialization.

Make sure nullable reference types are enabled (<Nullable>enable</Nullable> in your .csproj).
Define public record Item(string Name, int Quantity, decimal Price, string? Notes);.
Create a List<Item> with at least 4 items. Leave Notes as null for some.
Serialize the list with JsonSerializer.Serialize using JsonSerializerOptions { WriteIndented = true }, then save it with File.WriteAllText.
Open the file in your editor and confirm the JSON looks right.
Read it back with File.ReadAllText and JsonSerializer.Deserialize<List<Item>>. The result can be null, so handle that case.
Print the loaded items.
Use a with expression to copy one item with a new quantity, and print both to show the original didn’t change.

Bonus: Compare an original item to its loaded copy with == and explain why records give you true (video 89).
*/



/*
Problem 10: Async Timer (videos 83-84, 85)

Goal: Practice async/await and running work concurrently.

Make your Main method static async Task Main(string[] args).
Write static async Task CountdownAsync(string label, int seconds). Use a loop that prints label: N... and calls await Task.Delay(1000) each second, then prints label: done!.
In Main, start the task without awaiting it: Task t = CountdownAsync("Timer", 3);.
While it runs, print a few messages from Main (like “Main is still working...”) with short Task.Delay calls between them.
Finally, await t; and print “All finished.”

Bonus: Start two countdowns, wait for both with await Task.WhenAll(t1, t2), and use a Stopwatch to show the total time is about 3 seconds, not 6.
*/

