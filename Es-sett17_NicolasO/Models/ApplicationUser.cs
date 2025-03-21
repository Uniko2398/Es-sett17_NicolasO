using Microsoft.AspNetCore.Identity;

namespace Es_sett17_NicolasO.Models
{
   

    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
        public string Cognome { get; set; } = string.Empty;
    }

}
