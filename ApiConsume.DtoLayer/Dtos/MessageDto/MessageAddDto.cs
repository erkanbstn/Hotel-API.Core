using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.DtoLayer.Dtos.MessageDto
{
    public class MessageAddDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
