//We'll forecast the future value using:
//A base value (e.g., Year 0 = ₹1000)
//A fixed growth rate (e.g., 10%)
//A recursive method to calculate future value at year n.

import java.util.Scanner;

public class FinancialForecast {

    // Recursive function to calculate future value
    public static double forecastValue(double baseValue, double rate, int year) {
        if (year == 0) {
            return baseValue;
        }
        return forecastValue(baseValue, rate, year - 1) * (1 + rate);
    }

    // Optimized version using memoization
    public static double forecastMemo(double baseValue, double rate, int year, Double[] memo) {
        if (year == 0)
            return baseValue;
        if (memo[year] != null)
            return memo[year];
        memo[year] = forecastMemo(baseValue, rate, year - 1, memo) * (1 + rate);
        return memo[year];
    }

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.print("Enter base year value (e.g., 1000): ");
        double baseValue = sc.nextDouble();

        System.out.print("Enter annual growth rate (in %, e.g., 10): ");
        double rate = sc.nextDouble() / 100;

        System.out.print("Enter number of years to forecast: ");
        int years = sc.nextInt();

        // Basic recursive approach
        double futureValue = forecastValue(baseValue, rate, years);
        System.out.printf("Forecasted Value after %d years: Rs. %.2f\n", years, futureValue);

        // Memoized version (optional for optimization)
        Double[] memo = new Double[years + 1];
        double optimizedValue = forecastMemo(baseValue, rate, years, memo);
        System.out.printf("Optimized Forecast (Memoization): Rs. %.2f\n", optimizedValue);

        sc.close();
    }
}
