using Frontend_Mvc.Core.ViewModels.Booking;
using Frontend_Mvc.Core.ViewModels.Staff;
using Frontend_Mvc.Core.ViewModels.Subscribe;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Frontend_Mvc.Core.Controllers
{
    public class MainController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MainController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Room()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }
        public IActionResult Reservation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Reservation(BookingViewModel bookingViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(bookingViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5298/api/Booking", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeViewModel subscribeViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(subscribeViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5298/api/Subscribe", content);
            return RedirectToAction("Index");
        }
    }
}
