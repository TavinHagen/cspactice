
using System.IO.Compression;
using System.Linq;
using System.Text.RegularExpressions;

/*
Methods Called Here:
*/

// userNextYearAge();

// Console.WriteLine(Math.Round(simpleMath(), 2));

// fizzBuzz();

// gradeBook();

/*
BankAccount account = new BankAccount("Dave", 34.55m);
account.Deposit(332.43m);
account.Withdraw(33.68m);
Console.WriteLine(account.ToString());
*/

/*
List<Shape> shapes = new List<Shape>
{
    new Circle(5),
    new Circle(2),
    new Rectangle(5, 3),
    new Rectangle(4, 4),
    new Triangle(6, 3),
};

double totalArea = 0;

foreach (Shape shape in shapes)
{
    double area = shape.Area();

    Console.WriteLine($"{shape.Name}'s Area: {area:F2}");

    totalArea += area;
}

Console.WriteLine($"\nTotal Area: {totalArea:F2}");

List<Shape> sortedShapes = shapes.OrderBy(shape => shape.Area()).ToList();
*/

/*
var students = new List<Student>
{
    new Student("Jonas", 45),
    new Student("Jude", 9),
    new Student("Chase", 100),
    new Student("Kyle", 75),
    new Student("Jaden", 80),
    new Student("Andy", 60),
    new Student("Hunter", 61),
    new Student("Zach", 25),
    new Student("Evan", 91),
    new Student("Stevenson", 90),
};

var topStudents = students.Where(Student => Student.Grade >= 80).OrderBy(Student => Student.Name).ToList();

var groupByGrade = students.GroupBy(student => student.GetLetter(student.Grade)).ToList();

Console.WriteLine("Students with a grade of 80+:");
foreach (var student in topStudents)
{
    Console.WriteLine($"    Student: {student.Name}, Grade: {student.Grade}");
}

Console.WriteLine("\nSorted Students by grade:");
foreach (var group in groupByGrade)
{
    Console.WriteLine($"    Grade Category: {group.Key}");
    foreach (var student in group)
    {
        Console.WriteLine($"    Student: {student.Name}, Grade: {student.Grade}");
    }
}

bool hasFail = students.Any(student => student.Grade < 60);
Console.WriteLine($"\nHas any student failed: {hasFail}");

bool allPassed = students.All(student => student.Grade >= 60);
Console.WriteLine($"\nHas all students passed: {allPassed}");

var gradeAverages = groupByGrade.Select(group => new
{
    Grade = group.Key,
    Average = group.Average(student => student.Grade)
});
*/

// ==============================================

/*
Goal: Practice input, variables, strings, and type conversion.

Print a prompt asking for the user’s name, then read it with Console.ReadLine() and store it in a string.
Prompt for their age and read it as a string.
Convert the age to an int with int.Parse.
Calculate next year’s age in a new variable.
Print the result using string interpolation ($"...").

Bonus: Use int.TryParse and keep re-asking until the user enters a valid number.
*/
static void userNextYearAge() 
{
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
        else
        {
            Console.WriteLine("Invalid number.");
            continue;
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

        if (input == "0" && (operatorChoice == "/" || operatorChoice == "%"))
        {
            Console.WriteLine("\nError: Cannot divide by zero.\nPlease enter valid number.");
            continue;
        }

        if (double.TryParse(input, out denominator))
        {
            running = false;
        }
        else
        {
            Console.WriteLine("Invalid number.");
            continue;
        }
    }

    switch (operatorChoice)
    {
        case "+":
            return add(numerator, denominator);
        case "-":
            return subtract(numerator, denominator);
        case "*":
            return multiply(numerator, denominator);
        case "/":
            return divide(numerator, denominator);
        case "%":
            return modulus(numerator, denominator);
        case "^":
            return power(numerator, denominator);
        default:
            Console.WriteLine("\nError: Couldn't proccess request.");
            return 1.0;
    }
}

static double add(double a, double b) => a + b;
static double subtract(double a, double b) => a - b;
static double multiply(double a, double b) => a * b;
static double divide(double a, double b) => a / b;
static double modulus(double a, double b) => a % b;
static double power(double a, double b) => Math.Pow(a, b);

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
static void fizzBuzz()
{
    for (int i = 1; i <= 100; i++)
    {
        if (i > 1)
        {
            Console.Write(", ");
        }

        string output = (i % 3 == 0, i % 5 == 0) switch
        {
            (true, true) => "FizzBuzz",
            (true, _) => "Fizz",
            (_, true) => "Buzz",
            (_, _) => i.ToString() 
        };

        Console.Write(output);
    }
    Console.WriteLine();
}

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
static void gradeBook()
{   
    Console.WriteLine("Enter scores (type 'done' to exit): ");

    List<int> scores = new List<int>();

    while (true)
    {   
        Console.Write("\nEnter: ");
        string score = Console.ReadLine();
        
        int num = 0;

        if (score == "done") break;

        if (int.TryParse(score, out num) && num >= 0 && num <= 100)
        {
            scores.Add(num);
        }
        else
        {
            Console.WriteLine("Invalid number. Must be in the range 0-100");
        }
    }

    if (scores.Count <= 0)
    {
        Console.WriteLine("No scores entered");
        return;
    }

    scores.Sort();

    Console.Write("\nSorted: ");
    Console.Write(string.Join(", ", scores));

    double averageScore = scores.Average();
    Console.WriteLine($"\nAverage: {averageScore:F1}");

    int maxScore = scores.Max();
    Console.WriteLine($"Highest: {maxScore}");

    int minScore = scores.Min();
    Console.WriteLine($"Lowest: {minScore}");

    bool allPassed = scores.All(score => score >= 60);
    Console.WriteLine($"Everyone passed: {allPassed}");
}

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
string filePath = Path.Combine(AppContext.BaseDirectory, "sample.txt");

string content;

try
{
    content = File.ReadAllText(filePath);
}
catch (FileNotFoundException)
{
    Console.WriteLine("File not found.");
    return;
}

string lower = content.ToLower();

char[] separators = { ' ', '.', ',', '!', '?' };
string[] splitContent = lower.Split(separators, StringSplitOptions.RemoveEmptyEntries);

var wordCount = new Dictionary<string, int>();

foreach (string word in splitContent)
{
    if (wordCount.ContainsKey(word))
    {
        wordCount[word]++;
    }
    else
    {
        wordCount.Add(word, 1);
    }
}

Dictionary<string, int> sortedWordCount = wordCount.OrderByDescending(pair => pair.Value).Take(5).ToDictionary(pair => pair.Key, pair => pair.Value);

foreach (var word in sortedWordCount)
{
    Console.WriteLine($"{word.Key} : {word.Value}");
}
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


/*
LESSON 01: CLASSES AND CONSTRUCTORS

Create a class named GameProfile.

Requirements:

1. Create a public string field called Name.
2. Create a public int field called Level.
3. Create a constructor that accepts a name.
4. The constructor must store the name and
   set the starting level to 1.
5. Create a public method called LevelUp()
   that increases Level by 1.
6. Create a method called Summary() that
   returns:
   "Name: <name>, Level: <level>"

TEST CASES:

- A new GameProfile("Mira") starts at level 1.
- Calling LevelUp() twice makes the level 3.
- A second GameProfile("Jun") still starts
  at level 1.
- Mira's Summary() should return:
  "Name: Mira, Level: 3"

Try implementing it yourself.
*/


// Linq practice:

/*
Problem 1: Basic Filtering (Where)

• Task: Given a list of integers List<int> numbers = new() { 1, 4, 7, 9, 12, 15, 18, 22 };, 
write a LINQ query to get only the even numbers that are greater than 10, 
and return them as a List<int>.

Hint: Use .Where(n => ...) followed by .ToList().*/

var numbers = new List<int>() { 1, 4, 7, 9, 12, 15, 18, 22 };

var evenGreaterThanTen = numbers.Where(n => n % 2 == 0 && n > 10).ToList();
Console.WriteLine("Even numbers greater than 10: ");

foreach (int num in evenGreaterThanTen)
{
    Console.WriteLine($"\t{num}");
}


/*
Problem 2: Projection (Select)

• Task: Given a list of Student objects, 
return a List<string> containing only the names of all students whose major is "Computer Science".

• Hint: Combine Where and Select*/

var newStudents = new List<Student2>()
{
    new Student2 { Name = "Liam", Major = "Computer Science" },
    new Student2 { Name = "Jonas", Major = "Computer Science" },
    new Student2 { Name = "Jude", Major = "Gender Studies & lesbian tribal dance" },
    new Student2 { Name = "Oliver", Major = "Everything" },
};

var prob2result = newStudents.Where(s => s.Major == "Computer Science").Select(s => s.Name).ToList();

Console.WriteLine("\nStudent with a Computer Science Major: ");
foreach (string name in prob2result)
{
    Console.WriteLine($"\tName: {name}");
}


/*
Problem 3: Sorting (OrderBy and OrderByDescending)

• Task: Given a list of Product objects, 
sort the products first by Category (ascending) and then by Price (descending).

• Hint: Use .OrderBy(...) and .ThenByDescending(...)*/

var products = new List<Product>()
{
    new Product { Category = "Utility", Price = 4.53m },
    new Product { Category = "Utility", Price = 50.76m },
    new Product { Category = "Food", Price = 2.99m },
    new Product { Category = "Entertainment", Price = 456.66m },
};

var sortedProducts = products.OrderBy(p => p.Category)
                    .ThenByDescending(p => p.Price).ToList();

Console.WriteLine("\nSorted products by category and price:");
foreach (Product item in sortedProducts)
{
    Console.WriteLine($"\tCategory: {item.Category}, Price: {item.Price}");
}

/*
Problem 4: Aggregation (Average and Max)

• Task: Given a list of Student objects, find the average GPA of all students, 
and separately find the highest GPA value.

• Hint: Use .Average(s => s.GPA) and .Max(s => s.GPA).*/

var studentsGPA = new List<Student2>()
{
    new Student2 { GPA = 3.2 },
    new Student2 { GPA = 4.0 },
    new Student2 { GPA = 3.5 },
    new Student2 { GPA = 1.5 },
    new Student2 { GPA = 3.2 },
};

double avgGPA = studentsGPA.Average(s => s.GPA);

Console.WriteLine($"\nThe average GPA is {avgGPA:F3}");

double highestGPA = studentsGPA.Max(s => s.GPA);

Console.WriteLine($"\nThe highest GPA is {highestGPA:F3}");

/*
Problem 5: Grouping (GroupBy)

• Task: Group a list of Product objects by their Category and 
project each group into an anonymous type containing the Category name 
and the count of products in that category.

• Hint: Use products.GroupBy(p => p.Category).Select(g => new { g.Key, Count = g.Count() }).*/

var categoryProducts = new List<Product>()
{
    new Product { Category = "utility", Stock = 1 },
};

var groupedProducts = categoryProducts.GroupBy(p => p.Category).Select(s => new
{
    s.Key,
    Count = s.Count(),
});

Console.WriteLine("\nProduct categories and count:");
foreach (var group in groupedProducts)
{
    Console.WriteLine($"\tCategory: {group.Key}, Amount: {group.Count}");
}


/*
Problem 6: Condition Checks (Any and First / FirstOrDefault)

• Task: Check if any product in the products list has a Stock == 0 (out of stock). 
Then, retrieve the first product whose price is greater than $500 (or null if none exist).

• Hint: Use .Any(...) and .FirstOrDefault(...).*/



public class Student2
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Major { get; set; }
    public double GPA { get; set; }
}

public class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}