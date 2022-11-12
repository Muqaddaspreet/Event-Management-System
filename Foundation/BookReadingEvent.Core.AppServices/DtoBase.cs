using System;

namespace BookReadingEvent.Core.AppServices
{
    public abstract class DtoBase : IDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the automatic off set.
        /// </summary>
        /// <value>The automatic off set.</value>
        public int? AutoOffSet { get; set; }

        /// <summary>
        /// Gets or sets the creation date.
        /// </summary>
        /// <value>The creation date.</value>
        public DateTimeOffset CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>The created by.</value>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>The updated date.</value>
        public DateTimeOffset? ModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>The updated by.</value>
        public int? ModifiedBy { get; set; }

        /// <summary>
        /// Gets or sets the row version.
        /// </summary>
        /// <value>The row version.</value>
        public byte[] RowVersion { get; set; }

        /// <summary>
        /// Gets or sets the state of the entity.
        /// </summary>
        /// <value>The state of the entity.</value>
        public DtoStateType EntityState { get; set; }
    }
}
