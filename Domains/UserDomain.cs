﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reservation_system.Domains
{
    [Table("user")]   
    
    public class UserDomain
    {
        [Key]
        public int id {  get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string password { get; set; }

        public string role { get; set; }
    }
}
