﻿using Microsoft.AspNetCore.Mvc;

namespace RentACar.WebUI.ViewComponents.UILayoutViewComponents;

public class _HeadLayoutComponentPartial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
