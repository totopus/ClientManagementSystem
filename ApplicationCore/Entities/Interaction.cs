using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
   
    public class Interaction
    {

     
        public int Id { get; set; }
        
        public int? ClientId { get; set; }
        
        public int? EmpId { get; set; }
  
        public string? IntType { get; set; }
        public DateTime? IntDate { get; set; }
      
        public string? Remarks { get; set; }

        public Client Client { get; set; }
        public Employee Employee { get; set; }
        
        // Navigation Properties
        
    }
}
