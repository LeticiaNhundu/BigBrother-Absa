using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BigBrotherAPI.Entities
{
    [Table("teams", Schema ="poc") ]
    public class Teams
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int team_id { get; set; }

        [Required]
        public string team_name { get; set; }

    }
}
