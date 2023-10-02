using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetApp.Models;

public class GrupViewModel{
    [Key]
    public int Id { get; set;}
    
    public string? GrupIsim {get; set;} 
}