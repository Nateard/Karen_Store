using Karen_Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.HomePage
{
    public class Slider: BaseEntity
    {
        public string Name { get; set; }
        public string Src {  get; set; }
        public string Link { get; set; }
    }
}
