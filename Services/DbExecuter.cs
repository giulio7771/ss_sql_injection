using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Xml.Serialization;

namespace projeto_mvc.Services
{
    public class DbExecuter
    {
        private DbHelper helper =
            new DbHelper();

        public int Execute(MySqlCommand command)
        {
            using (helper)
            {
                try
                {
                    helper.Setup(command);
                    return command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao conectar-se com o banco de dados.");
                }
            }
        }
        public DataTable GetData(MySqlCommand command)
        {
            using (helper)
            {
                try
                {
                    helper.Setup(command);
                    DataTable table = new DataTable();
                    table.Load(command.ExecuteReader());
                    return table;
                }
                catch (Exception e)
                {
                    throw new Exception("Erro ao buscar valores no banco de dados.");
                }
            }
        }
    }
}
