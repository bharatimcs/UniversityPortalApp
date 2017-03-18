using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortalApp.Core
{
    public class Course : Entity
    {
        [Key]
        public override int Id { get; set; }
        [Display(Name = "Course Name")]
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int Credits { get; set; }
        [Display(Name = "Department")]
        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
