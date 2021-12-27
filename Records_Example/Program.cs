using System;
using System.Collections.Generic;
/*
*Benefits
* - Simple to set up
* - Thread safe
* - Easy/safe to share
* 
* When to use redords
* - Capturing external data that doesn't change
* - API calls
* - Processing data
* - Read-only data
* 
* When not to use records
* - When you need to change the data (Entity Framework)
*/
namespace Records_Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Record1 r1a = new Record1("Viktor","Zafirovski");
            Record1 r1b = new Record1("Viktor", "Zafirovski");
            Record1 r1c = new Record1("Svasta", "Nikakva");

            Class1 c1a = new Class1("Viktor", "Zafirovski");
            Class1 c1b = new Class1("Viktor", "Zafirovski");
            Class1 c1c = new Class1("Svasta", "Nikakva");
            Console.WriteLine($"{r1a.FirstName} {r1a.LastName}");

            Console.WriteLine("***************************************");
            Console.WriteLine();

            Console.WriteLine("Record Type");
            Console.WriteLine($"To string {r1a}");
            Console.WriteLine($"Are there are 2 objects equal: {Equals(r1a,r1b)}");
            Console.WriteLine($"Are there are 2 objects Reference equal: {ReferenceEquals(r1a, r1b)}");
            Console.WriteLine($"Are there are 2 objects equal ==: {r1a == r1b}");
            Console.WriteLine($"Are there are 2 objects equal !=: {r1a != r1b}");
            Console.WriteLine($"Hash code of object A: {r1a.GetHashCode()}");
            Console.WriteLine($"Hash code of object B: {r1b.GetHashCode()}");
            Console.WriteLine($"Hash code of object C: {r1c.GetHashCode()}");
            Console.WriteLine();

            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            Console.WriteLine("Class Type");
            Console.WriteLine($"To string {c1a}");
            Console.WriteLine($"Are there are 2 objects equal: {Equals(c1a, c1b)}");
            Console.WriteLine($"Are there are 2 objects Reference equal: {ReferenceEquals(c1a, c1b)}");
            Console.WriteLine($"Are there are 2 objects equal ==: {c1a == c1b}");
            Console.WriteLine($"Are there are 2 objects equal !=: {c1a != c1b}");
            Console.WriteLine($"Hash code of object A: {c1a.GetHashCode()}");
            Console.WriteLine($"Hash code of object B: {c1b.GetHashCode()}");
            Console.WriteLine($"Hash code of object C: {c1c.GetHashCode()}");
            Console.WriteLine();

            // DECONSTRUCTOR
            var (fn, ln) = r1a;
            Console.WriteLine("******************************");
            Console.WriteLine($"The value of fn is {fn} and the value of ln is {ln}");
            Console.WriteLine();

            // RECORD OBJ COPY
            Console.WriteLine("*********************************");
            Record1 r1d = r1a with
            {
                FirstName = "John"
            };
            Console.WriteLine($"Jon's record: {r1d}");

            // RECORD PROPERTY ACCESS MODIFIER
            Console.WriteLine();
            Console.WriteLine("*********************************");

            Record2 r2a = new Record2("Viktor", "Zafirovski");
            Console.WriteLine($"R2a value: {r2a}");
            Console.WriteLine($"R2a fn: {r2a.FirstName} R2a ln: {r2a.LastName}");
            Console.WriteLine(r2a.SayHello());
            Console.ReadLine();
        }
        
    }
    // a records is just a fancy class
    // Immutable
    // Records is Readonly class
    public record Record1(string FirstName, string LastName);
    //RECORD INHERITANCE
    public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName);

    public class Discovery
    {
        public User1 LookupUser { get; set; }
        public int IncidenceFound { get; set; }
        public List<string> Incidens { get; set; }
    }

    public record Record2(string FirstName, string LastName)
    {
        private string _firstName = FirstName;

        public string FirstName
        {
            get { return _firstName.Substring(0, 1); }
            init { }
        }
        //internal string FirstName { get; init; } = FirstName;
        public string FullName { get => $"{FirstName} {LastName}"; }

        //METHOD IN RECORD
        public string SayHello()
        {
            return $"Hello {FirstName}";
        }
    }
    public class Class1
    {
        // "init" - only set the values in a constructor or when you create a class using the curly brace syntax
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public Class1(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public void Deconstruct(out string FirstName, out string LastName)
        {
            FirstName = this.FirstName;
            LastName = this.LastName;
        }
    }

    //*****************************
    // DO NOT DO ANY OF THE BELLOW
    //*******************************
    public record Record3  // no construtor so no deconstructor
    {
        public string FirstName { get; set; }  //The set makes this records mutable (BAD) 
        public string LastName { get; set; }
    }
}
