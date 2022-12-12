using System;
using CalcInterfaces;

namespace CalcServer
{
    public class CalcService : ICalcService
    {
        public string Divizion(float firstNumber, float secondNumber)
        {
            if (secondNumber == 0) return "Divizion by zero";
            return (firstNumber / secondNumber).ToString();
            
        }

        public float Mod(float firstNumber, float secondNumber)
        {
            return firstNumber % secondNumber;
        }

        public float Multiplication(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public float Power(float firstNumber, float secondNumber)
        {
            return (float)Math.Pow(firstNumber, secondNumber);
        }

        public float Substraction(float firstNumber, float secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public float Sum(float firstNumber, float secondNumber)
        {
            return firstNumber + secondNumber;
        }
    }
}
