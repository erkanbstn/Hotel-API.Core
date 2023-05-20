using Frontend_Mvc.Core.ViewModels.Count;
using Frontend_Mvc.Core.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class CountPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CountPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageTestimonial = await client.GetAsync("http://localhost:5298/api/Testimonial");
            var responseMessageRoom = await client.GetAsync("http://localhost:5298/api/Room");
            var responseMessageStaff = await client.GetAsync("http://localhost:5298/api/Staff");
            if (responseMessageTestimonial.IsSuccessStatusCode)
            {
                var jsonDataTestimonial = await responseMessageTestimonial.Content.ReadAsStringAsync();
                var jsonDataStaff = await responseMessageStaff.Content.ReadAsStringAsync();
                var jsonDataRoom = await responseMessageRoom.Content.ReadAsStringAsync();

                var roomValues = JsonConvert.DeserializeObject<List<RoomViewModel>>(jsonDataRoom);
                var staffValues = JsonConvert.DeserializeObject<List<RoomViewModel>>(jsonDataStaff);
                var testimonialValues = JsonConvert.DeserializeObject<List<RoomViewModel>>(jsonDataTestimonial);

                var count = new CountInt()
                {
                    ReferenceCount = testimonialValues.Count,
                    RoomCount = roomValues.Count,
                    StaffCount = staffValues.Count
                };
                return View(count);
            }
            return View();
        }
    }
}
