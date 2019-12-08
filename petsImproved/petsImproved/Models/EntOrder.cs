using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pets.Models
{
    [Table("tblOrder")]
    public class EntOrder
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string surname { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string pnone { get; set; }
        [ForeignKey("Animal")]
        public int animalId { get; set; }
        public EntAnimal Animal { get; set; }
    }
}
