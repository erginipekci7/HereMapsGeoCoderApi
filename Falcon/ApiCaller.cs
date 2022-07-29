using Falcon.Entities;
using Newtonsoft.Json;

namespace Falcon
{
    public class ApiCaller
    {
        private readonly string _apikey;

        public ApiCaller(string apikey)
        {
            _apikey = apikey;
        }

        public List<AddressCoordinate> GetCoordinates(List<Address> addresses)
        {
            List<AddressCoordinate> addressCoordinates = new();

            foreach (var address in addresses)
            {
                using var client = new HttpClient();
                var baseUri = $"https://geocoder.ls.hereapi.com/6.2/geocode.json?apiKey={_apikey}&searchtext=";
                var result = client.GetAsync(baseUri + address.AddressName).Result.Content
                    .ReadAsStringAsync().Result;

                dynamic? test = JsonConvert.DeserializeObject(result);

                if (test?.Response.View.Count == 0)
                {
                    addressCoordinates.Add(new()
                    {
                        Id = address.Id,
                        Address = address.AddressName,
                        Longtitude = 0,
                        Latitude = 0
                    });

                    continue;
                }

                var displayPosition = test?.Response.View[0].Result[0].Location.DisplayPosition;

                addressCoordinates.Add(new()
                {
                    Id = address.Id,
                    Address = address.AddressName,
                    Longtitude = displayPosition?.Longitude,
                    Latitude = displayPosition?.Latitude
                });

            }

            return addressCoordinates;
        }
    }
}
