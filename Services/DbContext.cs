using System;
using System.Transactions;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace projeto_mvc.Services
{ 
    public class DbContext<T>: IDisposable
    {
        TransactionScope transaction;
        public DbContext()
        {
            transaction = new TransactionScope();
        }

        public List<T> Select(string query)
        {
            DataTable table = new DbExecuter().GetData(new MySqlCommand(query));
            if (table.Rows.Count == 0)
                return null;
            return table.ToObjectCollection<T>();
        }

        public void Dispose()
        {
            transaction.Complete();
            transaction.Dispose();
        }
    }
}
