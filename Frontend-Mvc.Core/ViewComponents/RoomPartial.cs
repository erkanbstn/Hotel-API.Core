﻿using Frontend_Mvc.Core.ViewModels.Room;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class RoomPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5298/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RoomViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
