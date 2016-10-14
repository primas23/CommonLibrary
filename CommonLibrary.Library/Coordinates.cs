// <copyright file="Coordinates.cs" company="Primas">
//     Company copyright tag.
// </copyright>
namespace CommonLibrary.Library
{
    using CommonLibrary.Contracts;

    /// <summary>
    /// Coordinates for 2D
    /// </summary>
    /// <typeparam name="T">Any struct type</typeparam>
    /// <seealso cref="CommonLibrary.Contracts.ICoordinates{T}" />
    public class Coordinates<T> : ICoordinates<T> where T : struct 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates{T}"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Coordinates(T x, T y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// Gets or sets the x coordinate
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public T X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public T Y { get; set; }
    }
}