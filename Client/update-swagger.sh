#!sh

curl "https://localhost:44312/swagger/v1/swagger.json" -o "OpenAPIs/swagger.json"
dotnet build