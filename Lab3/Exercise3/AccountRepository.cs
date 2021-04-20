using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class AccountRepository : IRepository<HouseholdAccounts>
    {
        List<HouseholdAccounts> lstCollection = new List<HouseholdAccounts>(10000);
        public void Delete(string date)
        {
            HouseholdAccounts d = GetByDate(date);
            if (d != null)
                lstCollection.Remove(d);
        }

        public List<HouseholdAccounts> GetAll()
        {
            return lstCollection;
        }

        public HouseholdAccounts GetByDate(string date)
        {
            int length = lstCollection.Count;
            for (int i = 0; i < length; i++)
            {
                if (lstCollection[i].Date == date)
                    return lstCollection[i];
            }
            return null;
        }

        public void Insert(HouseholdAccounts item)
        {
            lstCollection.Add(item);
        }

        public void Update(HouseholdAccounts item)
        {
            HouseholdAccounts a = GetByDate(item.Date);
            if (a != null)
            {
                a.Date = item.Date;
                a.Description = item.Description;
                a.Category = item.Category;
                a.Amount = item.Amount;
            }
        }

        public List<HouseholdAccounts> Search(string text)
        {
            int length = lstCollection.Count;
            List<HouseholdAccounts> matched = new List<HouseholdAccounts>(10000);
            for (int i = 0; i < length; i++)
            {
                if (lstCollection[i].Description.ToLower().Contains(text.ToLower()))
                {
                    matched.Add(lstCollection[i]);
                }
                else if (lstCollection[i].Category.ToLower().Contains(text.ToLower()))
                {
                    matched.Add(lstCollection[i]);
                }
                    
            }
            return matched;
        }

        public void GetSorted()
        {
            lstCollection.Sort((s1, s2) => s1.Date.CompareTo(s2.Date));
        }
    }
}
