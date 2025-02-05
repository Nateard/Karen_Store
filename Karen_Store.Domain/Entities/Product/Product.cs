using Karen_Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.Product
{
    public class Product : BaseEntity<long>
    {
        public string Name { get; set; }
        public string Brand { get; set; }  
        public int Price { get; set; }
        public int Inventory {  get; set; }
        public bool Displayed { get; set; }
        public int ViewCount { get; set; }
        public string? Description { get; set; }
        public virtual Category Category {  get; set; } 
        public long  CategoryId { get; set; }

        public string Icon {  get; set; }
        public string? Color { get; set; }
        public string? Image { get; set; } = null;
        public string? Size {  get; set; }  
        public string? Type { get; set; } 
        

    }
    
}
