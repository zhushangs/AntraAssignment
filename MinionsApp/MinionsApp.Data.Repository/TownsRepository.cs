using System;
using System.Collections.Generic;
using System.Text;
using MinionsApp.Data.Model;
using System.Data.SqlClient;
using System.Data;


namespace MinionsApp.Data.Repository
{
    public class TownsRepository : IRepository<Towns>
    {
        DBHelper _dBHelper;
        public TownsRepository()
        {
            _dBHelper = new DBHelper();
        }

        public int CallSP(Towns item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Towns> GetAll()
        {
            string cmd = "Select Id, Name, CountryCode from Towns";
            DataTable dt = _dBHelper.GetData(cmd, null);
            if (dt != null)
            {
                List<Towns> lstTowns = new List<Towns>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Towns t = new Towns();
                    t.Id = Convert.ToInt32(dataRow["Id"]);
                    t.Name = Convert.ToString(dataRow["Name"]);
                    t.CountryCode = Convert.ToInt32(dataRow["CountryCode"]);

                    lstTowns.Add(t);
                }
                return lstTowns;
            }

            return null;
        }

        public Towns GetById(int id)
        {
            string cmd = "Select Id, Name, CountryCode from Towns where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = _dBHelper.GetData(cmd, parameters);
            if (dt != null)
            {
                DataRow dataRow = dt.Rows[0];
                Towns t = new Towns();
                t.Id = Convert.ToInt32(dataRow["Id"]);
                t.Name = Convert.ToString(dataRow["Name"]);
                t.CountryCode = Convert.ToInt32(dataRow["CountryCode"]);

                return t;
            }
            return null;
        }

        public int Insert(Towns item)
        {
            SqlConnection connection = new SqlConnection(_dBHelper.GetConnectionString());
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "Insert into Towns values(@Name, @CountryCode)";
            sqlCommand.Parameters.AddWithValue("@Name", item.Name);
            sqlCommand.Parameters.AddWithValue("@CountryCode", item.CountryCode);

            sqlCommand.Connection = connection;
            int result = sqlCommand.ExecuteNonQuery();

            connection.Close();
            return result;
        }

        public int Update(Towns item)
        {
            string statement = "Update Towns set Name =@name, CountryCode =@CountryCode where Id=@id";
            Dictionary<string, object> parametes = new Dictionary<string, object>();
            parametes.Add("@name", item.Name);
            parametes.Add("@CountryCode", item.CountryCode);
            parametes.Add("@Id", item.Id);
            return _dBHelper.ExecuteDML(statement, parametes);
        }
    }
}
