using System;
using System.Collections.Generic;
using CommonLibrary.Contracts;
using CommonLibrary.Library;

namespace CommonLibrary.ConsoleApplication1
{
    class ConsoleProgram
    {
        static void Main()
        {
            IList<ICoordinates<decimal>> list = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 3)

            };

            LinearRegression linearRegression = new LinearRegression(list);

            var xMean = linearRegression.XMean;
            var yMean = linearRegression.YMean;


            var b1 = linearRegression.Slope;
            var yInterceptionWithRegressionLine = linearRegression.YIntercept;
            var standartError = linearRegression.StandardError;



            var next = linearRegression.GetNextPredictedNumber(25);
            Console.WriteLine(next);
        }
    }
}
