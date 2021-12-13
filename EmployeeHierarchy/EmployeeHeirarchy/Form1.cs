using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Employee;

namespace EmployeeHeirarchy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectCSVFile_Click(object sender, System.EventArgs e)
        {
            string fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //Verify Selected File is a CSV File Only
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "csv files (*.csv)|*.csv";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            Employee.Employee employee;
            employee = new Employee.Employee(fileContent);

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);


            //List<Employee.Employee> values = File.ReadAllLines(filePath).Skip(1)
            //                               .Select(v => Employee.Employee(v))
            //                               .ToList();



            
        }
    }
}
