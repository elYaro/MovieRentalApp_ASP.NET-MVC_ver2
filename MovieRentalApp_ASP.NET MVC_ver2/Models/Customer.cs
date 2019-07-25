﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Models
{
    public class Customer
    {
        public int Id{ get; set; }

        //[Required]
        [Required(ErrorMessage ="Please enter customer's name")]  //OVERRIDING the default error message
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Birth Date")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }



    }
}