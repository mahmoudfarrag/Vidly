using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter Name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Display(Name="Date Of Birth")]

        [Min18YearsIfAmember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipTybe MembershipTybe { get; set; }
        [Display(Name ="Membership Type")]
        public byte MembershipTybeId { get; set; }
    }
}