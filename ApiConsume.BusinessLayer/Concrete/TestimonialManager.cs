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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal TestimonialDal)
        {
            _TestimonialDal = TestimonialDal;
        }

        public void TDelete(Testimonial t)
        {
            _TestimonialDal.Delete(t);
        }

        public Testimonial TGetById(int id)
        {
            return _TestimonialDal.GetById(id);
        }

        public List<Testimonial> TGetList()
        {
            return _TestimonialDal.GetList();
        }

        public void TInsert(Testimonial t)
        {
            _TestimonialDal.Insert(t);
        }

        public void TUpdate(Testimonial t)
        {
            _TestimonialDal.Update(t);
        }
    }
}
