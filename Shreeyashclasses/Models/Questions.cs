using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shreeyashclasses.Models
{
    public class Questions
    {
        public string Question { get; set; }

        public string OptionOne { get; set; }

        public string OptionTwo { get; set; }

        public string OptionThree { get; set; }

        public string OptionFour { get; set; }

        public string Answer { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}