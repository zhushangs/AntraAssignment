using System;
using System.Collections.Generic;
using System.Text;
using MinionsApp.Data.Model;
using System.Data.SqlClient;
using System.Data;

namespace MinionsApp.Data.Repository
{
    public class MinionsRepository : IRepository<Minions>
    {
        DBHelper _dBHelper;
        public MinionsRepository()
        {
            _dBHelper = new DBHelper();
        }

        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                sqlConnection.ConnectionString = _dBHelper.GetConnectionString();
                sqlConnection.Open();

                command.CommandText = "Delete from Minions where id =@id";
                command.Parameters.AddWithValue("@id", id);

                command.Connection = sqlConnection;

                int result = command.ExecuteNonQuery();

                sqlConnection.Close();
                return result;
            }
            catch (Exception ex)
            { }

            finally
            {
                sqlConnection.Dispose();
                command.Dispose();
            }
            return 0;
        }

        public IEnumerable<Minions> GetAll()
        {
            string cmd = "Select Id, Name, Age, TownId from Minions";
            DataTable dt = _dBHelper.GetData(cmd, null);
            if (dt != null)
            {
                List<Minions> lstMinions = new List<Minions>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Minions m = new Minions();
                    m.Id = Convert.ToInt32(dataRow["Id"]);
                    m.Name = Convert.ToString(dataRow["Name"]);
                    m.Age = Convert.ToInt32(dataRow["Age"]);
                    m.TownId= Convert.ToInt32(dataRow["TownId"]);

                    lstMinions.Add(m);
                }
                return lstMinions;
            }
            return null;
        }

        public Minions GetById(int id)
        {
            string cmd = "Select Id, Name, Age, TownId from Minions where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = _dBHelper.GetData(cmd, parameters);
            if (dt != null)
            {
                DataRow dataRow = dt.Rows[0];
                Minions m = new Minions();
                m.Id = Convert.ToInt32(dataRow["Id"]);
                m.Name = Convert.ToString(dataRow["Name"]);
                m.Age = Convert.ToInt32(dataRow["Age"]);
                m.TownId = Convert.ToInt32(dataRow["TownId"]);

                return m;
            }
            return null;
        }

        public int Insert(Minions item)
        {
            SqlConnection connection = new SqlConnection(_dBHelper.GetConnectionString());
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Insert into Minions values(@Name, @Age, @TownId)";
            sqlCommand.Parameters.AddWithValue("@Name", item.Name);
            sqlCommand.Parameters.AddWithValue("@Age", item.Age);
            sqlCommand.Parameters.AddWithValue("@TownId", item.TownId);

            sqlCommand.Connection = connection;

            int result = sqlCommand.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public int Update(Minions item)
        {
            string statement = "Update Minions set Name =@name, Age =@Age, TownId=@TownId where Id=@id";
            Dictionary<string, object> parametes = new Dictionary<string, object>();
            parametes.Add("@name", item.Name);
            parametes.Add("@Age", item.Age);
            parametes.Add("@TownId", item.TownId);
            parametes.Add("@Id", item.Id);
            return _dBHelper.ExecuteDML(statement, parametes);
        }

        public int CallSP(Minions item)
        {
            string statement = "exec usp_GetOlder @Id";
            Dictionary<string, object> parametes = new Dictionary<string, object>();
            parametes.Add("@Id", item.Id);
            return _dBHelper.ExecuteDML(statement, parametes, CommandType.StoredProcedure);
        }
    }
}
