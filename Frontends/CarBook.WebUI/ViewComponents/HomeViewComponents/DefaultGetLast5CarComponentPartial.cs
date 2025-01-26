﻿using CarBook.DTO.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.HomeViewComponents
{
	public class DefaultGetLast5CarComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DefaultGetLast5CarComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44345/api/Cars/GetLast5CarWithBrand");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarDto>>(jsonData);
				return View(values);
			}

			return View();
		}
	}
}
