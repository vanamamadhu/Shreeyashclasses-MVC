using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shreeyashclasses.Models
{
    public class Question
    {
        [Required]
        public string QuestionName { get; set; }

        [Required]
        public string OptionOne { get; set; }

        [Required]
        public string OptionTwo { get; set; }

        [Required]
        public string OptionThree { get; set; }

        [Required]
        public string OptionFour { get; set; }

        [Required]
        public string Answer { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}