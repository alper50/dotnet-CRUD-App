using dotnetApp.Data;
using dotnetApp.Models.Interface;

namespace dotnetApp.Models.Repositories
{
    public class KullaniciRepository : IKullanici
    {
        private readonly DatabaseContext _database;
        public KullaniciRepository(DatabaseContext db)
        {
            _database = db;
        }


        public KullaniciViewModel? Find(int id)
        {
            try
            {
                var kullanici = _database.Kullanicilar.Find(id);
                return kullanici;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<KullaniciViewModel> GetAll()
        {
            try
            {
                var kullanicilar = _database.Kullanicilar.ToList();
                return kullanicilar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(KullaniciViewModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var kullanici = _database.Kullanicilar.Find(model.Id);
                    _database.Entry(kullanici).CurrentValues.SetValues(model);

                }
                else
                {
                    _database.Kullanicilar.Update(model);

                }
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

          public IEnumerable<object> GetKullaniciWithGruplar(int kullaniciId)
        {
            try
            {
                var gruplar = _database.Gruplar.ToList();
                
                var kullaniciyaAitGrupIdleri = _database.Kullanicilar.Where(p => p.Id == kullaniciId).Select(yg => yg.GrupId).ToList();
                var grupKullanicilar = gruplar.Select(grup => new
                {
                    grupId = grup.Id,
                    grupIsim = grup.GrupIsim,
                    kullaniciId = kullaniciId,
                    kullaniciyaAitmi = kullaniciyaAitGrupIdleri.Contains(grup.Id)
                }).ToList();
                return grupKullanicilar;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ChangeKullaniciGrup(int grupId, bool kullaniciyaAitmi, int kullaniciId)
        {
            try
            {
                var kullanici = _database.Kullanicilar.Find(kullaniciId);
                if (kullanici != null)
                {
                    if (kullaniciyaAitmi)
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
    }
}