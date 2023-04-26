using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace what28.Models
{
    public class DeliverPost
    {

        //self properties
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Restaurant is required.")]
        public string? Restaurant { get; set; }

        [Required(ErrorMessage = "Duration time is required.")]
        public int? Duration { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string? Description { get; set; }

        public int? OpenAmount { get; set; } = 5;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool? Status { get; set; }


        // model relationship properties
        [ForeignKey("Account")]
        public int? PosterId { get; set; }
        public virtual Account? Poster { get; set; }

        public virtual ICollection<Order> Orderers { get; set; }


        public bool isTimeout(int Duration)
        {
            TimeSpan timeElapsed = DateTime.Now - this.CreatedDate;
            return timeElapsed.TotalMinutes > Duration;
        }
    }
}
