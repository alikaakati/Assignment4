using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment4_ALI_K_MOHAMAD.N.Models
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        [Required()]
        [StringLength(10, ErrorMessage = "Account number must be 10 numbers")]
        [Display(Name = "Account #")]
        public string AccountNumber { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [DataType(DataType.Currency)]
        public float Balance { get; set; }
        public virtual ApplicationUser User { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }
    }
}