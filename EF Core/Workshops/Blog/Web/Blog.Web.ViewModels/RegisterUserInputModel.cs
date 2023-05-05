namespace Blog.Web.ViewModels.ApplicationUser
{
    using System.ComponentModel.DataAnnotations;

    using Blog.Common;

    public class RegisterUserInputModel
    {
        [Required]
        [MinLength(ValidationConstants.USERNAMEMINLENGTH)]
        [MaxLength(ValidationConstants.USERNAMEMAXLENGTH)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(ValidationConstants.EMAILMINLENGTH)]
        [MaxLength(ValidationConstants.EMAILMAXLENGTH)]
        public string Email { get; set; }

        [Required]
        [MinLength(ValidationConstants.PASSWORDMINLENGTH)]
        [MaxLength(ValidationConstants.PASSWORDMAXLENGTH)]
        public string Password { get; set; }

        [Required]
        [MinLength(ValidationConstants.PASSWORDMINLENGTH)]
        [MaxLength(ValidationConstants.PASSWORDMAXLENGTH)]
        public string PasswordConfirmation { get; set; }

    }
}