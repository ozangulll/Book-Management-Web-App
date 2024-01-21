using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Book_Store.Models;

namespace Book_Store.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

   public IActionResult Index()
{
    ViewData["img1"] = "~/images/im1.jpg";
    ViewData["img2"] = "~/images/im2.jpg";
    ViewData["img3"] = "~/images/im3.jpg";

    return View();
}

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}