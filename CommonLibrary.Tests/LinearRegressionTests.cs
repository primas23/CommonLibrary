// <copyright file="LinearRegressionTests.cs" company="Primas">
//     Company copyright tag.
// </copyright>
namespace CommonLibrary.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

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
    }
}
