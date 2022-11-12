using BookReadingEvent.Core.WebMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingEvent.Web.Models
{
    public class ProductViewModel : ViewModel
    {
        [Display(Name = "Id")]
        public int ID { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please enter product name.")]
        [StringLength(50)]
        public string ProductName { get; set; }



        [Display(Name = "Policy Type ID")]
        [Required(ErrorMessage = "Please enter PlicyTypeID name.")]
        [Range(1, 20, ErrorMessage = "Please enter a valid Policy Type ID")]
        public int PolicyTypeID { get; set; }

        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "Please enter the Product Code.")]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [Display(Name = "IRDA Code")]
        [Required(ErrorMessage = "Please enter IRDACode .")]
        [StringLength(50)]
        public string IRDACode { get; set; }

        [Display(Name = "Remarks/Notes")]
        [Required(ErrorMessage = "Please enter Remarks .")]
        [StringLength(100)]
        public string Remarks { get; set; }

        [Display(Name = "Proposal Issue Days Limit")]
        [Required(ErrorMessage = "Please enter ProposalIssueDaysLimit.")]
        [Range(1, 15, ErrorMessage = "Please enter a valid Proposal Issue Days Limit")]
        public int ProposalIssueDaysLimit { get; set; }
    }
}
