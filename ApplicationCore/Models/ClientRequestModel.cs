using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Models
{
    public class ClientRequestModel
    {
        public int Id { get; set; }

      
        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Phones { get; set; }
       
        public string? Address { get; set; }
        public DateTime? AddedOn { get; set; }

        
    }
}
