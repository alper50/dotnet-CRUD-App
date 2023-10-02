using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class KullaniciGrup : Controller
{
    private readonly ILogger<KullaniciGrup> _logger;

    private readonly IKullanici _repository;

    public KullaniciGrup(ILogger<KullaniciGrup> logger, IKullanici repository)
    {
        _logger = logger;
        _repository = repository;
    }


    public IActionResult Index(string kullaniciId)
    {
        var boxModel = new KullaniciViewModel
        {
            Id = int.Parse(kullaniciId)
        };
        return View("KullaniciGruplar", boxModel);
    }



    [HttpGet]
    public JsonResult GetKullaniciWithGruplar(int kullaniciId)
    {
        var kullaniciGruplar = _repository.GetKullaniciWithGruplar(kullaniciId);
        return Json(kullaniciGruplar);
    }

    [HttpPost]
    public IActionResult ChangeKullaniciGrup(int grupId, bool kullaniciyaAitmi, int kullaniciId)
    {
        _repository.ChangeKullaniciGrup(grupId,kullaniciyaAitmi,kullaniciId);
        var parametre = new RouteValueDictionary
            {
                { "kullaniciId", kullaniciId },
            };
        return RedirectToAction("Index", "KullaniciGrup", parametre);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
