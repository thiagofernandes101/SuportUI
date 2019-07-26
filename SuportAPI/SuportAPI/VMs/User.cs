using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuportAPI.VMs
{
    public class User
    {       
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Company { get; set; }        
        public string Login { get; set; }        
        public string Password { get; set; }        
        public string Type { get; set; }
    }
}
