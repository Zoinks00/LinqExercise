using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            var sum = numbers.Sum();
            Console.WriteLine($"Sum of number list is {sum}");
            var avg = numbers.Average();
            Console.WriteLine($"Average number in list is {avg}");
            Console.WriteLine("----------");
            //Order numbers in ascending order and decsending order. Print each to console.
            var numAscend = numbers.OrderBy(x => x );
            Console.WriteLine("Number list in Ascending order");
            foreach(var num in numAscend)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("----------"); 

            var numDescend = numbers.OrderByDescending(d => d);
            Console.WriteLine("Number list in Descending order");
            foreach (var num in numDescend)
            {
                Console.WriteLine(num);
            }

            //Print to the console only the numbers greater than 6
            var numG = numbers.Where(num1 => num1 > 6);
            Console.WriteLine("----------");
            Console.WriteLine($"All numbers greater than 6");
            foreach (var num in numG)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("----------");
            var firstFour = numbers.Take(4);
            Console.WriteLine("First 4 Decsending");
            foreach(var num in firstFour)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("----------");
            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 37;
            foreach(var n in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(n);
            }
            Console.WriteLine("----------");
            
            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var filterFirst = employees.Where(f => f.FirstName.StartsWith('C') || f.FirstName.StartsWith('S')).OrderBy(f => f.FirstName);
            Console.WriteLine("Employee names starting with C or S\n");
            foreach(var nItem in filterFirst)
            {
                Console.WriteLine(nItem.FirstName);
            }
            Console.WriteLine("------------");
            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var sortedAge = employees.Where(af => af.Age > 26).OrderBy(af => af.Age).ThenBy(af => af.FirstName);
            Console.WriteLine("Full name of employees older than 26\n");
            foreach(var a in sortedAge)
            {
                Console.WriteLine($"FullName {a.FullName} Age { a.Age}");
            }
            Console.WriteLine("-----------");
            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35
            var sumYOE = employees.Where(yoe => yoe.YearsOfExperience <= 10 && yoe.Age > 35).Sum(yoe => yoe.YearsOfExperience);
            Console.WriteLine($"Sum of experience for employees with 10 years or less experience who are older than 35: {sumYOE}");
            var avgYOE = employees.Where(yoe => yoe.YearsOfExperience <= 10 && yoe.Age > 35).Average(yoe => yoe.YearsOfExperience);
            //Average of employees with 10 or YOE and older then 35
            Console.WriteLine($"Average of employees with 10 years or less experience who are older than 35: {avgYOE}");
            //Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("------------");
            Console.WriteLine("New employee added to current employee list\n");
            employees = employees.Append(new Employee("Forrest", "Rabideau", 37, 2)).ToList();

            foreach(var item in employees)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} {item.Age} {item.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
