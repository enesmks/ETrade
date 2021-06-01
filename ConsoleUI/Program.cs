using Business.Concrete;
using Core.Extensions;
using DataAccess.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManager employeeManager = new EmployeeManager(new EfEmployeeDal());
            foreach (var employee in employeeManager.GetAll().Data)
            {
                DateTime birthDate = employee.BirthDate;
                var today = DateTime.Now;
                string iso = "yyyy-MM-dd";


                Console.WriteLine("Birth date: " + birthDate.ToString(iso) + "Today : " + today.ToString(iso) + "  Age: " + birthDate.AddDays(today.Day).Age(today.AddDays(today.Day)).ToString());
            }
            
            

            Console.ReadLine();
        }
    }
}
