using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using log4net;
using System.Configuration;
using log4net.Config;

namespace PTIC.Common
{
    public class DBManager
    {
        /// <summary>
        /// Logger for DBManager
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(DBManager));

        #region Private Member Variables
        private static DBManager _dbInstance = null;
        //private static readonly string ConnStringName = "PTICConnectionString";
        private static readonly string ConnStringName = "PTIC.Properties.Settings.PTICConnectionString";
        private static string _conString = string.Empty;                
        private readonly SqlConnection conn = new SqlConnection(_conString);
        #endregion

        #region Private Properties
        #endregion

        #region Private Methods
        private static string GetConnectionStringByName(string name)
        {
            string returnVal = null;

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnVal = settings.ConnectionString;
            return returnVal;
        }

        private static string GetConnectionStringByProvider(string providerName)
        {
            string returnVal = null;

            ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    if (cs.ProviderName == providerName)
                    {
                        returnVal = cs.ConnectionString;
                        break;
                    }
                }
            }
            return returnVal;
        }

        // TODO: Protected Configuration Providers
        #endregion

        #region Constructors
        private DBManager() { }
        #endregion

        #region Public Properties
        #endregion

        #region Public Methods
        //public static DBManager GetInstance_bak()
        //{
        //    if (_dbInstance == null)
        //    {
        //        var settingFile = Assembly.GetExecutingAssembly().GetManifestResourceStream("PTIC.Setting.xml");
        //        DataSet ds = new DataSet();
        //        // read xml stream
        //        ds.ReadXml(settingFile);
        //        // set connection string
        //        DataRow row = ds.Tables["DatabaseConfig"].Rows[0];
        //        _conString = "Data Source=" + row["Server"];
        //        _conString += ";Initial Catalog=" + row["Database"];
        //        _conString += ";User ID=" + row["UserName"];
        //        _conString += ";Password=" + row["Password"];
        //        _conString += ";Network Library=DBMSSOCN";
        //        _conString += ";MultipleActiveResultSets=True;";
        //        // initiate db manager
        //        _dbInstance = new DBManager();

        //        // Configure logger
        //        XmlConfigurator.Configure();
        //    }
        //    return _dbInstance;
        //}

        public static DBManager GetInstance()
        {
            if (_dbInstance == null)
            {
                _conString = GetConnectionStringByName(ConnStringName);
                // initiate db manager
                _dbInstance = new DBManager();
                // Configure logger
                XmlConfigurator.Configure();
            }
            return _dbInstance;
        }

        public SqlConnection GetDbConnection()
        {
            try
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                conn.Open();
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                _logger.Error(conn);
                throw new Exception("Please check your network setting or database.\r\nError Number : " + sqle.Number);
                
            }
            return conn;
        }

        public void CloseDbConnection()
        {
            try
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (SqlException sqle)
            {
                _logger.Error(sqle);
                // TODO: handle error    
                //ToastMessageBox.Show(Resource.errDBorNet + "\r\nError Code : " + sqle.ErrorCode);
            }
        }
        #endregion
    }
}
