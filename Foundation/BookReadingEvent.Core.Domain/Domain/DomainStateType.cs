using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.Domain.Domain
{
    public enum DomainStateType
    {
        /// <summary>
        /// The un-changed
        /// </summary>
        UnChanged = 2,
        /// <summary>
        /// The added
        /// </summary>
        Added = 4,
        /// <summary>
        /// The deleted
        /// </summary>
        Deleted = 8,
        /// <summary>
        /// The modified
        /// </summary>
        Modified = 16,
    }
}
