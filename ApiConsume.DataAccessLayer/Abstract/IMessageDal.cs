﻿using ApiConsume.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
    }
}
