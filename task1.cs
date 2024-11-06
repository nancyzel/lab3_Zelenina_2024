using System.Numerics;
using System.Reflection.Metadata;

namespace лаб3_задача1
{
    internal class task1
    {
        // calculating the sum of a power series for a given number of terms
        public static double CountFunctionWithSummandNumber(double argument, int summandNumber)
        {
            double resultFunctionWithSummandNumber = 0;
            double summand = 1;
            int recurrentPart = 1;
            for (int i = 1; i < summandNumber + 1; i++)
            {
                resultFunctionWithSummandNumber += summand;
                recurrentPart *= i;
                summand = Math.Cos(i * argument) / recurrentPart;
            }
            return resultFunctionWithSummandNumber;
        }


        // calculating the sum of a power series for a given accuracy
        public static double CountFunctionWithAccuracy(double argument, double accuracy)
        {
            double resultFunctionWithAccuracy = 0;
            double summand = 1;
            int counterSummand = 1;
            int recurrentPart = 1;
            while (Math.Abs(summand) > accuracy)
            {
                resultFunctionWithAccuracy += summand;
                recurrentPart *= counterSummand;
                summand = Math.Cos(counterSummand * argument) / recurrentPart;
                counterSummand++;
            }
            return resultFunctionWithAccuracy;
        }


        static void Main(string[] args)
        {
            double lowerCeiling = 0.1;
            double upperCeiling = 1;
            int stepDivisor = 10;
            double accuracy = 0.00001;
            int summandNumber = 20;
            double argument;
            double functionPrecise;
            double functionWithSummandNumber;
            double functionWithAccuracy;
            double step = (upperCeiling - lowerCeiling) / stepDivisor;
            const double exponent = Math.E;
            for (argument = lowerCeiling; argument <= upperCeiling; argument += step)
            {
                // calculating the precise value of the function + round
                functionPrecise = Math.Round(Math.Pow(exponent, Math.Cos(argument)) * Math.Cos(Math.Sin(argument)), 4);
                functionWithSummandNumber = Math.Round(CountFunctionWithSummandNumber(argument, summandNumber), 4);
                functionWithAccuracy = Math.Round(CountFunctionWithAccuracy(argument, accuracy), 4);
                Console.WriteLine("X = {0,4}    SN = {1,6}    SE = {2,6}    Y = {3,6}", Math.Round(argument, 4), functionWithSummandNumber, functionWithAccuracy, functionPrecise);
            }
        }
    }
}
