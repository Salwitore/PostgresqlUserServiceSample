﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.EntityClasses
{
    [Table("ConsumeUser")]
    internal class ConsumeUser
    {
        [Key]
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
