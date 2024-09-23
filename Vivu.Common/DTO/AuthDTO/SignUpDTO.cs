using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vivu.Common.DTO.AuthDTO
{
    public class SignUpDTO
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        public SignUpDTO() { }

        public SignUpDTO(string fullname, string address, string phoneNumber, string email, string password)
        {
            Fullname = fullname;
            PhoneNumber = phoneNumber;
            Password = password;
            Email = email;
        }
    }
}
