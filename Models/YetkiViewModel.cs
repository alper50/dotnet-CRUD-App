using System.ComponentModel.DataAnnotations;

namespace dotnetApp.Models;

public class YetkiViewModel{
    [Key]
    public int Id { get; set;}
    
    public string? YetkiIsim {get; set;} 
    public List<YetkiViewModel> Yetkiler {get; set;} 

    public YetkiViewModel(){
        Yetkiler = new List<YetkiViewModel>();
    }

}

