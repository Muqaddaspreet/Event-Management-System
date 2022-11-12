using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.Core.AppServices
{
    public enum DtoStateType
    {
        /// <summary>
        /// The unchanged
        /// </summary>
        Unchanged,
        /// <summary>
        /// The added
        /// </summary>
        Added,
        /// <summary>
        /// The modified
        /// </summary>
        Modified,
        /// <summary>
        /// The deleted
        /// </summary>
        Deleted
    }
}
