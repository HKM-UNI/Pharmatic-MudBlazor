using System.IO;
using System.Reflection;

namespace Pharmatic.Shared
{
    public class CustomIcons
    {
        public static string Search
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.search.svg");
                return svgFile;
            }
        }

        public static string Logout
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.logout.svg");
                return svgFile;
            }
        }

        public static string Notification
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.notification.svg");
                return svgFile;
            }
        }

        public static string Down
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.down.svg");
                return svgFile;
            }
        }

        private static string GetEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream ?? throw new Exception("Stream is null")))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
