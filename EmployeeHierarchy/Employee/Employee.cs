using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Employee
{
    public class Employee
    {
        public string EmployeeID { get; set; }
        public string ManagerID { get; set; }
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
                List<string> EmployeeIdList = new List<string>();
                List<string> ManagerIdList = new List<string>();
                _Employee.Clear();

                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] values = line.Split(',');

                    _Employee.Add(new Employee()
                    {
                        EmployeeID = (values[0]).ToString(),
                        ManagerID = (values[1]).ToString(),
                        Salary = (InputValidateSalary(values[2])) ? Convert.ToInt32(values[2]) : throw new FormatException("Salary can only be integers"),
                    });

                    EmployeeIdList.Add((values[0]).ToString());
                    ManagerIdList.Add((values[1]).ToString());
                }

                /*//Check if Salary Validates Integer
                foreach (var obj in _Employee)
                {
                    if (InputValidateSalary(obj.Salary.ToString()).Equals(false))
                    {
                        throw new FormatException("Salary can only be integers");
                    }
                }*/


                // Tracking each employee does not have more than one manager
                bool EmployeeDCount = _Employee.GroupBy(x => x.EmployeeID).Any(group => group.Count() > 1);
                if (EmployeeDCount)
                {
                    throw new Exception("One employee can have only one manager");
                }

                // Check if there is one ceo
                if (_Employee.Where(x => x.ManagerID.Equals("0") || string.IsNullOrWhiteSpace(x.ManagerID)).Count() > 1)
                {
                    throw new Exception("There can only be one CEO");
                }


                //Check if Manager is an Employee
                int ManagerIsNotEmployeeCount = _Employee.Where(x => x.ManagerID != x.EmployeeID).Count();

                bool ManagerIsEmployee = EmployeeIdList.Any(employeeID => ManagerIdList.Any(managerId => managerId == employeeID));

                /*if (ManagerIsNotEmployeeCount > 0)
                {
                    throw new Exception("Manager must be an Employee");
                }*/

                if (ManagerIsEmployee.Equals(false))
                {
                    throw new Exception("Manager must be an Employee");
                }
            }
        }



        //Instance Sum Salary Budget
        public static int BudgetSalary(string ManagerID, List<Employee> _Employee)
        {
            int salary = 0;
            int ManagerSalary = 0;
            int EmployeeSalary = 0;

            ManagerSalary = _Employee.Where(x => x.ManagerID.Equals(ManagerID)).SingleOrDefault().Salary;

            var group = _Employee.GroupBy(x => x.ManagerID.Equals(ManagerID));

            foreach (var managerGroup in group)
            {
                foreach (var employee in managerGroup)
                {
                    EmployeeSalary += employee.Salary;
                }
            }

            salary = ManagerSalary + EmployeeSalary;

            return salary;
        }



        //Input Validation for salary
        public static bool InputValidateSalary(string input)
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
