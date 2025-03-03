// namespace Proje14_Nesne_Yonelimli_Programlama_Giris
// {
//     class Car
//     {
//         private string brand; // field

//         public string Brand // Property
//         {
//             get
//             {
//                 string result = string.Empty;
//                 if(brand.Length>10)
//                 {
//                     result = brand.Substring(0,5);
//                 }
//                 else
//                 {
//                     result = brand.Substring(0,3).ToLower();
//                 }
//                 return result;
//             }
//             set{brand = value.ToUpper();}
//         }

//         private string model;
//         public string Model
//         {
//             get { return model; }
//             set { model = value; }
//         }

//         private int maxSpeed;
//         public int MaxSpeed
//         {
//             get { return maxSpeed; }
//             set 
//             {
//                 if(value<0)
//                 {
//                     maxSpeed = 100;
//                 }
//                 else
//                 {
//                     maxSpeed = value; 
//                 }
                
//             }
//         }
        
        
        
//     }
// }