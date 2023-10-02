using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetApp.Models;
using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Controllers;

public class YetkiController : Controller
{   
    private readonly ILogger<YetkiController> _logger;
    private readonly  IYetki _repository;

    public YetkiController(ILogger<YetkiController> logger, IYetki repository){
        
        _logger = logger;
        _repository=repository;
    }


    public IActionResult Index()
    {
        var yetkiler = _repository.GetAll().ToList();
        var model = new YetkiViewModel();
        model.Yetkiler = yetkiler; 
            return View(yetkiler); 
    }
     public JsonResult GetYetkiler()
    {
            var yetkiler = _repository.GetAll();
            return Json(yetkiler);
        
    }
    [HttpGet]
    public JsonResult GetYetki(int yetkiId)
    {
        var yetki = _repository.Find(yetkiId);
        return Json(yetki);
    }
    public IActionResult GetIsim(string ali){
        return null;
    }

      [HttpPost]
    public IActionResult UpdateYetki(YetkiViewModel model)
    {
        _repository.Update(model);
        return RedirectToAction("Index", "Yetki");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
