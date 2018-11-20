using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSample.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Home Address")]
        public string Address { get; set; }
    }
}
