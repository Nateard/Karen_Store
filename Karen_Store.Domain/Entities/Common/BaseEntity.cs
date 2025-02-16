﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.Common
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; } 
        public DateTime InsertDateTime { get; set; }  = DateTime.Now;   
        public DateTime? UpdateDateTime { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsDeleted { get; set; }
    }
    public abstract class BaseEntity : BaseEntity<long>
    {

    }

}

