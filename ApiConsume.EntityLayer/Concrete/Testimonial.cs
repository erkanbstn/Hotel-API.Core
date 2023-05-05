using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.EntityLayer.Concrete
{
    public class Testimonial:BaseEntity
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string CoverImage { get; set; }
    }
}
