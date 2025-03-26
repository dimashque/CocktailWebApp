using System.ComponentModel.DataAnnotations;

namespace CocktailWebApp.ViewModel
{
    public class LoginViewModel
    {
        
            [Display(Name = "Email Address")]
            [DataType(DataType.EmailAddress)]
            [Required]
            public string EmailAddress { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
       
    }
}
