using System;
using System.Transactions;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projeto_mvc.Services
{
    public class DbContext : IDisposable
    {
        TransactionScope transaction;
        public DbContext()
        {
            if (DbSettings.startup)
            {
                DbSettings.startup = false;
                new DbService();
                new DbDefinitions();
                new Seeds();
            }
            transaction = new TransactionScope();
        }

        public List<T> GetCollection<T>(MySqlCommand query)
        {
            DataTable table = new DbExecuter().GetData(query);
            if (table.Rows.Count == 0)
                return null;
            return table.ToObjectCollection<T>();
        }

        public void Execute(MySqlCommand query)
        {
            new DbExecuter().Execute(query);
        }

        public void Dispose()
        {
            transaction.Complete();
            transaction.Dispose();
        }
    }
}
