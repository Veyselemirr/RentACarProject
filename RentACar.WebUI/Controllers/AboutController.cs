﻿using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımızda";
            ViewBag.v2 = "Vizyon ve Misyonumuz";
            return View();
        }
    }
}
