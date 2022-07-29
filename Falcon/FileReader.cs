using CsvHelper;
using CsvHelper.Configuration;
using Falcon.Entities;
using System.Globalization;

namespace Falcon
{
    public class FileReader
    {
        public readonly IEnumerable<Address> Addresses;
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
            Addresses = ReadData();
        }

        private IEnumerable<Address> ReadData()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ","
            };

            using var reader = new StreamReader(_path);
            using var csv = new CsvReader(reader, config);
            var records = csv.GetRecords<Address>()
                .ToList();

            return records;
        }
    }
}
