using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortalApp.Core
{
    public class Address : Entity
    {
        public string Street { get; set; }

        public string Unit { get; set; }
        public string City { get; set; }
        
        public string State { get; set; }
        public int Zipcode { get; set; }

        public string Country { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
