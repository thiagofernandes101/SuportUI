using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuportAPI.VMs
{
    public class Comment
    {
        
        public int Id { get; set; }        
        public int TicketId { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        
    }
}
