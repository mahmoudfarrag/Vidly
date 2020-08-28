using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }
     

        //[Min18YearsIfAmember]
        public DateTime? Birthdate { get; set; }
        public MembershipTypeDto MembershipTybe { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public byte MembershipTybeId { get; set; }
    }
}