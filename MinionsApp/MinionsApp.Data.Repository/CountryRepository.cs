using System;
using System.Collections.Generic;
using System.Text;
using MinionsApp.Data.Model;
using System.Data.SqlClient;
using System.Data;

namespace MinionsApp.Data.Repository
{
    public class CountryRepository : IRepository<Countries>
    {
        DBHelper _dBHelper;
        public CountryRepository()
        {
            _dBHelper = new DBHelper();
        }

        public int CallSP(Countries item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Countries> GetAll()
        {
            string cmd = "Select Id, Name from Countries";
            DataTable dt = _dBHelper.GetData(cmd, null);
            if (dt != null)
            {
                List<Countries> lstCountries = new List<Countries>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    Countries c = new Countries();
                    c.Id = Convert.ToInt32(dataRow["Id"]);
                    c.Name = Convert.ToString(dataRow["Name"]);

                    lstCountries.Add(c);
                }
                return lstCountries;
            }
            return null;
        }

        public Countries GetById(int id)
        {
            string cmd = "Select Id, Name from Countries where id=@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = _dBHelper.GetData(cmd, parameters);
            if (dt != null)
            {
                DataRow dataRow = dt.Rows[0];
                Countries c = new Countries();
                c.Id = Convert.ToInt32(dataRow["Id"]);
                c.Name = Convert.ToString(dataRow["Name"]);

                return c;
            }
            return null;
        }

        public int Insert(Countries item)
        {
            throw new NotImplementedException();
        }

        public int Update(Countries item)
        {
            string statement = "Update Countries set Name =@name where Id=@id";
            Dictionary<string, object> parametes = new Dictionary<string, object>();
            parametes.Add("@name", item.Name);
            parametes.Add("@Id", item.Id);
            return _dBHelper.ExecuteDML(statement, parametes);
        }
    }
}
