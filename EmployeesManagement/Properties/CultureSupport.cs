using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;
using System.Windows.Data;

namespace EmployeeApplication.Properties
{
    public class CultureSupport
    {
        private static ObservableCollection<CultureInfo> _availableCultures;
        public static ObservableCollection<CultureInfo> AvailableCultures
        {
            get { return _availableCultures; }
            set { _availableCultures = value; }
        }

        private static ObjectDataProvider _provider;
        public static ObjectDataProvider ResourceProvider
        {
            get
            {
                if (_provider == null)
                    _provider = (ObjectDataProvider)App.Current.FindResource("Resources");
                return _provider;
            }
        }

        public CultureSupport()
        {   
            var availableLanguage = GetAvaliableLanguages();
            AvailableCultures = new ObservableCollection<CultureInfo>(availableLanguage);
        }

        private IEnumerable<CultureInfo> GetAvaliableLanguages()
        {
            var cultureInfos = new List<CultureInfo>();

            ResourceManager rm = new ResourceManager(typeof(Resources));
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (var culture in cultures)
            {
                try
                {
                    ResourceSet rs = rm.GetResourceSet(culture, true, false);
                    if (rs != null)
                        cultureInfos.Add(culture);
                }
                catch (CultureNotFoundException)
                {
                    System.Diagnostics.Debug.WriteLine(culture + " is not available on the machine or is an invalid culture identifier.");
                }
            }
            return cultureInfos;
        }

        public Resources GetResourceInstance()
        {
            return new Resources();
        }

        public static void ChangeCulture(CultureInfo culture)
        {
            if (AvailableCultures.Contains(culture))
            {
                Resources.Culture = culture;
                ResourceProvider.Refresh();
            }
            else
                System.Diagnostics.Debug.WriteLine(string.Format("Culture [{0}] not available", culture));
        }
    }
}
