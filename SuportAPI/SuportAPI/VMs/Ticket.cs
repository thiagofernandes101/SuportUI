using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuportAPI.VMs
{
    public class Ticket
    {
        
        public int Id { get; set; }
        public string Code { get; set; }        
        public string Description { get; set; }        
        public string Type { get; set; }
        public string Priority { get; set; }
        public DateTime OpeningDate { get; set; }        
        public DateTime? ClosingDate { get; set; }        
        public string Status { get; set; }
        public User Owner { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
