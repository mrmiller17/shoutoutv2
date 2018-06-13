using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoutoutProgram.Models
{
    public class Shoutout
    {
        // Table key
        public int ShoutoutId { get; set; }

        // User properties
        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        // Recipient properties
        public ApplicationUser Recipient { get; set; }

        public string RecipientId { get; set; }

        public IEnumerable<ApplicationUser> Recipients { get; set; }

        // Other properties
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [StringLength(100)]
        public string Project { get; set; }

        // Level properties (weighted value)
        public Level Level { get; set; }

        public int LevelId { get; set; }

        public IEnumerable<Level> Levels { get; set; }

        // Description property, multiline textbox
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}