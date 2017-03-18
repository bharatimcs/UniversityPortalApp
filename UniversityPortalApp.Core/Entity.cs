using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPortalApp.Core
{
    public abstract class Entity
    {
        public abstract int Id { get; set; }
    }
}
