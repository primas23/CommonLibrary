// <copyright file="ICoordinates.cs" company="Primas">
//     Company copyright tag.
// </copyright>
namespace CommonLibrary.Contracts
{
    /// <summary>
    /// Interface for a 2D Coordinates
    ///  </summary>
    /// <typeparam name="T">Any struct</typeparam>
    public interface ICoordinates<T> where T : struct
    {
        /// <summary>
        /// Gets or sets the x coordinate
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        T X { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        T Y { get; set; }
    }
}