using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Users_Api.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Lastname cannot be longer than 30 characters and less than 3 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3,
            ErrorMessage = "Lastname cannot be longer than 30 characters and less than 3 characters")]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8,
            ErrorMessage = "Password cannot be longer than 20 characters and less than 8 characters")]
        public string Password { get; set; }
    }
}
