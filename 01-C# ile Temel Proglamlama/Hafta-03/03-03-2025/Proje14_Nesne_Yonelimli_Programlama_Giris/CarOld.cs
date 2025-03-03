
namespace Proje14_Nesne_Yonelimli_Programlama_Giris
{
    class CarOld
    {
         string brand; // default'u private olarak gelir.
         string model;
         int maxSpeed;

         public void SetBrandName(string brandName)
         {
            brand = brandName.ToUpper();
         }
         public string GetBrandName()
         {
            return brand.Substring(0,3);
         }
        


    }
}