using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPortalApp.Core
{
    public class StudentEnrollment : Entity
    {
        [Key]
        public override int Id { get; set; }
        public int StudentId { get; set; }
        public int EnrollmentId { get; set; }

        public virtual Enrollment Enrollment { get; set; }
        public virtual Student Student { get; set; }
    }
}
