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
            
            bool valid = true;
            do
            {
                Console.Write("Enter date (YYYYMMDD format) = ");
                a.Date = Console.ReadLine();
                if (string.IsNullOrEmpty(a.Date))
                {
                    valid = false;
                    Console.WriteLine("Empty input, please try again");
                }
                else if (a.Date.Length != 8 || Convert.ToInt32(a.Date) < 10000000 || Convert.ToInt32(a.Date) > 30000000)
                {
                    valid = false;
                    Console.WriteLine("Invalid Date input");
                }
                else
                {
                    valid = true;
                }
               
            } while (!valid);


            do
            {
                Console.Write("Enter Description = ");
                a.Description = Console.ReadLine();
                if(string.IsNullOrEmpty(a.Description))
                {
                    Console.WriteLine("Empty input, please try again");
                }
            } while (string.IsNullOrEmpty(a.Description));

            Console.Write("Enter Category = ");
            a.Category = Console.ReadLine();

            //do
            //{
            //    Console.Write("Enter amount (Must be integer) = ");
            //    a.Amount = Convert.ToInt32(Console.ReadLine());
            //    if (a.Amount.GetType() != typeof(int))
            //    {
            //        Console.WriteLine("Empty input, please try again");
            //    }
            //} while (a.Amount.GetType() != typeof(int));

            Console.Write("Enter amount (Must be integer) = ");
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
                //Console.WriteLine($"{accCollection[i].Date} \t {accCollection[i].Description} \t {accCollection[i].Category} \t {accCollection[i].Amount}");
                Console.WriteLine("{0} - {1}/{2}/{3} - {4} -({5}) - {6}",
                                   i + 1,
                                   accCollection[i].Date.Substring(6, 2), // Day
                                   accCollection[i].Date.Substring(4, 2), // Month
                                   accCollection[i].Date.Substring(0, 4), // Year
                                   accCollection[i].Description,
                                   accCollection[i].Category,
                                   accCollection[i].Amount.ToString("N2"));
            }
        }

        void PrintByCategoryAndDate()
        {
            Console.Write("Enter the category = ");
            string category = Console.ReadLine();

            Console.Write("Enter the the start date (YYYYMMDD) = ");
            string startDate = Console.ReadLine();

            Console.Write("Enter the the end date (YYYYMMDD) = ");
            string endDate = Console.ReadLine();


            List<HouseholdAccounts> accCollection = accRepository.GetByCategoryAndDate(category, startDate, endDate);
            int length = accCollection.Count;
            for (int i = 0; i < length; i++)
            {
                //Console.WriteLine($"{accCollection[i].Date} \t {accCollection[i].Description} \t {accCollection[i].Category} \t {accCollection[i].Amount}");
                Console.WriteLine("{0} - {1}/{2}/{3} - {4} -({5}) - {6}",
                                   i + 1,
                                   accCollection[i].Date.Substring(6, 2), // Day
                                   accCollection[i].Date.Substring(4, 2), // Month
                                   accCollection[i].Date.Substring(0, 4), // Year
                                   accCollection[i].Description,
                                   accCollection[i].Category,
                                   accCollection[i].Amount.ToString("N2"));
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
            Console.Write("Enter date (YYYYMMDD format) = ");
            d.Date = Console.ReadLine();

            Console.Write("Enter new Description of expenditure or revenu = ");
            d.Description = Console.ReadLine();
            
            Console.Write("Enter Category = ");
            d.Category = Console.ReadLine();

            Console.Write("Enter amount  = ");
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
                //Console.WriteLine($"{accCollection[i].Date} \t {accCollection[i].Description} \t {accCollection[i].Category} \t {accCollection[i].Amount}");
                Console.WriteLine("{0} - {1}/{2}/{3} - {4} -({5}) - {6}",
                                   i + 1,
                                   accCollection[i].Date.Substring(6, 2), // Day
                                   accCollection[i].Date.Substring(4, 2), // Month
                                   accCollection[i].Date.Substring(0, 4), // Year
                                   accCollection[i].Description,
                                   accCollection[i].Category,
                                   accCollection[i].Amount.ToString("N2"));
            }
        }

        void Sorted()
        {
            accRepository.GetSorted();
            Console.WriteLine("Account Date sorted successfully");
        }

        void Normalized()
        {
            accRepository.GetNormalized();
            Console.WriteLine("Account Description sorted successfully");
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
                    case (int)CRUDOperations.PrintByCategoryAndDate:
                        PrintByCategoryAndDate();
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
                    case (int)CRUDOperations.Normalize:
                        Normalized();
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
