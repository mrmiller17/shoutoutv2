using System;
using System.ComponentModel.DataAnnotations;

namespace ShoutoutProgram.Models
{
    public class Event
    {
        // TODO: Apply attributes to the rest of the properties
        [Key]
        public int EventId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
        public bool IsTicker { get; set; }
    }
}