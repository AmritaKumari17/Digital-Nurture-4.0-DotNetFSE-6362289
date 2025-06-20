//Time Complexity:
//Without memoization: O(2^n) — exponential
//With memoization: O(n) — linear

using System;
using System.Collections.Generic;

class Program
{
    //  Recursive function with memoization (optimization)
    static double PredictFutureValue(int year, double initialValue, double growthRate, Dictionary<int, double> memo)
    {
        if (year == 0)
            return initialValue;

        if (memo.ContainsKey(year))
            return memo[year];

        double previousValue = PredictFutureValue(year - 1, initialValue, growthRate, memo);
        double currentValue = previousValue * (1 + growthRate);
        memo[year] = currentValue;
        return currentValue;
    }

    static void Main(string[] args)
    {
        Console.Write("Enter initial value (₹): ");
        double initialValue = double.Parse(Console.ReadLine());

        Console.Write("Enter annual growth rate (e.g., 0.1 for 10%): ");
        double growthRate = double.Parse(Console.ReadLine());

        Console.Write("Enter number of years to forecast: ");
        int years = int.Parse(Console.ReadLine());

        Console.WriteLine("\n Financial Forecast:");
        var memo = new Dictionary<int, double>();

        for (int i = 0; i <= years; i++)
        {
            double value = PredictFutureValue(i, initialValue, growthRate, memo);
            Console.WriteLine($"Year {i}: ₹{value:F2}");
        }
    }
}
