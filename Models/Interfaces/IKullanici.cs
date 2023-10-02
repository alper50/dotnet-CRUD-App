namespace dotnetApp.Models.Interface
{
    public interface IKullanici
    {
        IEnumerable<KullaniciViewModel> GetAll();
        KullaniciViewModel? Find(int id);
        void Update(KullaniciViewModel model);
        public IEnumerable<object> GetKullaniciWithGruplar(int kullaniciId);
        public void ChangeKullaniciGrup(int grupId, bool kullaniciyaAitmi, int kullaniciId);

    }
}