using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace EmployeeLib.Model
{
    public class EmploymentAgency
    {
        public static IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>
            {
                new Employee
                    {
                        FullName = "Marek Marecki",
                        BirthDate = new DateTime(1985,10,23),
                        IsManager = false,
                        Photo = GetImageBytes(@"..\EmployeesManagement\Images\icon1.jpg")
                    },
                new Employee
                    {
                        FullName = "Jan Brzeczyszczykiewicz",
                        BirthDate = new DateTime(1967,3,17),
                        IsManager = true,
                        Photo = GetImageBytes(@"..\EmployeesManagement\Images\icon2.jpg")
                    },
                new Employee
                    {
                        FullName = "Bozena Bor",
                        BirthDate = new DateTime(1982,08,11),
                        IsManager = false,
                        Photo = GetImageBytes(@"..\EmployeesManagement\Images\icon3.jpg")
                    },
               new Employee
                   {
                       FullName = "Adam Galant",
                       BirthDate = new DateTime(1978,12,18),
                       IsManager = true,
                       Photo = GetImageBytes(@"..\EmployeesManagement\Images\icon2.jpg")
                   },
                new Employee
                    {
                        FullName = "Mariusz Strach",
                        BirthDate = new DateTime(1990,5,13),
                        IsManager = false,
                        Photo = GetImageBytes(@"..\EmployeesManagement\Images\icon4.jpg")
                    },
                new Employee
                    {
                        FullName = "Ilona Krochmal",
                        BirthDate = new DateTime(1980,9,6),
                        IsManager = false,
                       Photo = GetImageBytes(@"..\EmployeesManagement\Images\icon5.jpg")
                    }
            };
            return employees;
        }

        private static byte[] GetImageBytes(string path)
        {
            if (!File.Exists(path))
                return null;

            var image = Image.FromFile(path);
            byte[] arr;
            using (var memoeryStream = new MemoryStream())
            {
                image.Save(memoeryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr = memoeryStream.ToArray();
            }
            return arr;
        }
    }
}
