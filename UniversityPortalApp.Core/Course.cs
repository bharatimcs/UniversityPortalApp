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
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
