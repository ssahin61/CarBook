﻿using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
