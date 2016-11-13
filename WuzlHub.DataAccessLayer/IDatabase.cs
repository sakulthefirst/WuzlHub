using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WuzlHub.DataAccessLayer
{
   public interface IDatabase
    {
        DbCommand CreateCommand(string sql);

        int DeclareParameter(DbCommand cmd, string name, DbType type);

        void SetParameter(DbCommand cmd, string name, object value);

        int DefineParameter(DbCommand cmd, string name, DbType type, object value);

        IDataReader ExecuteReader(DbCommand cmd);

        int ExecuteNonQuery(DbCommand cmd);
    }
}
