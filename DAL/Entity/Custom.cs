using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class Custom : Base
    {
        [CsvColumn(FieldIndex = 2, Name = "Name")]
        public string Name { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "PurchaseDate")]
        public DateTime PurchaseDate { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "Number")]
        public Int64 Number { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "HoneyType")]
        public string HoneyType { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "Email")]
        public string Email { get; set; }

        [CsvColumn(FieldIndex = 7, Name = "Amount")]
        public double Amount { get; set; }
    }
}
