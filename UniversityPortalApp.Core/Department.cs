using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortalApp.Core
{
    public class Department : Entity
    {
        [Display(Name = "Department Name")]
        [Required]
        public string DepartmentName { get; set; }
        [Display(Name = "Head of the Department")]
        public int? HeadOfDepartmentId { get; set; }

        [ForeignKey("HeadOfDepartmentId")]
        public virtual Instructor Instructor { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Student> Students { get; set; }

        public ICollection<Instructor> Instructors { get; set; }
    }
}
