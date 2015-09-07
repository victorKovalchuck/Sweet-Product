using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class Product : Base
    {

        [CsvColumn(FieldIndex = 2, Name = "Name")]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "ProductedDate")]
        public DateTime ProductedDate { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "Cost")]
        public int Cost { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "Recived")]
        public int Recived { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "Remains")]
        public int Remains { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "IsDefault")]
        public bool IsDefault { get; set; }
    }
}
