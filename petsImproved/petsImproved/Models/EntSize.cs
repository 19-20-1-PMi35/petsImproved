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
    [Table("tblSize")]
    public class EntSize
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string size { get; set; }
        public ICollection<EntAnimal> Animals { get; set; }

        public EntSize()
        {
            Animals = new Collection<EntAnimal>();
        }
    }
}
