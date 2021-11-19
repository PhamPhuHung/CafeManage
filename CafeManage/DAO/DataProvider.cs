using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManage.DAO
{
    public class DataProvider
    {
        #region Initialize Singleton Class
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set => instance = value;
        }

        private DataProvider() { }
        #endregion

        private string connectionSTR = "Data Source=DESKTOP-GAOH2SK;Initial Catalog=CafeManage;Integrated Security=True";
        #region Methods

        /// <summary>
        /// Get returned table of query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query, object[] parameterValues = null)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if(parameterValues!=null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string parameter in listParameter)
                    {
                        if (parameter.Contains('@'))
                        {
                            command.Parameters.AddWithValue(parameter, parameterValues[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Get number of  row AFFECTED by query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string query, object[] parameterValues = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                if (parameterValues != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string parameter in listParameter)
                    {
                        if (parameter.Contains('@'))
                        {
                            command.Parameters.AddWithValue(parameter, parameterValues[i]);
                            i++;
                        }
                    }
                }
                try
                {
                    data = command.ExecuteNonQuery();
                }
                catch(Exception e) {
                    System.Windows.Forms.MessageBox.Show(e.ToString());
                }
                connection.Close();
            }
            return data;
        }

        /// <summary>
        /// Get value of first cell of returned table of query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public object ExecuteScalar(string query, object[] parameterValues = null)
        {
            object data = null;
            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if(parameterValues != null)
                {
                    string[] listParameter = query.Split(' ');
                    int i = 0;
                    foreach (string parameter in listParameter)
                    {
                        if(parameter.Contains('@'))
                        {
                            command.Parameters.AddWithValue(parameter, parameterValues[i]);
                            i++;
                        }
                    }
                    try
                    {
                        data = command.ExecuteScalar();
                    }
                    catch { }
                }
                connection.Close();
            }
                return data;
        }
        #endregion
    }
}
