using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Models.Repositories
{
    public class GrupRepository : IGrup
    {
        private readonly DatabaseContext _database;
        public GrupRepository(DatabaseContext db)
        {
            _database = db;
        }

        public void ChangeGrupKullanici(int grupId, bool grubaAitmi, int kullaniciId)
        {
            try
            {
                var kullanici = _database.Kullanicilar.Find(kullaniciId);
                if (kullanici != null)
                {
                    if (grubaAitmi)
                    {

                        kullanici.GrupId = null;
                        _database.Kullanicilar.Update(kullanici);
                        
                    }
                    else
                    {

                        kullanici.GrupId = grupId;
                        _database.Kullanicilar.Update(kullanici);
                        
                    }
                    _database.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ChangeGrupYetki(int grupId, bool grubaAitmi, int yetkiId)
        {
            try
            {
                if (grubaAitmi)
                {
                    var yetkiToDelete = _database.YetkiGrup.FirstOrDefault(g => g.YetkiId == yetkiId && g.GrupId == grupId);
                    if (yetkiToDelete != null)
                    {
                        _database.YetkiGrup.Remove(yetkiToDelete);
                        
                    }

                }
                else
                {
                    var grupToAdd = new YetkiGrupViewModel();
                    grupToAdd.YetkiId = yetkiId;
                    grupToAdd.GrupId = grupId;
                    _database.YetkiGrup.Add(grupToAdd);
                    
                }
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public GrupViewModel? Find(int id)
        {
            try
            {
                var grup = _database.Gruplar.Find(id);
                return grup;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<GrupViewModel> GetAll()
        {
            try
            {
                var gruplar = _database.Gruplar.ToList();
                return gruplar;
            }
            catch (Exception)
            { throw; }
        }

        public IEnumerable<object> GetGrupWithKullanicilar(int grupId)
        {
            try
            {
                var kullanicilar = _database.Kullanicilar.ToList();
                var grubaAitKullaniciIdleri = _database.Kullanicilar.Where(p => p.GrupId == grupId).Select(yg => yg.Id).ToList();
                var grupKullanicilar = kullanicilar.Select(kullanici => new
                {
                    kullaniciId = kullanici.Id,
                    kullaniciIsim = kullanici.KullaniciIsim,
                    grupId = grupId,
                    grubaAitmi = grubaAitKullaniciIdleri.Contains(kullanici.Id)
                }).ToList();
                return grupKullanicilar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<object> GetGrupWithYetkiler(int grupId)
        {
            try{
                  var yetkiler = _database.Yetkiler.ToList();
        //gelen yetkiId sine ait olan grupların Idlerini listeler
        var grubaAitYetkiIdleri = _database.YetkiGrup.Where(p => p.GrupId == grupId).Select(yg => yg.YetkiId).ToList();
        var grupYetki = yetkiler.Select(yetki => new
        {   
            yetkiId = yetki.Id,
            yetkiIsim = yetki.YetkiIsim,
            grupId = grupId,
            grubaAitmi = grubaAitYetkiIdleri.Contains(yetki.Id)
        }).ToList();
        return grupYetki;
            }
            catch(Exception){throw;}
        }

        public void Remove(int id)
        {
            try{
                var grupToDelete = Find(id);
                if(grupToDelete!=null)
                {   
                    _database.Gruplar.Remove(grupToDelete);
                }
                
            }
            catch(Exception){throw;}
        }

        public void Update(GrupViewModel model)
        {
            try{
                if (model.Id == 0)
            {
                var grup = _database.Gruplar.Find(model.Id);
                _database.Entry(grup).CurrentValues.SetValues(model);

            }
            else
            {
                _database.Gruplar.Update(model);

            }
            _database.SaveChanges();
            }
            catch(Exception){throw;}
        }
    }
}