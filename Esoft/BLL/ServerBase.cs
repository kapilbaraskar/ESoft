using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Esoft.BLL
{
    public class ServerBase : IDisposable
    {

        #region FOR WEB USE        
        protected IDbTransaction DBTransactionObject = null;
        protected DataSet objData;

        protected SqlConnection objConnection;
        protected SqlCommand objCommand;
        protected SqlDataAdapter objAdapter;
        #endregion

        public ServerBase()
        {
            try
            {
                objConnection = new SqlConnection();
                objConnection.ConnectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();

                objCommand = new SqlCommand();
                objAdapter = new SqlDataAdapter();

                if (objConnection != null)
                {
                    if (objConnection.State != ConnectionState.Closed) objConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            if (objConnection != null)
            {
                if (objConnection.State == ConnectionState.Open) objConnection.Close();
            }
        }
    }
}