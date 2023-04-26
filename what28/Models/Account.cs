using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what28.Models
{
    public class Account
    {

        //self properties
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$",
        ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one number")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }


        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        // model relationship properties
        public virtual ICollection<DeliverPost> DeliverPosts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<EaterPostAccount> EaterPostAccounts { get; set; }

    }
}
