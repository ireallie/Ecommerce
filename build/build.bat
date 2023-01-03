cd ../src/Ecommerce.Api

dotnet restore
dotnet build --no-restore
dotnet publish -o ../../deploy