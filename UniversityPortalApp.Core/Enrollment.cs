using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortalApp.Core
{
    public class Enrollment : Entity
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int InstructorId { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("InstructorId")]
        public virtual Instructor Instructor { get; set; }
    }
}
