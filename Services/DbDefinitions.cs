using System;
using System.Reflection;
using System.Linq;
using MySql.Data.MySqlClient;
using projeto_mvc.Models;

namespace projeto_mvc.Services
{
    public class DbDefinitions
    {
        public DbDefinitions()
        {
            Create(true);
        }

        public void Create(bool dropTables = false)
        {
            Type[] ClassType = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from assemblyType in domainAssembly.GetTypes()
                                where typeof(Entity).IsAssignableFrom(assemblyType)
                                select assemblyType).ToArray();

            for (int i = 0; i < ClassType.Length; i++)
            {
                string tableName = ClassType[i].Name.Replace("ViewModel", "");
                if (dropTables)
                {
                    new DbExecuter().Execute(new MySqlCommand(
                            "DROP TABLE IF EXISTS " + tableName + ";"
                        ));
                }
                string query = "CREATE TABLE IF NOT EXISTS " + tableName + " (";
                PropertyInfo[] props = ClassType[i].GetProperties();
                for (int j = 0; j < props.Length; j++)
                {
                    string PropertyName = props[j].Name;
                    bool Null = props[j].GetType() == typeof(Nullable);
                    string DataType = getDBType(props[j]);
                    Null = false;
                    string DbNull = (Null) ? "NULL" : "NOT NULL";
                    query += props[j].Name + " " + DataType + " " + DbNull;
                    if(PropertyName == "Id"){
                        query += " AUTO_INCREMENT";
                    }
                    query += ", "; 
                    if (PropertyName.EndsWith("Id") && PropertyName != "Id")
                    {
                        for (int l = 0; l < ClassType.Length; l++)
                        {
                            if (ClassType[l] == props[j].PropertyType)
                            {
                                string fk = ClassType[l].Name.Replace("ViewModel", "");
                                query += $"CONSTRAINT [FK_{tableName}_To{fk}] FOREIGN KEY ([{PropertyName}]) REFERENCES [{tableName}] ([{"ID"}]),";
                            }
                        }
                    }
                }
                query += "    PRIMARY KEY (Id)                " +
                    ") ENGINE=INNODB;";
                new DbExecuter().Execute(new MySqlCommand(query));
            }
        }

        private string getDBType(PropertyInfo prop)
        {
            if (prop.PropertyType == typeof(string))
                return "VARCHAR(200) CHARSET utf8";
            if (prop.PropertyType == typeof(bool))
                return "BIT";
            if (prop.PropertyType == typeof(DateTime))
                return "DATETIME2";
            if (prop.PropertyType == typeof(int))
                return "INT";
            if (prop.PropertyType == typeof(double))
                return "DECIMAL(15,2)";
            return string.Empty;
        }
    }
}