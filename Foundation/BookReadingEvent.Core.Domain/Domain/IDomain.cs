using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.Domain.Domain
{
    public interface IDomain
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>
        /// The unique identifier.
        /// </value>
        Guid GUID { get; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the current state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        DomainStateType State { get; set; }
    }
}
