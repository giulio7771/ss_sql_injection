using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Xml.Serialization;

namespace projeto_mvc.Services
{
    public class DbExecuter
    {
        private DbHelper helper;
        public DbExecuter(bool withDatabase = true)
        {
            helper =
            new DbHelper(withDatabase);
        }

        public int Execute(MySqlCommand command)
        {
            using (helper)
            {
                helper.Setup(command);
                return command.ExecuteNonQuery();
            }
        }

        public DataTable GetData(MySqlCommand command)
        {
            using (helper)
            {
                helper.Setup(command);
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
        }
    }
}
