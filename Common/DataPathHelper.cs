using System.Web;
namespace Honey.Common
{
    public class DataPathHelper
    {
        public static string GetDataPath(string dataType)
        {
            string serverPath = GetServerPath();
            return string.Format("{0}Data\\{1}.csv", serverPath, dataType);
          
        }
        public static string GetServerPath()
        {
            return HttpRuntime.AppDomainAppPath;
        }
    }
}
