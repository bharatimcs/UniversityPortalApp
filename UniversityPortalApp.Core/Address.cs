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
        [Key]
        public override int Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Display(Name = "Zip code")]
        [Required]
        public string Zipcode { get; set; }
        [Required]
        public string Country { get; set; }

        [Display(Name = "Student")]
        [Required]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}
