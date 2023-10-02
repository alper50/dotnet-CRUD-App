using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetApp.Models;

public class YetkiGrupViewModel{
    [Key]
    public int Id { get; set;}
    [ForeignKey("Yetki")]
    public int YetkiId {get; set;} 
    [ForeignKey("Grup")]
    public int GrupId { get; set;}

}