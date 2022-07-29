using CsvHelper;
using Falcon.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon
{
    public class FileWriter
    {
        private readonly string _path;
        public FileWriter(string path)
        {
            _path = path;
        }

        public void WriteData(List<AddressCoordinate> addressCoordinates)
        {
            using (var writer = new StreamWriter(_path))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.WriteRecords(addressCoordinates);
            }
        }
    }
}
