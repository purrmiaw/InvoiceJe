using System.IO;

namespace InvoiceJe.UWP.Extensions
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            // For UWP, we store the database file in our application data's local folder.
            var path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            return Path.Combine(path, filename);
        }

        public static string GetLocalDatabasePath()
        {
            //var dbPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "exrin.db");
            var dbPath = GetLocalFilePath("invoiceje.db");
            return dbPath;
        }
    }
}
