using Karen_Store.Domain.Entities.Common;
using Karen_Store.Domain.Entities.Finance;
using Karen_Store.Domain.Entities.Products;
using Karen_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.Orders
{
    public class Order:BaseEntity
    {
        public virtual User User { get; set; }
        public long UserId { get; set; }    
        public virtual RequestPay RequestPay {  get; set; } 
        public long RequestPayId { get; set; }

        public OrderState order { get; set; }
        
        public string Address { get; set; }
    }

    public class OrderDetail:BaseEntity
    {
        public virtual Order Order { get; set; }
        public long OrderId { get; set; } 
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; } 
        public int price { get; set; }
    }

    public enum OrderState
    {
        Proccesing = 0,
        Cancled = 1,
        Delivered = 2,
    }
}
