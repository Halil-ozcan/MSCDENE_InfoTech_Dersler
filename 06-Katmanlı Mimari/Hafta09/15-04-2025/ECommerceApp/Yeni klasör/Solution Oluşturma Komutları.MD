mkdir EShopApp
cd EShopApp
mkdir Backend
mkdir Frontend
cd Backend
dotnet new webapi -o Backend.API --use-controllers --no-https
dotnet new classlib -o Backend.Business
dotnet new classlib -o Backend.Data
dotnet new classlib -o Backend.Entities
dotnet new classlib -o Backend.Shared
cd ..
cd Frontend
dotnet new mvc -o Frontend.MVC --no-https
cd ..
dotnet new sln
dotnet sln add Backend/Backend.API
dotnet sln add Backend/Backend.Business
dotnet sln add Backend/Backend.Data
dotnet sln add Backend/Backend.Entities
dotnet sln add Backend/Backend.Shared
dotnet sln add Frontend/Frontend.MVC
dotnet add Backend/Backend.API reference Backend/Backend.Business
dotnet add Backend/Backend.API reference Backend/Backend.Shared
dotnet add Backend/Backend.Business reference Backend/Backend.Data
dotnet add Backend/Backend.Business reference Backend/Backend.Shared
dotnet add Backend/Backend.Data reference Backend/Backend.Entities
dotnet add Backend/Backend.Data reference Backend/Backend.Shared
dotnet add Backend/Backend.Entities reference Backend/Backend.Shared
code .