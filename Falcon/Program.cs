using Falcon;
using Falcon.Entities;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables();

var config = configuration.Build();

Settings settings = config.GetSection("settings").Get<Settings>();

FileReader fileReader = new(settings.ReadFrom);
ApiCaller apiCaller = new(settings.ApiKey);
var addressCoordinates = apiCaller.GetCoordinates(fileReader.Addresses.ToList());
FileWriter fileWriter = new(settings.WriteTo);
fileWriter.WriteData(addressCoordinates);