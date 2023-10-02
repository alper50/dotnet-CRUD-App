using dotnetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnetApp.Data;

public class DatabaseContext : DbContext{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options){

    }

    public DbSet<YetkiViewModel> Yetkiler {get; set;}
    public DbSet<KullaniciViewModel> Kullanicilar {get; set;}
    public DbSet<GrupViewModel> Gruplar {get; set;}
    public DbSet<YetkiGrupViewModel> YetkiGrup {get; set;}
}

//CLI'da dotnet-ef toolu kullanılarak migration yapıldı
//dotnet ef database update  
//Docker kullanılırken connectionString'te Trusted_Connection=True yerine TrustServerCertificate=True kullanılmalı