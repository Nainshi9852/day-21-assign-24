using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EmpLib;

namespace Assign24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee()
            {
               Id = 1,
               FName = "Navidita",
               LName = "Sharma",
               Salary = 7760000
            };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("C:\\Users\\HP\\Desktop\\Indeed\\Phase-2(C#)\\Day-21\\Employees.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("Binary serialization done");

            //Reading the binary  file
            Console.WriteLine("********Deserialized Data***********");
            using (FileStream fs1 = new FileStream("C:\\Users\\HP\\Desktop\\Indeed\\Phase-2(C#)\\Day-21\\Employees.bin", FileMode.Open))
            {
                Employee employee1 = (Employee)formatter.Deserialize(fs1);
                Console.WriteLine("Employee ID:" + employee1.Id);
                Console.WriteLine("Employee First Name:" + employee1.FName);
                Console.WriteLine("Employee Last Name:" + employee1.LName);
                Console.WriteLine("Employee Salary:" + employee1.Salary);
            }
            Console.WriteLine("\n");
            Console.WriteLine("____________________________________________________________________________________________");

            //XML serialization

            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter textWriter = new StreamWriter("C:\\Users\\HP\\Desktop\\Indeed\\Phase-2(C#)\\Day-21\\Employees.Xml"))
            {
                serializer.Serialize(textWriter, employee);

            }
            Console.WriteLine("XML Serialization done");

            //xml deSerializer
            Console.WriteLine("********Deserialized Data***********");
            using (TextReader textReader = new StreamReader("C:\\Users\\HP\\Desktop\\Indeed\\Phase-2(C#)\\Day-21\\Employees.Xml"))
            {
                Employee emp = (Employee)serializer.Deserialize(textReader);
                Console.WriteLine("Employee ID:" + emp.Id);
                Console.WriteLine("Employee First Name:" + emp.FName);
                Console.WriteLine("Employee Last Name:" + emp.LName);
                Console.WriteLine("Employee Salary:" + emp.Salary);
            }
            Console.ReadKey();
        }
    }
}
