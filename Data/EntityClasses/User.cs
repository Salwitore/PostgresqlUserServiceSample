using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EntityClasses
{
    [Table("User")]
    public class User
    {
        [Key,Required]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DeletedTime { get; set; }


    }
}
