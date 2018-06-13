using System;
using System.Collections.Generic;

namespace ShoutoutProgram.Models
{
    public class MonthlySummaryViewModel
    {
        public int ShoutoutId { get; set; }

        public int TotalPoints { get; set; }

        public List<Shoutout> Shoutouts { get; set; }

        public string Recipient { get; set; }

        public IEnumerable<ApplicationUser> Recipients { get; set; }

        public DateTime DateTime { get; set; }

        public int Level { get; set; }

        public IEnumerable<Level> Levels { get; set; }

        public List<string> DistinctRecipients { get; set; }
    }
}