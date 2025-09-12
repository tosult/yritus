using System.Diagnostics;
using DAL.Contracts.App;
using DAL.EF.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAppUOW _uow;

    public HomeController(ILogger<HomeController> logger, IAppUOW uow)
    {
        _logger = logger;
        _uow = uow;
    }

    public async Task<IActionResult> Index()
    {
        var vm = await _uow.YritusRepository.AllAsync();
        return View(vm);
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