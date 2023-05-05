using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.DataAccessLayer.Abstract;
using ApiConsume.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.BusinessLayer.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _ServiceDal;

        public ServiceManager(IServiceDal ServiceDal)
        {
            _ServiceDal = ServiceDal;
        }

        public void TDelete(Service t)
        {
            _ServiceDal.Delete(t);
        }

        public Service TGetById(int id)
        {
            return _ServiceDal.GetById(id);
        }

        public List<Service> TGetList()
        {
            return _ServiceDal.GetList();
        }

        public void TInsert(Service t)
        {
            _ServiceDal.Insert(t);
        }

        public void TUpdate(Service t)
        {
            _ServiceDal.Update(t);
        }
    }
}
