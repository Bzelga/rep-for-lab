using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SevenLab
{
    public partial class Developers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeveloperId { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual ICollection<Games> Games { get; set; }
    }
}
