using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortalApp.Core
{
    public class ErrorLog : Entity
    {
        [Key]
        public override int Id { get; set; }

        public string message { get; set; }
        public string stacktrace { get; set; }
        
    }
}
