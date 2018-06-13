using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ShoutoutProgram.Models
{
    /* These classes are no longer being used due to DateTime
     * being pulled automatically at creation of the shoutout. */
    public class ValidDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var IsValid = DateTime.TryParseExact(Convert.ToString(value),
                "dd MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (IsValid);
        }
    }

    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var IsValid = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm tt",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);

            return (IsValid);
        }
    }
}