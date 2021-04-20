using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise3
{
    class ManageAccount
    {
        IRepository<HouseholdAccounts> accRepository;
        public ManageAccount()
        {
            accRepository = new AccountRepository();
        }

        void AddDepartment()
        {
            HouseholdAccounts a = new HouseholdAccounts();
            Console.Write("Enter date  = ");
            a.Date = Console.ReadLine();

            Console.Write("Enter Description = ");
            a.Description = Console.ReadLine();

            Console.Write("Enter Category = ");
            a.Category = Console.ReadLine();

            Console.Write("Enter amount  = ");
            a.Amount = Convert.ToInt32(Console.ReadLine());

            accRepository.Insert(a);
            Console.WriteLine("Account created successfully");
        }

        void Print()
        {

            List<HouseholdAccounts> accCollection = accRepository.GetAll();
            int length = accCollection.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{accCollection[i].Date} \t {accCollection[i].Description} \t {accCollection[i].Category} \t {accCollection[i].Amount}");
            }
        }

        void Delete()
        {
            Console.Write("Enter DATE = ");
            string date = Console.ReadLine();
            accRepository.Delete(date);
            Console.WriteLine("Account deleted successfully");
        }
        void Update()
        {
            HouseholdAccounts d = new HouseholdAccounts();
            Console.Write("Enter date  = ");
            d.Date = Console.ReadLine();

            Console.Write("Enter new Description = ");
            d.Description = Console.ReadLine();

            Console.Write("Enter new Category = ");
            d.Category = Console.ReadLine();

            Console.Write("Enter new amount  = ");
            d.Amount = Convert.ToInt32(Console.ReadLine());

            accRepository.Update(d);
            Console.WriteLine("Account updated successfully");
        }
        void Search()
        {
            Console.Write("Enter Description or Category information = ");
            string text = Console.ReadLine();
            List<HouseholdAccounts> accCollection = accRepository.Search(text);
            int length = accCollection.Count;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"{accCollection[i].Date} \t {accCollection[i].Description} \t {accCollection[i].Category} \t {accCollection[i].Amount}");
            }
        }

        void Sorted()
        {
            accRepository.GetSorted();
            Console.WriteLine("Account sorted successfully");
        }

        public void Run()
        {
            Console.Clear();
            int choice = (int)CRUDOperations.Exit;
            Menu m = new Menu();
            do
            {
                Console.Clear();
                choice = m.Print(typeof(CRUDOperations));
                switch (choice)
                {
                    case (int)CRUDOperations.Insert:
                        AddDepartment();
                        break;
                    case (int)CRUDOperations.Print:
                        Print();
                        break;
                    case (int)CRUDOperations.Search:
                        Search();
                        break;
                    case (int)CRUDOperations.Update:
                        Update();
                        break;
                    case (int)CRUDOperations.Delete:
                        Delete();
                        break;
                    case (int)CRUDOperations.Sort:
                        Sorted();
                        break;
                    case (int)CRUDOperations.Exit:
                        Console.WriteLine("Thanks for visit. Please visit again !!!!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();

            } while (choice != (int)CRUDOperations.Exit);

        }
    }
}
