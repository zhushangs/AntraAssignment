using System;
using System.Collections.Generic;
using System.Text;
using MinionsApp.Data.Model;
using System.Data.SqlClient;
using System.Data;

namespace MinionsApp.Data.Repository
{
    public class MinionsVillainsRepository : IRepository<MinionsVillains>
    {
        DBHelper _dBHelper;
        public MinionsVillainsRepository()
        {
            _dBHelper = new DBHelper();
        }

        public int CallSP(MinionsVillains item)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MinionsVillains> GetAll()
        {
            string cmd = "Select MinionId, VillainId from MinionsVillains";
            DataTable dt = _dBHelper.GetData(cmd, null);
            if (dt != null)
            {
                List<MinionsVillains> lstMinionsVillains = new List<MinionsVillains>();

                foreach (DataRow dataRow in dt.Rows)
                {
                    MinionsVillains mv = new MinionsVillains();
                    mv.MinionId = Convert.ToInt32(dataRow["MinionId"]);
                    mv.VillainId = Convert.ToInt32(dataRow["VillainId"]);

                    lstMinionsVillains.Add(mv);
                }
                return lstMinionsVillains;
            }
            return null;
        }

        public MinionsVillains GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(MinionsVillains item)
        {
            throw new NotImplementedException();
        }

        public int Update(MinionsVillains item)
        {
            throw new NotImplementedException();
        }
    }
}
