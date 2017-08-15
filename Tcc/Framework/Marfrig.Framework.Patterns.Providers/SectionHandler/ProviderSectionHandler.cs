using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Tcc.Framework.Patterns.Providers.SectionHandler
{

    public class ProviderSectionHandler : ConfigurationSection
    {
        [ConfigurationProperty("defaultProvider")]
        public string DefaultProvider
        {
            get
            {
                return (string)base["defaultProvider"];
            }
            set
            {
                base["defaultProvider"] = value;
            }
        }

        [ConfigurationProperty("providers")]
        public ProviderSettingsCollection Providers
        {
            get
            {
                return (ProviderSettingsCollection)base["providers"];
            }
        }
    }
}
