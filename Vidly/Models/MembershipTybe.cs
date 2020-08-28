using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class MembershipTybe
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        // this to avoid using magic numbers in validation which is hard to understand by others 
        //also we can use enum for types of membership like PayAsYouGo or monthly
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}