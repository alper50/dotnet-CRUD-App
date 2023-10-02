namespace dotnetApp.Models.Interface
{
    public interface IYetki
    {
        IEnumerable<YetkiViewModel> GetAll();
        YetkiViewModel? Find(int id);
        void Remove(int id);
        void Update(YetkiViewModel model);
        IEnumerable<Object> GetYetkiWithGruplar(int yetkiId);
        void ChangeYetkiGrup(int grupId, bool yetkiyeAitmi,int yetkiId);
    }
}