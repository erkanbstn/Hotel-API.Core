using ApiConsume.DataAccessLayer.Abstract;
using ApiConsume.DataAccessLayer.Concrete;
using ApiConsume.DataAccessLayer.Repositories;
using ApiConsume.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.DataAccessLayer.EntityFramework
{
    public class EFServiceDal : GenericRepository<Service>, IServiceDal
    {
        public EFServiceDal(Context context) : base(context)
        {
        }
    }
}
