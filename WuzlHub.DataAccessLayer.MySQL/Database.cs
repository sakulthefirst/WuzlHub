using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace WuzlHub.DataAccessLayer.MySQL
{
    public class Database : IDatabase
    {
        private string connectionString;


        [ThreadStatic]
        private static DbConnection sharedConnection;

        public Database(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private bool UsingSharedConnaction
        {

            get { return Transaction.Current != null; }
        }
        private DbConnection CreateOpenConneciton()
        {
            DbConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        protected DbConnection GetOpenConnection()
        {
            Transaction currentTx = Transaction.Current;

            if (currentTx == null)
            {
                return CreateOpenConneciton();
            }
            else
            {
                if (sharedConnection == null)
                {
                    sharedConnection = CreateOpenConneciton();
                    currentTx.TransactionCompleted += (s, e) =>
                    {
                        sharedConnection.Close();
                        sharedConnection = null;
                    };
                }
            }
            return sharedConnection;
        }

        protected void ReleaseConnection(DbConnection connection)
        {
            if (connection == null || UsingSharedConnaction)
                return;
            connection.Close();
        }

        public DbCommand CreateCommand(string sql)
        {
            return new MySqlCommand(sql);
        }

        public int DeclareParameter(DbCommand cmd, string name, DbType type)
        {
            if (cmd.Parameters.Contains(name))
            {
                throw new ArgumentException($"paramenter {name} already declared");
            }
            return cmd.Parameters.Add(new MySqlParameter(name, type));
        }

        public int DefineParameter(DbCommand cmd, string name, DbType type, object value)
        {
            int paramIdx = DeclareParameter(cmd, name, type);
            cmd.Parameters[paramIdx].Value = value;
            return paramIdx;
        }

        public int ExecuteNonQuery(DbCommand cmd)
        {
            DbConnection conn = null;

            try
            {
                conn = GetOpenConnection();
                cmd.Connection = conn;
                return cmd.ExecuteNonQuery();
            }
            finally
            {
                ReleaseConnection(conn);
            }
        }

        public IDataReader ExecuteReader(DbCommand cmd)
        {
            DbConnection conn = null;

            try
            {
                conn = GetOpenConnection();
                cmd.Connection = conn;
                var cmdbehanviour = UsingSharedConnaction ? CommandBehavior.Default : CommandBehavior.CloseConnection;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                ReleaseConnection(conn);
                throw ex;
            }
        }

        public void SetParameter(DbCommand cmd, string name, object value)
        {
            if (!cmd.Parameters.Contains(name))
            {
                throw new ArgumentException($"paramenter {name} not declared");
            }
            cmd.Parameters[name].Value = value;
        }

    }
}

