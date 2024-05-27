
using System;

public delegate double CalculatorDelegator(double num1, double num2, char operation);


public class Caclulator
{
    public static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':

                if (num2 != 0)
                    return num1 / num2;
                else
                    return -1;
            default:
                throw new ArgumentException("Invalid operation");
        }
    }
    public CalculatorDelegator funcCalc;

    public Caclulator()
    {
        funcCalc = new CalculatorDelegator(Calc);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Caclulator handcalc = new Caclulator();

        double result1 = handcalc.funcCalc(10, 7, '+');
        double result2 = handcalc.funcCalc(20, 2, '/'); 
        double result3 = handcalc.funcCalc(8, 7, '*');  
        double result4 = handcalc.funcCalc(15, 6, '-');

        Console.WriteLine($"Result of 10 + 7 = {result1}");
        Console.WriteLine($"Result of 20 / 2 = {result2}");
        Console.WriteLine($"Result of 8 * 7 = {result3}");
        Console.WriteLine($"Result of 15 - 6 = {result4}");

        Caclulator namualcalc = new Caclulator();

        Console.WriteLine("Enter first number:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter operation (+, -, *, /):");
        char operation = Convert.ToChar(Console.ReadLine());

        double result = namualcalc.funcCalc(num1, num2, operation);

        Console.WriteLine($"Result of {num1} {operation} {num2} = {result}");
    }
}