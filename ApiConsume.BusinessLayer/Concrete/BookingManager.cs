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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _BookingDal;

        public BookingManager(IBookingDal BookingDal)
        {
            _BookingDal = BookingDal;
        }

        public void TDelete(Booking t)
        {
            _BookingDal.Delete(t);
        }

        public Booking TGetById(int id)
        {
            return _BookingDal.GetById(id);
        }

        public List<Booking> TGetList()
        {
            return _BookingDal.GetList();
        }

        public void TInsert(Booking t)
        {
            _BookingDal.Insert(t);
        }

        public void TUpdate(Booking t)
        {
            _BookingDal.Update(t);
        }
    }
}
