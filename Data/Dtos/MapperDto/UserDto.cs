using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dtos.MapperDto
{
    public class UserDto
    {
        [Display(Name= "Email")]
        [Required(ErrorMessage = "{0} field required!")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "{0} field required!")]
        public string Password { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} field required!")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "{0} field required!")]
        public string Surname { get; set; }


    }
}
