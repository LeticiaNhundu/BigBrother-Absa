using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Entities
{
    [Table("person", Schema = "poc")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int person_id { get; set; }

        [Required]
        [MaxLength(10)]
        public string abnumber { get; set; }

        [Required]
        [MaxLength(30)]
        public string  name { get; set; }

        [Required]
        [MaxLength(30)]
        public string surname { get; set; }
    }
}
