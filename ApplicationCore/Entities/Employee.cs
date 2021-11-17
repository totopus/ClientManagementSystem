using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Employee")]
    public class Employee
    {

        public int Id { get; set; }
        
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(10)]
        public string? Password { get; set; }

        [MaxLength(50)]
        public string? Designation { get; set; }

        public ICollection<Interaction> Interactions { get; set; }
    }
}
