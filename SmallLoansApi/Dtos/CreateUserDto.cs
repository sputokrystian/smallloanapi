using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SmallLoansApi.Models.Dtos
{
    public class CreateUserDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}