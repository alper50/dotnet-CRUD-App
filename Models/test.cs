namespace dotnetApp.Models
{
    public abstract class Isim
    {
        public string GetIsim()
        {
            return "";
        }

        public abstract string GetSoyIsim();
    }

    public sealed class SoyIsim
    {
         public string GetIsim()
        {
            return "";
        }
    }

    public interface Aile
    {

    }

    public class C 
    {


        public void nadsa(){
         var a = new SoyIsim();
        }

    }
}
