﻿using Frontend_Mvc.Core.ViewModels.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Frontend_Mvc.Core.ViewComponents
{
    public class ServicePartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServicePartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5298/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ServiceViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
