using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class GrupKullanici : Controller
{
    private readonly ILogger<GrupKullanici> _logger;

    private readonly IGrup _repository;

    public GrupKullanici(ILogger<GrupKullanici> logger, IGrup repository)
    {
        _logger = logger;
        _repository = repository;
    }


    public IActionResult Index(string grupId)
    {
        var boxModel = new GrupViewModel
        {
            Id = int.Parse(grupId)
        };
        return View("~/Views/Grup/GrupKullanicilar.cshtml", boxModel);
    }



    [HttpGet]
    public JsonResult GetGrupWithKullanicilar(int grupId)
    {
        var grupKullanicilar = _repository.GetGrupWithKullanicilar(grupId);
        return Json(grupKullanicilar);
    }

    [HttpPost]
    public IActionResult ChangeGrupKullanici(int grupId, bool grubaAitmi, int kullaniciId)
    {
        _repository.ChangeGrupKullanici(grupId,grubaAitmi,kullaniciId);
        var parametre = new RouteValueDictionary
            {
                { "grupId", grupId },
            };
        return RedirectToAction("Index", "GrupKullanici", parametre);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
