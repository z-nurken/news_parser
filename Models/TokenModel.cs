using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TokenModel
    {
        [Required]
        public string Access { get; set; }
        [Required]
        public string Refresh { get; set; }
    }
}
