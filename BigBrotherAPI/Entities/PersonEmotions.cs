using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Entities
{
    [Table("person_emotions", Schema = "poc")]
    public class PersonEmotions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("emotions")]
        public int emotion_fk { get; set; }

        [Required]
        [ForeignKey("person")]
        public int person_fk { get; set; }

        [Required]
        public double percentage { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime emotion_date { get; set; }
    }
}
