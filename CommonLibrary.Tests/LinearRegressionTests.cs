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
    using Moq;

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
                new Mock<ICoordinates<decimal>>().Object,
                new Mock<ICoordinates<decimal>>().Object,
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
                new Mock<ICoordinates<decimal>>().Object,
                new Mock<ICoordinates<decimal>>().Object
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
            var mochCoorTwo = new Mock<ICoordinates<decimal>>();
            mochCoorTwo.SetupGet(c => c.X).Returns(2);

            var mochCoorThree = new Mock<ICoordinates<decimal>>();
            mochCoorThree.SetupGet(c => c.X).Returns(3);

            var mochCoorFive = new Mock<ICoordinates<decimal>>();
            mochCoorFive.SetupGet(c => c.X).Returns(5);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorTwo.Object,
                mochCoorThree.Object,
                mochCoorFive.Object
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
            var mochCoorTwo = new Mock<ICoordinates<decimal>>();
            mochCoorTwo.SetupGet(c => c.Y).Returns(2);

            var mochCoorThree = new Mock<ICoordinates<decimal>>();
            mochCoorThree.SetupGet(c => c.Y).Returns(3);

            var mochCoorFive = new Mock<ICoordinates<decimal>>();
            mochCoorFive.SetupGet(c => c.Y).Returns(5);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorTwo.Object,
                mochCoorThree.Object,
                mochCoorFive.Object
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
            decimal slopeResult = 0.425m;

            var mochCoorOne = new Mock<ICoordinates<decimal>>();
            mochCoorOne.SetupGet(c => c.X).Returns(1);
            mochCoorOne.SetupGet(c => c.Y).Returns(1);

            var mochCoorSecond = new Mock<ICoordinates<decimal>>();
            mochCoorSecond.SetupGet(c => c.X).Returns(2);
            mochCoorSecond.SetupGet(c => c.Y).Returns(2);

            var mochCoorThird = new Mock<ICoordinates<decimal>>();
            mochCoorThird.SetupGet(c => c.X).Returns(3);
            mochCoorThird.SetupGet(c => c.Y).Returns(1.30m);

            var mochCoorFourth = new Mock<ICoordinates<decimal>>();
            mochCoorFourth.SetupGet(c => c.X).Returns(4);
            mochCoorFourth.SetupGet(c => c.Y).Returns(3.75m);

            var mochCoorFifth = new Mock<ICoordinates<decimal>>();
            mochCoorFifth.SetupGet(c => c.X).Returns(5);
            mochCoorFifth.SetupGet(c => c.Y).Returns(2.25m);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorOne.Object,
                mochCoorSecond.Object,
                mochCoorThird.Object,
                mochCoorFourth.Object,
                mochCoorFifth.Object,
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(slopeResult, linearRegression.Slope);
        }

        /// <summary>
        /// Interception should return correct when correct are supplied.
        /// </summary>
        [TestMethod]
        public void Interception_ShouldReturnCorrect_WhenCorrectAreSupplied()
        {
            decimal interceptionResult = 0.785m;

            var mochCoorOne = new Mock<ICoordinates<decimal>>();
            mochCoorOne.SetupGet(c => c.X).Returns(1);
            mochCoorOne.SetupGet(c => c.Y).Returns(1);

            var mochCoorSecond = new Mock<ICoordinates<decimal>>();
            mochCoorSecond.SetupGet(c => c.X).Returns(2);
            mochCoorSecond.SetupGet(c => c.Y).Returns(2);

            var mochCoorThird = new Mock<ICoordinates<decimal>>();
            mochCoorThird.SetupGet(c => c.X).Returns(3);
            mochCoorThird.SetupGet(c => c.Y).Returns(1.30m);

            var mochCoorFourth = new Mock<ICoordinates<decimal>>();
            mochCoorFourth.SetupGet(c => c.X).Returns(4);
            mochCoorFourth.SetupGet(c => c.Y).Returns(3.75m);

            var mochCoorFifth = new Mock<ICoordinates<decimal>>();
            mochCoorFifth.SetupGet(c => c.X).Returns(5);
            mochCoorFifth.SetupGet(c => c.Y).Returns(2.25m);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorOne.Object,
                mochCoorSecond.Object,
                mochCoorThird.Object,
                mochCoorFourth.Object,
                mochCoorFifth.Object,
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(interceptionResult, linearRegression.YIntercept);
        }

        /// <summary>
        /// Standard error should return correct coordinates when correct are supplied when there is non.
        /// </summary>
        [TestMethod]
        public void StandardError_ShouldReturnCorrectCoordinates_WhenCorrectAreSuppliedWhenThereIsNon()
        {
            var mochCoorOne = new Mock<ICoordinates<decimal>>();
            mochCoorOne.SetupGet(c => c.X).Returns(1);
            mochCoorOne.SetupGet(c => c.Y).Returns(1);

            var mochCoorSecond = new Mock<ICoordinates<decimal>>();
            mochCoorSecond.SetupGet(c => c.X).Returns(2);
            mochCoorSecond.SetupGet(c => c.Y).Returns(2);

            var mochCoorThird = new Mock<ICoordinates<decimal>>();
            mochCoorThird.SetupGet(c => c.X).Returns(3);
            mochCoorThird.SetupGet(c => c.Y).Returns(3);

            var mochCoorFourth = new Mock<ICoordinates<decimal>>();
            mochCoorFourth.SetupGet(c => c.X).Returns(4);
            mochCoorFourth.SetupGet(c => c.Y).Returns(4);

            var mochCoorFifth = new Mock<ICoordinates<decimal>>();
            mochCoorFifth.SetupGet(c => c.X).Returns(5);
            mochCoorFifth.SetupGet(c => c.Y).Returns(5);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorOne.Object,
                mochCoorSecond.Object,
                mochCoorThird.Object,
                mochCoorFourth.Object,
                mochCoorFifth.Object,
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
            decimal standartErrorResult = 0.964m;

            var mochCoorOne = new Mock<ICoordinates<decimal>>();
            mochCoorOne.SetupGet(c => c.X).Returns(1);
            mochCoorOne.SetupGet(c => c.Y).Returns(1);

            var mochCoorSecond = new Mock<ICoordinates<decimal>>();
            mochCoorSecond.SetupGet(c => c.X).Returns(2);
            mochCoorSecond.SetupGet(c => c.Y).Returns(2);

            var mochCoorThird = new Mock<ICoordinates<decimal>>();
            mochCoorThird.SetupGet(c => c.X).Returns(3);
            mochCoorThird.SetupGet(c => c.Y).Returns(1.30m);

            var mochCoorFourth = new Mock<ICoordinates<decimal>>();
            mochCoorFourth.SetupGet(c => c.X).Returns(4);
            mochCoorFourth.SetupGet(c => c.Y).Returns(3.75m);

            var mochCoorFifth = new Mock<ICoordinates<decimal>>();
            mochCoorFifth.SetupGet(c => c.X).Returns(5);
            mochCoorFifth.SetupGet(c => c.Y).Returns(2.25m);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorOne.Object,
                mochCoorSecond.Object,
                mochCoorThird.Object,
                mochCoorFourth.Object,
                mochCoorFifth.Object,
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(standartErrorResult, Math.Round(linearRegression.StandardError, 3));
        }

        /// <summary>
        /// Gets the next predicted number should return correct coordinates when correct are supplied.
        /// </summary>
        [TestMethod]
        public void GetNextPredictedNumber_ShouldReturnCorrectCoordinates_WhenCorrectAreSupplied()
        {
            var mochCoorOne = new Mock<ICoordinates<decimal>>();
            mochCoorOne.SetupGet(c => c.X).Returns(1);
            mochCoorOne.SetupGet(c => c.Y).Returns(1);

            var mochCoorSecond = new Mock<ICoordinates<decimal>>();
            mochCoorSecond.SetupGet(c => c.X).Returns(2);
            mochCoorSecond.SetupGet(c => c.Y).Returns(2);

            var mochCoorThird = new Mock<ICoordinates<decimal>>();
            mochCoorThird.SetupGet(c => c.X).Returns(3);
            mochCoorThird.SetupGet(c => c.Y).Returns(3);

            var mochCoorFourth = new Mock<ICoordinates<decimal>>();
            mochCoorFourth.SetupGet(c => c.X).Returns(4);
            mochCoorFourth.SetupGet(c => c.Y).Returns(4);

            var mochCoorFifth = new Mock<ICoordinates<decimal>>();
            mochCoorFifth.SetupGet(c => c.X).Returns(5);
            mochCoorFifth.SetupGet(c => c.Y).Returns(5);

            IList<ICoordinates<decimal>> coordinateses = new List<ICoordinates<decimal>>
            {
                mochCoorOne.Object,
                mochCoorSecond.Object,
                mochCoorThird.Object,
                mochCoorFourth.Object,
                mochCoorFifth.Object,
            };

            LinearRegression linearRegression = new LinearRegression(coordinateses);

            Assert.AreEqual(6, linearRegression.GetNextPredictedNumber(6));
        }
    }
}
