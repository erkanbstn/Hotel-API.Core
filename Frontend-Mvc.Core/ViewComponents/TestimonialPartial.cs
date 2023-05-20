using Frontend_Mvc.Core.ViewModels.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class TestimonialPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage =await client.GetAsync("http://localhost:5298/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
