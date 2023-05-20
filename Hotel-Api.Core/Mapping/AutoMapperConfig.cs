using ApiConsume.DtoLayer.Dtos.BookingDto;
using ApiConsume.DtoLayer.Dtos.RoomDto;
using ApiConsume.DtoLayer.Dtos.ServiceDto;
using ApiConsume.DtoLayer.Dtos.StaffDto;
using ApiConsume.DtoLayer.Dtos.SubscribeDto;
using ApiConsume.DtoLayer.Dtos.TestimonialDto;
using ApiConsume.EntityLayer.Concrete;
using AutoMapper;
namespace Hotel_Api.Core.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<RoomAddDto, Room>().ReverseMap();
            CreateMap<RoomUpdateDto, Room>().ReverseMap();

            CreateMap<ServiceAddDto, Service>().ReverseMap();
            CreateMap<ServiceUpdateDto, Service>().ReverseMap();

            CreateMap<TestimonialAddDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialUpdateDto, Testimonial>().ReverseMap();

            CreateMap<SubscribeAddDto, Subscribe>().ReverseMap();
            CreateMap<SubscribeUpdateDto, Subscribe>().ReverseMap();

            CreateMap<StaffAddDto, Staff>().ReverseMap();
            CreateMap<StaffUpdateDto, Staff>().ReverseMap();

            CreateMap<BookingAddDto, Booking>().ReverseMap();
            CreateMap<BookingUpdateDto, Booking>().ReverseMap();
        }
    }
}
