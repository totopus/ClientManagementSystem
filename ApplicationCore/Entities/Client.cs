using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("Client")]
    public class Client
    {
        // [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
       
        public int Id { get; set; }

        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; }
        [MaxLength(30)]
        public string? Phones { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        public DateTime? AddedOn { get; set; }

        public ICollection<Interaction> Interactions { get; set; }

    }
}
