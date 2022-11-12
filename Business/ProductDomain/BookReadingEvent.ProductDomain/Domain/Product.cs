using BookReadingEvent.Core.Domain.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookReadingEvent.ProductDomain.Domain
{
    public class Product : DomainBase
    {
        [Required()]
        [Range(1, 20, ErrorMessage = "Please enter a valid Policy Type ID")]
        public int PolicyTypeID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// The name of the product.
        /// </value>
        [Required()]
        [StringLength(50)]
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the product code.
        /// </summary>
        /// <value>
        /// The product code.
        /// </value>
        [Required()]
        [StringLength(50)]
        public string ProductCode { get; set; }

        /// <summary>
        /// Gets or sets the irda code.
        /// </summary>
        /// <value>
        /// The irda code.
        /// </value>
        [Required()]
        [StringLength(50)]
        public string IRDACode { get; set; }

        /// <summary>
        /// Gets or sets the proposal issue days limit.
        /// </summary>
        /// <value>
        /// The proposal issue days limit.
        /// </value>
        [Required()]
        [Range(1, 15, ErrorMessage = "Please enter a valid Proposal Issue Days Limit")]
        public int ProposalIssueDaysLimit { get; set; }

        /// <summary>
        /// Gets or sets the remarks.
        /// </summary>
        /// <value>
        /// The remarks.
        /// </value>
        [StringLength(100)]
        [Required]
        public string Remarks { get; set; }

        /// <summary>
        /// Called when [validate while create].
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<ValidationResult> OnValidateWhileCreate()
        {
            //Implement custom rule
            return null;
        }
    }
}
