using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryCalculations
{
    public class Calculator
    {
        private double result;
        private string currentOperation;

        private bool isDecimalClicked;

        public Calculator()
        {
            result = 0;
            currentOperation = "";
            isDecimalClicked = false;
        }

        public void SetCurrentOperation(string operation)
        {
            currentOperation = operation;
            isDecimalClicked = false;
        }

        public double PerformOperation(double number)
        {
            switch (currentOperation)
            {
                case "+":
                    result += number;
                    break;
                case "-":
                    result -= number;
                    break;
                case "X":
                    result *= number;
                    break;
                case "/":
                    if (number != 0)
                    {
                        result /= number;
                    }
                    else
                    {
                        throw new DivideByZeroException("Cannot divide by zero.");
                    }
                    break;
                case "MOD":
                    result %= number;
                    break;
                default:
                    result = number;
                    break;
            }
            return result;
        }

        public void Clear()
        {
            result = 0;
            currentOperation = "";
            isDecimalClicked = false;
        }

        public bool IsValidInput(string input)
        {
            // Check if the input contains more than one decimal point
            int decimalPointCount = 0;
            foreach (char c in input)
            {
                if (c == '.')
                {
                    decimalPointCount++;
                    if (decimalPointCount > 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
