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

public class Student
{
    private string name;
    private int grade;

    public Student(string name, int grade)
    {
        this.name = name;
        this.grade = grade;
    }
}