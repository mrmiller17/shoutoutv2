using System.ComponentModel.DataAnnotations;

namespace ShoutoutProgram.Models
{
    public class Level
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }
    }
}