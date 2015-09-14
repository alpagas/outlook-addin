using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OAFramework.Configuration
{
    public class ConnectionItem
    {
        public string DataBaseServerName { get; set; }
        public string DataBaseName { get; set; }

        public string DataBaseConnectionString()
        {
            return string.Format("{0};{1}", DataBaseServerName, DataBaseName);
        }
    }
}
