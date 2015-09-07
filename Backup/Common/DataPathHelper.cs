namespace Honey.Common
{
    public class DataPathHelper
    {
        public static string GetDataPath(string dataType)
        {
            return string.Format("D:/Projects/dot.net/HoneyProduct/Honey/Honey/Data/{0}.csv", dataType);
        }
    }
}
