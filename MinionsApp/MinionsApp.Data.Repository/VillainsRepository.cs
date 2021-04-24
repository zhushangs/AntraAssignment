using System;
using System.Collections.Generic;
using System.Text;
using MinionsApp.Data.Model;
using System.Data.SqlClient;
using System.Data;

namespace MinionsApp.Data.Repository
{
    public class VillainsRepository : IRepository<Villains>
    {
        DBHelper _dBHelper;
        public VillainsRepository()
        {
            _dBHelper = new DBHelper();
        }

        public int CallSP(Villains item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand command = new SqlCommand();
            try
            {
                sqlConnection.ConnectionString = _dBHelper.GetConnectionString();
                sqlConnection.Open();

                command.CommandText = "Delete * from Villains where id =@id";
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

        public IEnumerable<Villains> GetAll()
        {
            string cmd = "Select Id, Name, EvilnessFactorId from Villains";
            DataTable dt = _dBHelper.GetData(cmd, null);
            if (dt != null)
            {
                List<Villains> lstVillains = new List<Villains>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Villains v = new Villains();
                    v.Id = Convert.ToInt32(dataRow["Id"]);
                    v.Name = Convert.ToString(dataRow["Name"]);
                    v.EvilnessFactorId = Convert.ToInt32(dataRow["EvilnessFactorId"]);

                    lstVillains.Add(v);
                }
                return lstVillains;
            }
            
            return null;
        }

        public Villains GetById(int id)
        {
            string cmd = "Select Id, Name,EvilnessFactorId from Villains where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = _dBHelper.GetData(cmd, parameters);
            if (dt != null)
            {
                DataRow dataRow = dt.Rows[0];
                Villains v = new Villains();
                v.Id = Convert.ToInt32(dataRow["Id"]);
                v.Name = Convert.ToString(dataRow["Name"]);
                v.EvilnessFactorId = Convert.ToInt32(dataRow["EvilnessFactorId"]);

                return v;
            }
            return null;
        }

        public int Insert(Villains item)
        {
            SqlConnection connection = new SqlConnection(_dBHelper.GetConnectionString());
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Insert into Villains values(@Name, @EvilnessFactorId)";
            sqlCommand.Parameters.AddWithValue("@Name", item.Name);
            sqlCommand.Parameters.AddWithValue("@EvilnessFactorId", item.EvilnessFactorId);

            sqlCommand.Connection = connection;
            int result = sqlCommand.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public int Update(Villains item)
        {
            string statement = "Update Villains set Name =@name, EvilnessFactorId =@EvilnessFactorId where Id=@id";
            Dictionary<string, object> parametes = new Dictionary<string, object>();
            parametes.Add("@name", item.Name);
            parametes.Add("@EvilnessFactorId", item.EvilnessFactorId);
            parametes.Add("@Id", item.Id);
            return _dBHelper.ExecuteDML(statement, parametes);
        }
    }
}
