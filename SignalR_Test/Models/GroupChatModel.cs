using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalR_Test.Models
{
    public class Groups
    {
        [Key]
        public string groupName { get; set; }
    }

    public class Members
    {
        [Key]
        public string name { get; set; }

        public string groupName { get; set; }

        [ForeignKey("groupName")]
        public virtual Groups Groups { get; set; }
    }
}