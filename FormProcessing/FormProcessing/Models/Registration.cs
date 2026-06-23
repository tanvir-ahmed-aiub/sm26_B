using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;


namespace FormProcessing.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Please provide name")]
        [StringLength(100, ErrorMessage = "Name cant be more than 100")]
        public string Name { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Uname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        [Range(1,40)]
        public int Roll { get; set; }
        [Required]
        public string[] Hobbies { get; set; }
    }
}
