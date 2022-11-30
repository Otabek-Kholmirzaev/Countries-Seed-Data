using Newtonsoft.Json;
using System.Text;
using TetstSeedData;

var data = JsonConvert
           .DeserializeObject<IEnumerable<dynamic>>(File
           .ReadAllText("C:\\Users\\User\\source\\repos\\TetstSeedData\\TetstSeedData\\data.json"));

var result = data?.Select(x =>
{
    var guid = Guid.NewGuid();

    return (new Location
    {
        Guid = guid,
        Name = x.name,
        Type = LocationType.Country.ToString()
    },
    new LocationDetails
    {
        PhoneNumberCode = x.phone,
        LocationGuid = guid,
    });
}).ToList();

var countries = result?.Select(x => x.Item1);
var countriesDetail = result?.Select(x => x.Item2);

var path = "C:\\Users\\User\\source\\repos\\TetstSeedData\\TetstSeedData";
var countriesPath = Path.Combine(path, "Countries.json");
var countriesDetailPath = Path.Combine(path, "CountriesDetails.json");

File.WriteAllText(countriesPath, JsonConvert.SerializeObject(countries));
File.WriteAllText(countriesDetailPath, JsonConvert.SerializeObject(countriesDetail));
