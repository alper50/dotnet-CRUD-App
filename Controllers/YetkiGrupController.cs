using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class YetkiGrupController : Controller
{
    private readonly ILogger<YetkiGrupController> _logger;

    private readonly IYetki _repository;

    public YetkiGrupController(ILogger<YetkiGrupController> logger, IYetki repository)
    {
        _logger = logger;
        _repository=repository;
    }


    public IActionResult Index(int yetkiId)
    {
       var boxModel = new YetkiViewModel
        {
            Id = yetkiId
        };
        return View("YetkiGruplar", boxModel);
    }


    [HttpGet]
    public JsonResult GetYetkiWithGruplar(int yetkiId)
    {
        var yetkiGrup = _repository.GetYetkiWithGruplar(yetkiId);
        return Json(yetkiGrup);
    }

    [HttpPost]
    public IActionResult ChangeYetkiGrup(int grupId, bool yetkiyeAitmi,int yetkiId)
    {
        
       _repository.ChangeYetkiGrup(grupId,yetkiyeAitmi,yetkiId);
        var parametre = new RouteValueDictionary
            {
                { "yetkiId", yetkiId },
            };
        
        return RedirectToAction("Index","YetkiGrup",parametre);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
