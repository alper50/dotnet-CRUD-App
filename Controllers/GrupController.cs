using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class GrupController : Controller
{
    private readonly ILogger<GrupController> _logger;

    private readonly IGrup _repository;

    public GrupController(ILogger<GrupController> logger, IGrup repository)
    {
        _logger = logger;
        _repository = repository;
    }


    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public JsonResult GetGruplar()
    {
        var gruplar = _repository.GetAll();
        return Json(gruplar);

    }
    [HttpGet]
    public JsonResult GetGrup(int grupId)
    {
        var grup = _repository.Find(grupId);
        return Json(grup);
    }

    [HttpPost]
    public IActionResult UpdateGrup(GrupViewModel model)
    {
        if (ModelState.IsValid)
        {
        _repository.Update(model);
        }
        return RedirectToAction("Index", "Grup");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
