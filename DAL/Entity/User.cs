using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class User : Base
    {
        [CsvColumn(FieldIndex = 2, Name = "UserName")]
        public string UserName { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "Password")]
        public string Password { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "Is Active")]
        public bool IsActive { get; set; }       
    }
}
