using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shreeyashclasses.Models
{
    public class User
    {
        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public string Class { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Sure Name is required")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        public string Subjects { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}