﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }= Guid.NewGuid();   
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
        public bool IsDeleted { get; set; }
        
    }
}
