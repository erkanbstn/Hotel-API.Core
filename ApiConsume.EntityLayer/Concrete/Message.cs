using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.EntityLayer.Concrete
{
    public class Message : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
