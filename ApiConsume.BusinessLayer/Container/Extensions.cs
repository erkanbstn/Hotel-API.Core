using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.BusinessLayer.Concrete;
using ApiConsume.DataAccessLayer.Abstract;
using ApiConsume.DataAccessLayer.Concrete;
using ApiConsume.DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiConsume.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStaffDal, EFStaffDal>();
            services.AddScoped<IStaffService, StaffManager>();

            services.AddScoped<IRoomDal, EFRoomDal>();
            services.AddScoped<IRoomService, RoomManager>();

            services.AddScoped<ITestimonialDal, EFTestimonialDal>();
            services.AddScoped<ITestimonialService, TestimonialManager>();

            services.AddScoped<IServiceDal, EFServiceDal>();
            services.AddScoped<IServiceService, ServiceManager>();

            services.AddScoped<ISubscribeDal, EFSubscribeDal>();
            services.AddScoped<ISubscribeService, SubscribeManager>();

            services.AddScoped<IBookingDal, EFBookingDal>();
            services.AddScoped<IBookingService, BookingManager>();

            services.AddDbContext<Context>();
        }
    }
}
