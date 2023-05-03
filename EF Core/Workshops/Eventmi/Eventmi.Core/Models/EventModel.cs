using System.ComponentModel.DataAnnotations;

namespace Eventmi.Core.Models
{
    /// <summary>
    /// Events
    /// </summary>
    public class EventModel
    {
        /// <summary>
        /// Id of event
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the event
        /// </summary>
        [Display(Name = "Name of the event")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "The field '{0}' must contain between {2} and {1} symbols")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Start date and time
        /// </summary>
        [Display(Name = "Start date and time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        public DateTime Start { get; set; }

        /// <summary>
        /// End date and time
        /// </summary>
        [Display(Name = "End date and time")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        public DateTime End { get; set; }

        /// <summary>
        /// Place of the event
        /// </summary>
        [Display(Name = "Place of the event")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field '{0}' is required!")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "The field '{0}' must contain between {2} and {1} symbols")]
        public string Place { get; set; } = null!;
    }
}
