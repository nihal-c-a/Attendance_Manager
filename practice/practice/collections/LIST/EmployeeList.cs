using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice.Array
{
    public class EmployeelIST
    {
        // Fields
        public int empId;
        public string firstName;
        public string lastName;
        public string department;
        public decimal salary;

        // Method to initialize fields
        public void Initialize(int empId, string firstName, string lastName, string department, decimal salary)
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
            return $"Employee ID: {empId}, Name: {GetFullName()}, Department: {department}, Salary: {salary:C}";
        }
    }

    public class ListExample
    {
        public int numberOfEmployee;
        public List<EmployeelIST> emp;

        public ListExample()
        {
            Console.WriteLine("Enter the number of employees:");
            numberOfEmployee = int.Parse(Console.ReadLine());
            emp = new List<EmployeelIST>(numberOfEmployee); // Initialize List with initial capacity
        }

        public void RunListInitialize()
        {
            for (int i = 0; i < numberOfEmployee; i++)
            {
                var employee = new EmployeelIST();
                Console.WriteLine($"Please enter the details for employee {i + 1}");

                Console.Write("Please enter the employee ID: ");
                int empId = int.Parse(Console.ReadLine());
                employee.empId = empId;

                Console.Write("Please enter the employee's first name: ");
                string firstName = Console.ReadLine();
                employee.firstName = firstName;

                Console.Write("Please enter the employee's last name: ");
                string lastName = Console.ReadLine();
                employee.lastName = lastName;

                Console.Write("Please enter the employee's department (e.g., HR, IT): ");
                string department = Console.ReadLine();
                employee.department = department;

                Console.Write("Please enter the employee's monthly salary (e.g., 5000.00): ");
                decimal salary = decimal.Parse(Console.ReadLine());
                employee.salary = salary;

                emp.Add(employee); // Add the employee to the list
            }
        }

        public void DisplayEmployee()
        {
            foreach (var e in emp)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
