using System;
using System.Collections.Generic;
using MinionsApp.Data.Model;
using MinionsApp.Data.Repository;
using System.Linq;

namespace MinionsApp.ConsoleApp
{
    public class ManageAll
    {
        IRepository<Villains> villainsRepository;
        IRepository<MinionsVillains> minionsVillainsRepository;
        IRepository<Minions> minionsRepositroy;
        IRepository<Towns> townsRepository;
        IRepository<Countries> countryRepository;
        public ManageAll()
        {
            villainsRepository = new VillainsRepository();
            minionsVillainsRepository = new MinionsVillainsRepository();
            minionsRepositroy = new MinionsRepository();
            townsRepository = new TownsRepository();
            countryRepository = new CountryRepository();
        }

        void PrintVillainNames()
        {
            var collection = from v in villainsRepository.GetAll()
                             join mv in minionsVillainsRepository.GetAll()
                             on v.Id equals mv.VillainId
                             into minonsVillains
                             from mvv in minonsVillains.DefaultIfEmpty()
                             group mvv by v.Name into grouped
                             where grouped.Count() > 3
                             orderby grouped.Count() descending
                             select new { Name = grouped.Key, count = grouped.Count() };

            foreach (var item in collection)
            {
                Console.WriteLine($"{item.Name} \t {item.count}");
            }
        }

        void PrintMinionNames()
        {
            Console.Write("Enter Villain Id = ");
            int Id = Convert.ToInt32(Console.ReadLine());
            var collection = from v in villainsRepository.GetAll()
                             join mv in minionsVillainsRepository.GetAll()
                             on v.Id equals mv.VillainId
                             join m in minionsRepositroy.GetAll()
                             on mv.MinionId equals m.Id
                             where v.Id == Id
                             select new
                             {
                                 villains = v.Name,
                                 minions = m.Name,
                                 age = m.Age
                             };

            int count = collection.Count();
            if (count == 0)
            {
                Console.WriteLine($"No villain with ID {Id} exists in the database");
            }


            foreach (var item in collection)
            {
                Console.WriteLine($"{item.villains} \t {item.minions} \t {item.age}");
            }
        }
        void AddMinion()
        {
            Minions minions = new Minions();

            Console.Write("Enter minions name =");
            minions.Name = Console.ReadLine();

            Console.Write("Enter minions age =");
            minions.Age = Convert.ToInt32(Console.ReadLine());

            Towns towns = new Towns();
            Console.Write("Enter minions town =");
            towns.Name = Console.ReadLine();

            Villains villains = new Villains();
            Console.Write("Enter villains name =");
            villains.Name = Console.ReadLine();

            var checkVillainsName = from v in villainsRepository.GetAll()
                                    where v.Name.ToLower() == villains.Name.ToLower()
                                    select v.Name;

            int countVillains = checkVillainsName.Count();
            if (countVillains == 0)
            {
                villains.EvilnessFactorId = 4;
                villainsRepository.Insert(villains);
                Console.WriteLine($"Villain {villains.Name} was added to the database.");
            }

            var checkTownsName = from t in townsRepository.GetAll()
                                 where t.Name.ToLower() == towns.Name.ToLower()
                                 select t.Name;
            int countTowns = checkTownsName.Count();
            if (countTowns == 0)
            {
                towns.CountryCode = 4;
                townsRepository.Insert(towns);
                Console.WriteLine($"Town {towns.Name} was added to the database.");
            }

            foreach (var item in townsRepository.GetAll())
            {
                if (item.Name.ToLower() == towns.Name.ToLower())
                {
                    minions.TownId = item.Id;
                }
            }
            minionsRepositroy.Insert(minions);
            Console.WriteLine($"Successfully added {minions.Name} to be minion of {villains.Name}.");
        }

        void ChangeTownNames()
        {
            Console.Write("Enter country name = ");
            string countryName = Console.ReadLine().Trim();

            var findTowns = from t in townsRepository.GetAll()
                            join c in countryRepository.GetAll()
                            on t.CountryCode equals c.Id
                            where c.Name.ToLower() == countryName.ToLower()
                            group t by new
                            {
                                t.Name,
                                t.Id,
                                t.CountryCode,
                            }
                            into townNames
                            select new
                            {
                                key = townNames.Key.Name,
                                Id = townNames.Key.Id,
                                countryCode = townNames.Key.CountryCode,
                                count = townNames.Count(),               
                            };

            int count = findTowns.Count();
            if (count == 0)
            {
                Console.WriteLine("No town names were affected");
            }


            
            foreach (var item in findTowns)
            {
                Console.Write($" {item.key.ToUpper()} ");
                Towns towns = new Towns();
                towns.Id = item.Id;
                towns.Name = item.key.ToUpper();
                towns.CountryCode = item.countryCode;
                townsRepository.Update(towns);
            }
            Console.WriteLine();
            Console.WriteLine($" {findTowns.Count()} town names were affected");
           
        }

        void RemoveVillain()
        {
            Console.Write("Enter villain id = ");
            int id = Convert.ToInt32(Console.ReadLine());

            var villain = from v in villainsRepository.GetAll()
                          join mv in minionsVillainsRepository.GetAll()
                          on v.Id equals mv.VillainId
                          join m in minionsRepositroy.GetAll()
                          on mv.MinionId equals m.Id
                          where v.Id == id
                          group v by new
                          {
                              v.Name,
                              v.Id
                          }
                          into villainDelete
                          select new
                          {
                              villains = villainDelete.Key.Name,
                              id = villainDelete.Key.Id,
                              count = villainDelete.Count(),
                          };
            int count = villain.Count();
            if (count == 0)
            {
                Console.WriteLine("No such villain was found.");
            }
            foreach (var item in villain)
            {
                villainsRepository.Delete(id);
                Console.WriteLine($"{item.villains} was deleted \n{item.count} minions were released");
            }
        }
        void PrintAllMinionNames()
        {
            var collection = from m in minionsRepositroy.GetAll() select m.Name;
            List<string> minionslst = new List<string>();
            Console.WriteLine("---------------Before sort---------------");
            foreach (var item in collection)
            {
                minionslst.Add(item);
                Console.WriteLine(item);
            }
            int length = minionslst.Count()-1;
            Console.WriteLine("---------------After sort---------------");
            for (int start = 0, end = length; start < end; start++, end--)
            {
                Console.WriteLine(minionslst[start]);
                Console.WriteLine(minionslst[end]);
            }
        }

        void IncreaseMinionAge()
        {
            Console.Write("Enter Minions IDs, separte by space = ");
            string ids = Console.ReadLine();

            int[] idArr = ids.Split(" ").Select(n => Convert.ToInt32(n)).ToArray();

            foreach (int id in idArr)
            {
                var collection = from m in minionsRepositroy.GetAll()
                                 where m.Id == id
                                 select new
                                 {
                                     name = m.Name,
                                     age = m.Age,
                                     m.Id,
                                     m.TownId,
                                 };
                foreach (var item in collection)
                {
                    Minions minions = new Minions();
                    minions.Id = item.Id;
                    minions.Name = item.name;
                    minions.Age = item.age + 1;
                    minions.TownId = item.TownId;
                    minionsRepositroy.Update(minions);
                }
            }
            foreach (var item in minionsRepositroy.GetAll())
            {
                Console.WriteLine($"{item.Name} \t {item.Age}");
            }
        }

        void IncreaseAgeInSP()
        {
            Minions minions = new Minions();
            Console.Write("Enter Minions Id = ");
            minions.Id = Convert.ToInt32(Console.ReadLine());

            minionsRepositroy.CallSP(minions);
            //foreach (var item in minionsRepositroy.GetAll())
            //{
            //    Console.WriteLine($"{item.Name} - {item.Age} years old");
            //}
            var minion = minionsRepositroy.GetById(minions.Id);
            Console.WriteLine($"{minion.Name} - {minion.Age} years old");
        }

        public void Run()
        {
            //PrintVillainNames();
            //PrintMinionNames();
            //AddMinion();
            //ChangeTownNames();
            //RemoveVillain();
            //PrintAllMinionNames();
            //IncreaseMinionAge();
            IncreaseAgeInSP();
        }
    }
}
