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
        public static string Configuration
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.configuration.svg");
                return svgFile;
            }
        }

        public static string DashBoard
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.dashboard.svg");
                return svgFile;
            }
        }

        public static string DropBox
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.dropbox.svg");
                return svgFile;
            }
        }

        public static string EmptyWallet
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.emptywallet.svg");
                return svgFile;
            }
        }

        public static string Notepad
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.notepad.svg");
                return svgFile;
            }
        }

        public static string Client
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.client.svg");
                return svgFile;
            }
        }

        public static string Providers
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.providers.svg");
                return svgFile;
            }
        }

		public static string Bag
		{
			get
			{
				var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.bag.svg");
				return svgFile;
			}
		}
		public static string Setting
		{
			get
			{
				var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.setting3.svg");
				return svgFile;
			}
		}

        public static string HashtagDown
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.hashtagdown.svg");
                return svgFile;
            }
        }

        public static string Edit
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.edit.svg");
                return svgFile;
            }
        }

        public static string Filter
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.filter.svg");
                return svgFile;
            }
        }

        public static string Milk
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.milk.svg");
                return svgFile;
            }
        }

        public static string Tag2
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.tag2.svg");
                return svgFile;
            }
        }

        public static string ChemicalGlass
        {
            get
            {
                var svgFile = GetEmbeddedResource("Pharmatic.wwwroot.icons.chemicalglass.svg");
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
