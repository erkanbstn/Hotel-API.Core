using ApiConsume.BusinessLayer.Abstract;
using ApiConsume.BusinessLayer.Concrete;
using ApiConsume.DataAccessLayer.Abstract;
using ApiConsume.DataAccessLayer.Concrete;
using ApiConsume.DataAccessLayer.EntityFramework;
using ApiConsume.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Api.Core.Extensions
{
    public static class ConfigureAPIProgram
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddDbContext<Context>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Sql"));
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAutoMapper(typeof(Program));
            services.AddCors(opt =>
            {
                opt.AddPolicy("RapidCore", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                });
            });

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

            services.AddScoped<IMessageDal, EFMessageDal>();
            services.AddScoped<IMessageService, MessageManager>();
        }
        public static WebApplication ConfigureApp(this WebApplication webApplication)
        {
            if (webApplication.Environment.IsDevelopment())
            {
                webApplication.UseSwagger();
                webApplication.UseSwaggerUI();
            }
            webApplication.UseCors("RapidCore");
            webApplication.UseAuthorization();
            webApplication.MapControllers();
            webApplication.Run();
            return webApplication;
        }
    }
}
