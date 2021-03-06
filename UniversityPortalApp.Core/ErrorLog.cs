﻿using System;
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

        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string Source { get; set; }
        public string HelpLink { get; set; }
        public string InnerException { get; set; }
        //Source HelpLink InnerException
        public DateTime CreatedDate { get; set; }
        
    }
}
