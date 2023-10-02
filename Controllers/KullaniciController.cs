using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class KullaniciController : Controller
{
    private readonly ILogger<KullaniciController> _logger;
    private readonly DatabaseContext _database;

    private readonly IKullanici _repository;

    public KullaniciController(DatabaseContext db, ILogger<KullaniciController> logger, IKullanici repository)
    {
        _database = db;
        _logger = logger;
        _repository = repository;
    }


    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public JsonResult GetKullanicilar()
    {
        var kullanicilar = _repository.GetAll();
        return Json(kullanicilar);

    }
    [HttpGet]
    public JsonResult GetKullanici(int kullaniciId)
    {
        var kullanici = _repository.Find(kullaniciId);
        return Json(kullanici);
    }

    [HttpPost]
    public IActionResult UpdateKullanici(KullaniciViewModel model)
    {
        if (ModelState.IsValid)
        {
            _repository.Update(model);

        }
        return RedirectToAction("Index", "Kullanici");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
