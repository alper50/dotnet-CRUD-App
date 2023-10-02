using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class GrupYetkiController : Controller
{
    private readonly ILogger<GrupYetkiController> _logger;

    private readonly IGrup _repository;

    public GrupYetkiController(ILogger<GrupYetkiController> logger,IGrup repository)
    {
        _logger = logger;
        _repository = repository;
    }


    public IActionResult Index(int grupId)
    {
        var boxModel = new GrupViewModel
        {
            Id = grupId
        };
        return View("~/Views/Grup/GrupYetkiler.cshtml", boxModel);
    }


    [HttpGet]
    public JsonResult GetGrupWithYetkiler(int grupId)
    {
        var grupYetki = _repository.GetGrupWithYetkiler(grupId);
        return Json(grupYetki);
    }

    [HttpPost]
    public IActionResult ChangeGrupYetki(int grupId, bool grubaAitmi,int yetkiId)
    {
        
       _repository.ChangeGrupYetki(grupId,grubaAitmi,yetkiId);
         var parametre = new RouteValueDictionary
            {
                { "grupId", grupId },
            };
        return RedirectToAction("Index","GrupYetki",parametre);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
