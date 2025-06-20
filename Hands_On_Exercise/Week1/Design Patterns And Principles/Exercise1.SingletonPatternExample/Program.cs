// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        Logger logger1 = Logger.GetInstance();
        logger1.Log("First message");

        Logger logger2 = Logger.GetInstance();
        logger2.Log("Second message");

        // Check if both logger instances are the same
        if (object.ReferenceEquals(logger1, logger2))
        {
            Console.WriteLine("Both logger instances are the same. Singleton works!");
        }
        else
        {
            Console.WriteLine("Different logger instances. Singleton failed!");
        }
    }
}

