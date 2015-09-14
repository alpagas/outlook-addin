using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace OAFramework.Configuration
{
    public class DataBaseSection : ConfigurationSection
    {
        [ConfigurationProperty("fiMailCatalog", IsRequired = true)]
        public string FiMailCatalog
        {
            get
            {
                return (string)this["fiMailCatalog"];
            }
            set
            {
                this["fiMailCatalog"] = value;
            }
        }

        [ConfigurationProperty("fiMailServerName", IsRequired = true)]
        public string FiMailServerName
        {
            get
            {
                return (string)this["fiMailServerName"];
            }
            set
            {
                this["fiMailServerName"] = value;
            }
        }

        public static DataBaseSection Settings => ConfigurationManager.GetSection("dataBaseSettings") as DataBaseSection;
    }
}
