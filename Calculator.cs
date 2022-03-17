using System;

public class Calculator
{
    public Calculator() { }

    public double Calculate(double num1, double num2, string sign) 
    {
        switch (sign)
        {
            case "+":
                return (double)Math.Round((double)num1 + (double)num2, 2);
            case "-":
                return (double)Math.Round((double)num1 - (double)num2, 2);
            case "*":
                return (double)Math.Round((double)num1 * (double)num2, 2);
            case "/":
                return (double)Math.Round((double)num1 / (double)num2, 2);
            default:
                return 0;
        }
    }
}