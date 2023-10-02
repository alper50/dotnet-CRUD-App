namespace dotnetApp.Models.Interface
{
    public interface IGrup
    {
        IEnumerable<GrupViewModel> GetAll();
        GrupViewModel? Find(int id);
        void Remove(int id);
        void Update(GrupViewModel model);
        IEnumerable<Object> GetGrupWithYetkiler(int grupId);
        IEnumerable<Object> GetGrupWithKullanicilar(int grupId);
        void ChangeGrupYetki(int grupId, bool grubaAitmi,int yetkiId);
        void ChangeGrupKullanici(int grupId, bool grubaAitmi, int kullaniciId);
    }
}