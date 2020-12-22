using System.Data;

namespace MISA.DL
{
    internal class MysqlConnection : IDbConnection
    {
        public MysqlConnection(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public int ConnectionTimeout => throw new System.NotImplementedException();

        public string Database => throw new System.NotImplementedException();

        public ConnectionState State => throw new System.NotImplementedException();

        string IDbConnection.ConnectionString { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IDbTransaction BeginTransaction()
        {
            throw new System.NotImplementedException();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            throw new System.NotImplementedException();
        }

        public void ChangeDatabase(string databaseName)
        {
            throw new System.NotImplementedException();
        }

        public void Close()
        {
            throw new System.NotImplementedException();
        }

        public IDbCommand CreateCommand()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public void Open()
        {
            throw new System.NotImplementedException();
        }
    }
}