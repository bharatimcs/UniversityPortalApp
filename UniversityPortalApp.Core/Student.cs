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
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }


    }
}
