using BookReadingEvent.Core.AppServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookReadingEvent.ProductDomain.AppServices.DTOs
{
    public class ProductDTO : DtoBase
    {
        /// <summary>
        /// Gets or sets the policy type identifier.
        /// </summary>
        /// <value>
        /// The policy type identifier.
        /// </value>
        public int PolicyTypeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        /// <value>
        /// The product code.
        /// </value>
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the irda code.
        /// </summary>
        /// <value>
        /// The irda code.
        /// </value>
        public string IRDACode { get; set; }

        /// <summary>
        /// Gets or sets the proposal issue days limit.
        /// </summary>
        /// <value>
        /// The proposal issue days limit.
        /// </value>
        public int ProposalIssueDaysLimit { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        public string Remarks { get; set; }

    }
}
