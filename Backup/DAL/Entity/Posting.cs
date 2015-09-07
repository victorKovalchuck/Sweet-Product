using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class Posting : Base
    {
        [CsvColumn(FieldIndex = 2, Name = "UserName")]
        public string UserName { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "Description")]
        public string Description { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "Show")]
        public bool Show { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "Posted Date")]
        public DateTime PostedDate { get; set; }

        [CsvColumn(FieldIndex = 6, Name = "IPAddress")]
        public string IPAddress { get; set; }

    }
}
