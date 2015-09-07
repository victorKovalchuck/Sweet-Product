using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class Recipient : Base
    {
        [CsvColumn(FieldIndex = 2, Name = "Email Address")]
        public string EmailAddress { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "Is Valid")]
        public bool IsValid { get; set; }

        [CsvColumn(FieldIndex = 4, Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
