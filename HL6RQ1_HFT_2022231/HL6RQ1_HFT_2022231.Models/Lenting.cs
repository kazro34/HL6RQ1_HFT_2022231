using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Models
{
    [Table("Lenting")]
    public class Lenting 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Out { get; set; }
        public string In { get; set; }

        [NotMapped]
        public virtual Book Book { get; set; }

        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        
    }
}
