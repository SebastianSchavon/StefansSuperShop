using System.ComponentModel.DataAnnotations;

namespace StefansSuperShop.ViewModels;

public class NewsletterViewModel
{
    [Required(ErrorMessage = "Email address required")]
    public string EmailAddress { get; set; }
}