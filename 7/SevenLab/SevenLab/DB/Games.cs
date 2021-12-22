using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SevenLab
{
    public partial class Games
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GamesId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public int DeveloperId { get; set; }
        [ForeignKey("DeveloperId")]
        public Developers Developer { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
