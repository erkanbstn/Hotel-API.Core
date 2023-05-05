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
    public class StaffManager : IStaffService
    {
        private readonly IStaffDal _StaffDal;

        public StaffManager(IStaffDal StaffDal)
        {
            _StaffDal = StaffDal;
        }

        public void TDelete(Staff t)
        {
            _StaffDal.Delete(t);
        }

        public Staff TGetById(int id)
        {
            return _StaffDal.GetById(id);
        }

        public List<Staff> TGetList()
        {
            return _StaffDal.GetList();
        }

        public void TInsert(Staff t)
        {
            _StaffDal.Insert(t);
        }

        public void TUpdate(Staff t)
        {
            _StaffDal.Update(t);
        }
    }
}
