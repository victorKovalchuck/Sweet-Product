using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class Topic : Base
    {
        private string _haseble;
        [CsvColumn(FieldIndex = 2, Name = "Code")]
        public string Code { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "Content")]
        public string Content { get; set; }
       
    }
}
