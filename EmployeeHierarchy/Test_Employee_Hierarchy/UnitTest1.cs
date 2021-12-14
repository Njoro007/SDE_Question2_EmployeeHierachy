using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace Test_Employee_Hierarchy
{
    public class UnitTest1
    {
        [Fact]
        public void TestInputValidationForSalary()
        {
            //Arrange
            int SalaryExample = 1200;

            //Act
            bool response = Employee.Employee.InputValidateSalary(SalaryExample.ToString());

            //Assert
            Assert.True(response);
        }


        [Fact]
        public void TestEachEmployeeDoesNotHaveMoreThanOneManager()
        {
            //Arrange
            string fileContent = string.Empty;
            var filePath = string.Empty;

            //Get the path of specified file
            filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Employee.csv");

            //Read the contents of the file into a stream
            var fileStream = File.OpenRead(filePath);

            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();
            }

            List<Employee.Employee> employee = new List<Employee.Employee>();
            using (var reader = new StringReader(fileContent))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] values = line.Split(',');

                    employee.Add(new Employee.Employee()
                    {
                        EmployeeID = (values[0]).ToString(),
                        ManagerID = (values[1]).ToString(),
                        Salary = (Employee.Employee.InputValidateSalary(values[2])) ? Convert.ToInt32(values[2]) : throw new FormatException("Salary can only be integers"),
                    });
                }
            }

            //Act
            bool EmployeeDCount = employee.GroupBy(x => x.EmployeeID).Any(group => group.Count() > 1);
            if (EmployeeDCount)
            {
                throw new Exception("One employee can have only one manager");
            }

            //Assert
            Assert.False(EmployeeDCount);
        }


        [Fact]
        public void TestOneCEO()
        {
                //Arrange
                string fileContent = string.Empty;
                var filePath = string.Empty;

                //Get the path of specified file
                filePath = Path.Combine(Directory.GetCurrentDirectory(), @"Employee.csv");

                //Read the contents of the file into a stream
                var fileStream = File.OpenRead(filePath);

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    fileContent = reader.ReadToEnd();
                }

                List<Employee.Employee> employee = new List<Employee.Employee>();
                using (var reader = new StringReader(fileContent))
                {
                    for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                    {
                        string[] values = line.Split(',');

                        employee.Add(new Employee.Employee()
                        {
                            EmployeeID = (values[0]).ToString(),
                            ManagerID = (values[1]).ToString(),
                            Salary = (Employee.Employee.InputValidateSalary(values[2])) ? Convert.ToInt32(values[2]) : throw new FormatException("Salary can only be integers"),
                        });
                    }
                }

                //Act
                if (employee.Where(x => x.ManagerID.Equals("0") || string.IsNullOrWhiteSpace(x.ManagerID)).Count() > 1)
                {
                    throw new Exception("There can only be one CEO");
                }

                //Assert
                Assert.True(true);
        }


        [Fact]
        public void CheckIfManagerIsAnEmployee()
        {
            //Arrange
            string fileContent = string.Empty;
            var filePath = string.Empty;

            //Get the path of specified file
            filePath = Path.Combine(Directory.GetCurrentDirectory(), @"TestEmployee.csv");

            //Read the contents of the file into a stream
            var fileStream = File.OpenRead(filePath);

            using (StreamReader reader = new StreamReader(fileStream))
            {
                fileContent = reader.ReadToEnd();
            }

            List<Employee.Employee> employee = new List<Employee.Employee>();
            List<string> EmployeeIdList = new List<string>();
            List<string> ManagerIdList = new List<string>();
            using (var reader = new StringReader(fileContent))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    string[] values = line.Split(',');

                    employee.Add(new Employee.Employee()
                    {
                        EmployeeID = (values[0]).ToString(),
                        ManagerID = (values[1]).ToString(),
                        Salary = (Employee.Employee.InputValidateSalary(values[2])) ? Convert.ToInt32(values[2]) : throw new FormatException("Salary can only be integers"),
                    });

                    EmployeeIdList.Add((values[0]).ToString());
                    ManagerIdList.Add((values[1]).ToString());
                }
            }

            //Act
            int ManagerIsNotEmployeeCount = employee.Where(x => x.ManagerID != x.EmployeeID).Count();

            bool ManagerIsEmployee = EmployeeIdList.Any(employeeID => ManagerIdList.Any(managerId => managerId == employeeID));

            //Assert
            Assert.True(ManagerIsEmployee);
        }
    }
}
