using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HL6RQ1_HFT_2022231.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int LentingFee { get; set; }

        [NotMapped]
        public virtual Author Author { get; set; }

        [ForeignKey(nameof(Author))]
        public int AuthorId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Lenting> Lentings { get; set; }

        public Book()
        {

        }
    }
}
