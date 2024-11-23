﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthSphere.Model
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "First Name is required")]
        public string ?FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string ?LastName { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        public string ?EmailId { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        public string ?PhoneNumber { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string ?Password { get; set; }
    }
}