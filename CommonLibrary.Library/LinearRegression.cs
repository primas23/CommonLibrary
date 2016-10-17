// <copyright file="LinearRegression.cs" company="Primas">
//     Company copyright tag.
// </copyright>
namespace CommonLibrary.Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CommonLibrary.Contracts;

    /// <summary>
    /// A Linear Regression algorithm implementation
    /// </summary>
    public class LinearRegression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinearRegression"/> class. This is a linear regression analysis
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <exception cref="System.ArgumentNullException">
        /// The coordinates are null!
        /// or
        /// There is null coordinate!
        /// </exception>
        public LinearRegression(IList<ICoordinates<decimal>> coordinates)
        {
            this.ValidateIfListNull(coordinates);
            this.ValidateIfThereIsNullCoordinate(coordinates);

            this.CoordinatesList = coordinates;
        }

        /// <summary>
        /// Gets or sets the coordinates list.
        /// </summary>
        /// <value>
        /// The coordinates list.
        /// </value>
        public IList<ICoordinates<decimal>> CoordinatesList { get; set; }

        /// <summary>
        /// Gets the mean of the x coordinate. It is equal to the sum of all x and divided by the count of the x.
        /// </summary>
        /// <value>
        /// The x mean.
        /// </value>
        public decimal XMean
        {
            get
            {
                return this.CoordinatesList.Sum(c => c.X) / this.CoordinatesList.Count;
            }
        }

        /// <summary>
        /// Gets the mean of the y coordinate. It is equal to the sum of all y and divided by the count of the y.
        /// </summary>
        /// <value>
        /// The y mean.
        /// </value>
        public decimal YMean
        {
            get
            {
                return this.CoordinatesList.Sum(c => c.Y) / this.CoordinatesList.Count;
            }
        }
        
        /// <summary>
        /// Gets the slope of the regression line. Sum(MultiplyXMinusAndYMinusDash) / Sum(XMinusXUpperDashSquer).
        /// </summary>
        /// <value>
        /// The slope.
        /// </value>
        public decimal Slope
        {
            get
            {
                return this.MultiplyXMinusAndYMinusDash.Sum() / this.XMinusXUpperDashSquer.Sum();
            }
        }

        /// <summary>
        /// Gets the y intersection with the regression line.
        /// </summary>
        /// <value>
        /// The y intercept.
        /// </value>
        public decimal YIntercept
        {
            get
            {
                return this.YMean - (this.Slope * this.XMean);
            }
        }

        /// <summary>
        /// Gets the standard error.
        /// </summary>
        /// <value>
        /// The standard error.
        /// </value>
        public decimal StandardError
        {
            get
            {
                List<decimal> astemMinusActualSqrt = new List<decimal>();

                for (int i = 0; i < this.CoordinatesList.Count; i++)
                {
                    decimal estimated = this.GetNextPredictedNumber(i + 1);
                    decimal actual = this.CoordinatesList[i].Y;

                    astemMinusActualSqrt.Add((estimated - actual) * (estimated - actual));
                }

                decimal sum = astemMinusActualSqrt.Sum();
                decimal count = this.CoordinatesList.Count - 2;

                return (decimal)Math.Sqrt((double)(sum / count));
            }
        }

        /// <summary>
        /// Gets the x minus x upper dash.
        /// </summary>
        /// <value>
        /// The x minus x upper dash.
        /// </value>
        private List<decimal> XMinusXUpperDash
        {
            get
            {
                return this.CoordinatesList.Select(c => c.X - this.XMean).ToList();
            }
        }

        /// <summary>
        /// Gets or sets yCap = b0 + b1 * x
        /// </summary>
        private decimal YCap { get; set; }

        /// <summary>
        /// Gets the y minus y upper dash.
        /// </summary>
        /// <value>
        /// The y minus y upper dash.
        /// </value>
        private List<decimal> YMinusYUpperDash
        {
            get
            {
                return this.CoordinatesList.Select(c => c.Y - this.YMean).ToList();
            }
        }

        /// <summary>
        /// Gets the (x - xDash)^2
        /// </summary>
        private List<decimal> XMinusXUpperDashSquer
        {
            get
            {
                return this.XMinusXUpperDash.Select(c => c * c).ToList();
            }
        }

        /// <summary>
        /// Gets the XMinusXUpperDash * YMinusYUpperDash
        /// </summary>
        private List<decimal> MultiplyXMinusAndYMinusDash
        {
            get
            {
                List<decimal> res = new List<decimal>();

                for (int i = 0; i < this.CoordinatesList.Count; i++)
                {
                    res.Add(this.XMinusXUpperDash[i] * this.YMinusYUpperDash[i]);
                }

                return res;
            }
        }

        /// <summary>
        /// Validates if list is null.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <exception cref="ArgumentNullException">The coordinates are null!</exception>
        private void ValidateIfListNull(IList<ICoordinates<decimal>> coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException("The coordinates are null!");
            }
        }

        /// <summary>
        /// Validates if there is null coordinate.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        /// <exception cref="ArgumentNullException">There is null coordinate!</exception>
        private void ValidateIfThereIsNullCoordinate(IList<ICoordinates<decimal>> coordinates)
        {
            if (coordinates.Count(c => c != null) != coordinates.Count)
            {
                throw new ArgumentNullException("There is null coordinate!");
            }
        }

        /// <summary>
        /// Gets the next predicted number y.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns>The predicted number</returns>
        public decimal GetNextPredictedNumber(decimal x)
        {
            return this.YIntercept + this.Slope * x;
        }
    }
}
