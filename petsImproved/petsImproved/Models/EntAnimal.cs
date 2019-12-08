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
    [Table("tblAnimal")]
    public class EntAnimal
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; } = "unknown";

        public byte[] image { get; set; }

        public int age { get; set; } = 0;
        [Required]
        public string sex { get; set; }
        [ForeignKey("Size")]
        public int sizeId { get; set; }
        public EntSize Size { get; set; }
        public string breed { get; set; } = "unknown";
        public string description { get; set; }
        [ForeignKey("Type")]
        public int typeId { get; set; }
        public EntType Type { get; set; }
        public ICollection<EntOrder> Orders { get; set; }

        public EntAnimal()
        {
            Orders = new Collection<EntOrder>();
        }

    }
}
