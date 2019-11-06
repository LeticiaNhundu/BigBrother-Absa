using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Entities
{
    [Table("team_person", Schema = "poc")]
    public class TeamPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [ForeignKey("person")]
        public int person_fk { get; set; }

        [Required]
        [ForeignKey("team")]
        public int team_fk { get; set; }

    }
}
