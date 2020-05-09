using Microsoft.AspNetCore.Identity;

namespace Diploma.Interfaces.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
