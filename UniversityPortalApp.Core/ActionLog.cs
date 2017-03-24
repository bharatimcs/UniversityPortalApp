using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityPortalApp.Core
{
    ///TODO: Track down the action url, action method type, if method is POST get the post data
    public class ActionLog:Entity
    {
        [Key]
        public override int Id { get; set; }

        public string Controller { get; set; }
        public string Action { get; set; }
        public string IP { get; set; }
        public DateTime Date { get; set; }
    }
}
