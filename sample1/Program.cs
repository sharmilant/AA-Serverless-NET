namespace sample1;
using System;


class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello, World!");
        Person person = new Person("Donald Trump", 75);
        //person.name = "Donald Trump";
        //person.age = 75;
        Console.WriteLine(person.Hello(false));
    }
}

