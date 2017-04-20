using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise.Domain
{
    public class DataBaseRepository : IDatabaseRepository
    {
        private string categoryTable = "Categories";

        private string postsTable = "Posts";

        public DataTable GetCategories()
        {
            return Get(categoryTable);
        }

        public DataTable GetPosts()
        {
            return Get(postsTable);
        }

        public bool isCategoryExists(string title)
        {
            return isExists(categoryTable,title);
        }

        public bool isPostExists(string title)
        {
            return isExists(postsTable, title);
        }

        public int Save()
        {
            throw new NotImplementedException();
        }

        private DataTable Get(string tableName)
        {
            DataTable table = new DataTable();

            using (var connection = new OleDbConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT * FROM {tableName}";
                    connection.Open();

                    using (var adapter = new OleDbDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }

            return table;
        }

        private bool isExists(string tableName, string value)
        {
            int count = 0;

            using (var connection = new OleDbConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT count(*) FROM {tableName} where title = @title";
                    command.Parameters.Add(
                            new OleDbParameter("@title", value)
                        );

                    connection.Open();

                    count = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return count > 0;
        }
    }
}
