using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what28.Models
{
    public class EaterPost
    {

        //self properties
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Menu is required.")]
        public string? Menu { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Duration time is required.")]
        public int? Duration { get; set; }

        public bool? Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;


        public virtual ICollection<EaterPostAccount> EaterPostAccounts { get; set; }

        public bool isTimeout(int Duration)
        {
            TimeSpan timeElapsed = DateTime.Now - this.CreatedDate;
            return timeElapsed.TotalMinutes > Duration;
        }
    }
}
