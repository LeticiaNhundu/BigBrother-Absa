using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Entities
{
    [Table("emotions", Schema = "poc")]
    public class Emotions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emotion_id { get; set; }

        [Required]
        public string emotion_name { get; set; }

    }
}
