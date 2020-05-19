using System.ComponentModel.DataAnnotations;

namespace ExampleWebApplication.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}