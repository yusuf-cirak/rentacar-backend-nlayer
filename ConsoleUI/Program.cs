using Business.Concrete;
using DataAccess.EntityFramework;
using DataAccess.InMemoryConcrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarDescription);
            }
        }
    }
}
