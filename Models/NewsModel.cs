using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class NewsModel : IValidatableObject
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Link { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(Title))
            {
                errors.Add(new ValidationResult("Please enter a Title"));
            }
            if (string.IsNullOrWhiteSpace(Body))
            {
                errors.Add(new ValidationResult("Please enter a Body"));
            }
            if (PublicationDate == default)
            {
                errors.Add(new ValidationResult("Please enter a DateTime"));
            }

            return errors;
        }
    }
}
