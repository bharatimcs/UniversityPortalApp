using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityPortalApp.Core;

namespace UniversityPortalApp.Web.Models
{
    public class StudentEnrollmentViewModel : Enrollment
    {
        public bool Enrolled { get; set; }
    }
}