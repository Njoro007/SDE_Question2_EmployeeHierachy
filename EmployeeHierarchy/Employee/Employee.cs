using System;
using System.Collections.Generic;
using System.IO;

namespace Employee
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public int ManagerID { get; set; }
        public int Salary { get; set; }

        public Employee()
        {

        }

        //Create Overload Constructor
        public Employee(string StringCSVList)
        {
            using (var reader = new StringReader(StringCSVList))
            {
                List<Employee> _Employee = new List<Employee>();
                _Employee.Clear();

                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] values = line.Split(',');
                    _Employee.Add(new Employee()
                    {
                        EmployeeID = Convert.ToInt32(values[0]),
                        ManagerID = Convert.ToInt32(values[1]),
                        Salary = Convert.ToInt32(values[2]),
                    });

                }
            }
        }



        //Instance Sum Salary Budget
        public static int BudgetSalary(string ManagerID)
        {
            int salary=0;

            return salary;
        }



        //Input Validation for salary
        private static bool InputValidateSalary(string input)
        {
            bool mypass = true;
            var PositiveInRegex = new System.Text.RegularExpressions.Regex(@"^[0-9]*$");
            if (PositiveInRegex.IsMatch(input) == false)
            {
                mypass = false;
            }
            return mypass;
        }

    }
}
