using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OAFramework.Configuration
{
    public class OADBManager
    {
        public static OADBManager Instance;
        private static object syncRoot = new Object();
        public OAObjectsContext DBContext;

        private OADBManager()
        {
            DBContext = new OAObjectsContext();
            UtilsManager.CreateInstance();
        }

        public static OADBManager CreateInstance()
        {
            if (Instance == null)
            {
                lock (syncRoot)
                {
                    if (Instance == null)
                        Instance = new OADBManager();
                }
            }
            return Instance;
        }
    } 
}
