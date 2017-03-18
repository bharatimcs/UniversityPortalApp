using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UniversityPortalApp.Core
{
    public class Student : Entity
    {
        [Key]
        public override int Id { get; set; }

        [Display(Name ="First Name")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<StudentEnrollment> StudentEnrollments { get; set; }


    }
}
