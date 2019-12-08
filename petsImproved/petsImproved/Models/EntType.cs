using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace petsImproved.Models
{
    [Table("tblType")]
    public class EntType
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string type { get; set; }
        public ICollection<EntAnimal> Animals { get; set; }

        public EntType()
        {
            Animals = new Collection<EntAnimal>();
        }

    }
}
