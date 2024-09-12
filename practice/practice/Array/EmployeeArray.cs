using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.lIST
{
    public class EmployeeArray
    {
        // Fields
        public int empId;
        public string firstName;
        public string lastName;
        public string department;
        public decimal salary;


        // Method to initialize fields
        public void Initialize(int empId, string firstName, string lastName, string position, string department, decimal salary, DateTime hireDate)
        {
            this.empId = empId;
            this.firstName = firstName;
            this.lastName = lastName;

            this.department = department;
            this.salary = salary;

        }

        // Method to get full name
        public string GetFullName()
        {
            return $"{firstName} {lastName}";
        }

        // Method to calculate annual salary
        public decimal GetAnnualSalary()
        {
            return salary * 12;
        }


        // Override ToString method to provide a meaningful string representation of the object
        public override string ToString()
        {
            return $"Employee ID: {empId}, Name: {GetFullName()}, Department: {department}Salary: {salary}";
        }
    }
    public class ArrayExample
    {
        public int numberOfEmployee;
        public EmployeeArray[] emp;
        public ArrayExample()
        {
            Console.WriteLine("Enter the numer of employees");
            numberOfEmployee = int.Parse(Console.ReadLine());
        }



        public void RunArrayInitalize()
        {
            emp = new EmployeeArray[numberOfEmployee];
            Console.WriteLine("Enter the numer of employees");
            for (int i = 0; i < numberOfEmployee; i++)
            {
                emp[i] = new EmployeeArray();
                Console.WriteLine($"Please enter the details for the employee{i + 1}");
                Console.Write("Please enter the employee ID: ");
                int empId = int.Parse(Console.ReadLine());
                emp[i].empId = empId;

                Console.Write("Please enter the employee's first name: ");
                string firstName = Console.ReadLine();
                emp[i].firstName = firstName;

                Console.Write("Please enter the employee's last name: ");
                string lastName = Console.ReadLine();
                emp[i].lastName = lastName;

                Console.Write("Please enter the employee's department (e.g., HR, IT): ");
                string department = Console.ReadLine();
                emp[i].department = department;

                Console.Write("Please enter the employee's monthly salary (e.g., 5000.00): ");
                decimal salary = decimal.Parse(Console.ReadLine());
                emp[i].salary = salary;

            }
        }
        public void DisplayEmployee()
        {
            foreach (EmployeeArray e in emp)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

