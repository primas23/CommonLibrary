// <copyright file="LinearRegressionTests.cs" company="Primas">
//     Company copyright tag.
// </copyright>
namespace CommonLibrary.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MSTestExtensions;

    using CommonLibrary.Contracts;
    using CommonLibrary.Library;
    
    /// <summary>
    /// Testing LinearRegression.cs
    /// </summary>
    [TestClass]
    public class LinearRegressionTests
    {
        /// <summary>
        /// Linear regression constructor should throw argument null exception when null list is supplied.
        /// </summary>
        [TestMethod]
        public void LinearRegressionConstructor_ShouldThrowArgumentNullException_WhenNullListIsSupplied()
        {
            ThrowsAssert.Throws<ArgumentNullException>(() => new LinearRegression(null));
        }

        /// <summary>
        /// Linear regression constructor should throw argument null exception when in list is supplied null coordinate.
        /// </summary>
        [TestMethod]
        public void LinearRegressionConstructor_ShouldThrowArgumentNullException_WhenInListIsSuppliedNullCoordinate()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                null
            };

            ThrowsAssert.Throws<ArgumentNullException>(() => new LinearRegression(coordinateses));
        }

        /// <summary>
        /// Linear regression constructor should assign correct coordinates when correct are supplied.
        /// </summary>
        [TestMethod]
        public void LinearRegressionConstructor_ShouldAssignCorrectCoordinates_WhenCorrectAreSupplied()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(coordinateses, linearRegression.CoordinatesList);
        }

        /// <summary>
        /// XMean should return correct when correct are supplied.
        /// </summary>
        [TestMethod]
        public void XMean_ShouldReturnCorrect_WhenCorrectAreSupplied()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 3),
                new Coordinates<decimal>(5, 5)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(coordinateses.Sum(c => c.X) / coordinateses.Count, linearRegression.XMean);
        }

        /// <summary>
        /// YMean should return correct when correct are supplied.
        /// </summary>
        [TestMethod]
        public void YMean_ShouldReturnCorrect_WhenCorrectAreSupplied()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 3),
                new Coordinates<decimal>(5, 5)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(coordinateses.Sum(c => c.Y) / coordinateses.Count, linearRegression.YMean);
        }

        /// <summary>
        /// Slope should return correct when correct are supplied.
        /// </summary>
        [TestMethod]
        public void Slope_ShouldReturnCorrect_WhenCorrectAreSupplied()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 1.30m),
                new Coordinates<decimal>(4, 3.75m),
                new Coordinates<decimal>(5, 2.25m)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(0.425m, linearRegression.Slope);
        }

        /// <summary>
        /// Interception should return correct when correct are supplied.
        /// </summary>
        [TestMethod]
        public void Interception_ShouldReturnCorrect_WhenCorrectAreSupplied()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 1.30m),
                new Coordinates<decimal>(4, 3.75m),
                new Coordinates<decimal>(5, 2.25m)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(0.785m, linearRegression.YIntercept);
        }

        /// <summary>
        /// Standard error should return correct coordinates when correct are supplied when there is non.
        /// </summary>
        [TestMethod]
        public void StandardError_ShouldReturnCorrectCoordinates_WhenCorrectAreSuppliedWhenThereIsNon()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 3),
                new Coordinates<decimal>(4, 4),
                new Coordinates<decimal>(5, 5)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(0, linearRegression.StandardError);
        }

        /// <summary>
        /// Standard error should return correct coordinates when correct are supplied when there is.
        /// </summary>
        [TestMethod]
        public void StandardError_ShouldReturnCorrectCoordinates_WhenCorrectAreSuppliedWhenThereIs()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 1.30m),
                new Coordinates<decimal>(4, 3.75m),
                new Coordinates<decimal>(5, 2.25m)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(0.964m, Math.Round(linearRegression.StandardError, 3));
        }

        /// <summary>
        /// Gets the next predicted number should return correct coordinates when correct are supplied.
        /// </summary>
        [TestMethod]
        public void GetNextPredictedNumber_ShouldReturnCorrectCoordinates_WhenCorrectAreSupplied()
        {
            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                new Coordinates<decimal>(1, 1),
                new Coordinates<decimal>(2, 2),
                new Coordinates<decimal>(3, 3),
                new Coordinates<decimal>(4, 4),
                new Coordinates<decimal>(5, 5)
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(6, linearRegression.GetNextPredictedNumber(6));
        }
    }
}
