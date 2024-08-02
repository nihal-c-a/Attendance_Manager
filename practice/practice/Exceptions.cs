﻿using practice.ClassesAndObjects;
using System.IO;
using System.Reflection;
using System;

Module 14 Snippets
------------------
 
Demo 1
------

Console.WriteLine("5: Load specific employee");

case "5":
    Utilities.LoadEmployeeById(employees);
    break;

    internal static void LoadEmployeeById(Employee[] employees)
    {
        Console.Write("Enter the Employee ID you want to visualize: ");

        int selectedId = int.Parse(Console.ReadLine());

        //let's assume there is an existing employee at this point
        Employee selectedEmployee = employees[selectedId];
        selectedEmployee.DisplayEmployeeDetails();

    }


    try
    {


    }
    catch (FormatException fex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("That's not the correct format to enter an ID!\n\n");
        Console.ResetColor();
    }


    Demo 2
    ------

internal static void LoadEmployees(Employee[] employees, ref int employeeCount)
    {
        string path = $"{directory}{fileName}";
        try
        {
            if (File.Exists(path))
            {
                //reset the index 
                //clear all employees currently in the array

                for (int i = 0; i < employeeCount; i++)
                {
                    employees[i] = null;
                }
                employeeCount = 0;

                //now read the file
                string[] employeesAsString = File.ReadAllLines(path);
                for (int i = 0; i < employeesAsString.Length; i++)
                {
                    string[] employeeSplits = employeesAsString[i].Split(';');
                    string firstName = employeeSplits[0].Substring(employeeSplits[0].IndexOf(':') + 1);
                    string lastName = employeeSplits[1].Substring(employeeSplits[1].IndexOf(':') + 1);
                    string email = employeeSplits[2].Substring(employeeSplits[2].IndexOf(':') + 1);
                    DateTime birthDay = DateTime.Parse(employeeSplits[3].Substring(employeeSplits[3].IndexOf(':') + 1));
                    double hourlyRate = double.Parse(employeeSplits[4].Substring(employeeSplits[4].IndexOf(':') + 1));

                    Employee employee = new Employee(firstName, lastName, email, birthDay, hourlyRate);
                    employees[i] = employee;
                    employeeCount++;

                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Loaded {employeeCount} employees!\n\n");
                //Console.ResetColor();
            }
        }

        catch (FileNotFoundException fnfex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The file couldn't be found!");
            Console.WriteLine(fnfex.Message);
            Console.WriteLine(fnfex.StackTrace);
            Console.ResetColor();
        }

    }



    Demo 3
    ------

catch (IndexOutOfRangeException iex)
{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Something went wrong parsing the file, please check the data!");
        Console.WriteLine(iex.Message);
        Console.ResetColor();
    }
catch (FileNotFoundException fnfex)
{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("The file couldn't be found!");
        Console.WriteLine(fnfex.Message);
        Console.WriteLine(fnfex.StackTrace);
        Console.ResetColor();
    }
			

catch (Exception ex)
{
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Something went wrong while loading the file!");
        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }


    Demo 4
    ------


finally
{
        Console.ResetColor();
    }

            