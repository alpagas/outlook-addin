using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;

namespace OAFramework.Configuration
{
    public class GlobalConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("environnement", DefaultValue = "DEV", IsRequired = true)]
        public Env Environnement
        {
            get
            {
                return (Env)Enum.Parse(typeof(Env), this["environnement"].ToString());
            }
            set
            {
                this["environnement"] = value;
            }
        }
        
        public static GlobalConfigurationSection Settings => ConfigurationManager.GetSection("globalSettings") as GlobalConfigurationSection;
    }
}
