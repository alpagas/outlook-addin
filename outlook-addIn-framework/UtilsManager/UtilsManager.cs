using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using OAFramework.Configuration;

using log4net;

namespace OAFramework
{
    public class UtilsManager
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(UtilsManager));

        private static ConnectionItem _connectionItem;

        private readonly Env _env;

        private static string _serverName;
        private static string _catalog;

        public static UtilsManager Instance;

        private Dictionary<string, IEnumerable<string>> _valuesForCombo;

        private static readonly object _syncRoot = new object();

        private UtilsManager(Env env, string serverName, string catalog)
        {
            _serverName = serverName;
            _catalog = catalog;
            this._env = env;
            _valuesForCombo = new Dictionary<string, IEnumerable<string>>();
        }

        private static ConnectionItem ConnectionItem
        {
            get
            {
                return _connectionItem
                       ?? (_connectionItem =
                           new ConnectionItem { DataBaseServerName = _serverName, DataBaseName = _catalog, });
            }
        }

        public Env Environnement
        {
            get
            {
                return this._env;
            }
        }

        protected static UtilsManager CreateInstance(Env env, string serverName, string catalog)
        {
            if (Instance == null)
            {
                lock (_syncRoot)
                {
                    if (Instance == null) Instance = new UtilsManager(env, serverName, catalog);
                }
            }
            return Instance;
        }

        public static void CreateInstance()
        {
            CreateInstance(GlobalConfigurationSection.Settings.Environnement, DataBaseSection.Settings.FiMailServerName, DataBaseSection.Settings.FiMailCatalog);
        }

        public IEnumerable<string> GetValuesForCombo(string fieldName)
        {
            if (String.IsNullOrEmpty(fieldName)) return new List<string>();
            var query = GetComboQuery(fieldName);
            
            IEnumerable<string> values;
            if(!this._valuesForCombo.TryGetValue(fieldName,out values))
            {
                values = GetListString(query, fieldName).ToList();
            }
            return values;
        }
        
        private static IEnumerable<string> GetListString(string query, string label)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(ConnectionItem.DataBaseConnectionString()))
                {
                    cn.Open();
                    var cmd = cn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            count++;
                            yield return reader[0].ToString();

                        }
                    cn.Close();
                }
            }
            finally
            {
                _logger.Info(String.Format("{0} - Read {1} records", label, count));
            }
        }

        public IEnumerable<Tuple<string, string>> GetMailAssociations(int userGroupId)
        {
           string query = @"SELECT MailScanId, MailGroupScanId FROM [dbo].[MailGroupAssociationView] where UserGroupId = "+ userGroupId;
            return GetTuples(query,"MailAssociations").ToList();
        }

        private static IEnumerable<Tuple<string,string>> GetTuples(string query, string label)
        {
            var count = 0;
            try
            {
                using (var cn = new SqlConnection(ConnectionItem.DataBaseConnectionString()))
                {
                    cn.Open();
                    var cmd = cn.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.Text;

                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                        {
                            count++;
                            yield return new Tuple<string, string>(reader[0].ToString(), reader[1].ToString());
                        }
                    cn.Close();
                }
            }
            finally
            {
                _logger.Info(String.Format("{0} - Read {1} records", label, count));
            }
        }

        private static string GetComboQuery(string fieldName)
        {
            return String.Format(
                "select ComboQueryValue from [{0}].[dbo].[ComboQuery] where FieldName = '{1}'",
                DataBaseSection.Settings.FiMailCatalog,
                fieldName);
        }
    }
}
