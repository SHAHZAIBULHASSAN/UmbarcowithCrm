using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UmbarcowithCrm.Models
{
    public class ContactModel
    {
             [Required]
            [Display(Name = "First Name:")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name:")]
            public string LastName { get; set; }

        [Required]
        [Display(Name = "Job Tittle:")]
        public string JobTittle { get; set; }
        [Required]
        [Display(Name = "Phone Number:")]
        public string PhoneNumber { get; set; }
        [Required]
            [EmailAddress]
            [Display(Name = "Email Address:")]
            public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Message:")]
        public string Message { get; set; }
    }
    
}