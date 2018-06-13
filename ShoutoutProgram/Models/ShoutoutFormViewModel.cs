using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoutoutProgram.Models
{
    public class ShoutoutFormViewModel
    {
        public int ShoutoutId { get; set; }

        public string Recipient { get; set; }

        public IEnumerable<ApplicationUser> Recipients { get; set; }

        [Required]
        [StringLength(100)]
        public string Giver { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int Level { get; set; }

        public IEnumerable<Level> Levels { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string Description { get; set; }
    }
}