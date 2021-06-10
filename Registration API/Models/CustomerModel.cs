using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Registration_API.Models
{
   
    public class CustomerModel : ICustomerInsurer
    {
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Surname { get; set; }

       
        [Required]
        [RegularExpression(@"^[A-Z]{2}[-]\d{6} *$")]
        public string PolicyReferenceNumber { get; set; }
        //Validation 
        public DateTime DateOfBirth { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]{4,99}@[a-zA-Z0-9-]{2,99}\.[\.com or co\.uk]+$")]  
        public string PolicyHolderEmailAddress { get; set; }

    }
}