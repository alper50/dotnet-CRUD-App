using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetApp.Models;

public class KullaniciViewModel{
    [Key]
    public int Id { get; set;}
    
    public string? KullaniciIsim {get; set;} 
    [ForeignKey("Grup")]
    public int? GrupId { get; set;}

}