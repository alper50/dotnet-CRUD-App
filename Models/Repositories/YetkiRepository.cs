using dotnetApp.Data;
using dotnetApp.Models.Interface;
using Microsoft.Data.SqlClient;

namespace dotnetApp.Models.Repositories
{
    public class YetkiRepository : IYetki
    {
        private readonly DatabaseContext _database;
        public YetkiRepository(DatabaseContext db)
        {
            _database = db;
        }

        public void ChangeYetkiGrup(int grupId, bool yetkiyeAitmi, int yetkiId)
        {
            try
            {
                if (yetkiyeAitmi)
                {
                    var grupToDelete = _database.YetkiGrup.FirstOrDefault(g => g.YetkiId == yetkiId && g.GrupId == grupId);
                    if (grupToDelete != null)
                    {
                        _database.YetkiGrup.Remove(grupToDelete);

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

        public YetkiViewModel? Find(int id)
        {
            try
            {
                var yetki = _database.Yetkiler.Find(id);
                if (yetki != null)
                {
                    return yetki;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<YetkiViewModel> GetAll()
        {
            try
            {
                var yetkiler = _database.Yetkiler.ToList();
                return yetkiler;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<object> GetYetkiWithGruplar(int yetkiId)
        {
            try
            {
                var gruplar = _database.Gruplar.ToList();
                var yetkiyeAitGrupIdleri = _database.YetkiGrup.Where(p => p.YetkiId == yetkiId).Select(yg => yg.GrupId).ToList();
                var yetkiGrup = gruplar.Select(grup => new
                {
                    grupId = grup.Id,
                    grupIsim = grup.GrupIsim,
                    yetkiId = yetkiId,
                    yetkiyeAitmi = yetkiyeAitGrupIdleri.Contains(grup.Id)
                }).ToList();
                return yetkiGrup;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                var yetki = Find(id);
               if(yetki!=null)
               {
                 _database.Yetkiler.Remove(yetki);
               }
            }
            catch (Exception)
            {
                throw;
            }
        }

       public void Update(YetkiViewModel model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var yetki = _database.Yetkiler.Find(model.Id);
                    _database.Entry(yetki).CurrentValues.SetValues(model);

                }
                else
                {
                    _database.Yetkiler.Update(model);

                }
                _database.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}