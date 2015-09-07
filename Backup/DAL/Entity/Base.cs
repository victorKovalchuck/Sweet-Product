using LINQtoCSV;

namespace Honey.DAL.Entity
{
    public class Base
    {
        [CsvColumn(FieldIndex = 1, Name = "Id")]
        public int Id { get; set; }
    }
}