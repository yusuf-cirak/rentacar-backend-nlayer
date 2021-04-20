using Business.Concrete;
using DataAccess.EntityFramework;
using DataAccess.InMemoryConcrete;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // UserAdd();

            // CustomerAdd();

            // RentAdd();


        }

        private static void RentAdd()
        {
            RentalsManager rentalsManager = new RentalsManager(new EfRentalsDal());
            var resultAdd = rentalsManager.Add(new Rentals {CarId = 3, CustomerId = 3, RentDate = DateTime.Now, ReturnDate = null });
            Console.WriteLine(resultAdd.Message);
            foreach (var rentals in rentalsManager.GetAll().Data)
            {
                Console.WriteLine(rentals.CarId);
                Console.ReadLine();
            }
        }

        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var resultAdd = customerManager.Add(new Customer { UserId = 1, CustomerId = 1, CompanyName = "İsimsiz holding" });
            Console.WriteLine(resultAdd.Message);
            //foreach (var customer in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(customer.CompanyName);
            //}
        }

    }
}
