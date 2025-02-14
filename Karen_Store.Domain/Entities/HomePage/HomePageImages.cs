using Karen_Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.HomePage
{
    public class HomePageImages : BaseEntity
    {
        public string Src { get; set; } 
        public string Link { get; set; }
        public ImageLocation Location { get; set; }
    }


    public enum ImageLocation
    {
         L1 = 1,
         L2 = 2,
         R1 = 3,
         Center= 4,
         G1 = 5, 
         G2 = 6,

    }
}
