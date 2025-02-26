﻿using Karen_Store.Domain.Entities.Common;
using Karen_Store.Domain.Entities.Orders;
using Karen_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.Finance
{
    public class RequestPay:BaseEntity
    {
        public Guid Guid { get; set; }    
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
