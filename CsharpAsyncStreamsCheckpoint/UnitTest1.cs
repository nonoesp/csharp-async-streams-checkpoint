using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CsharpAsyncStreamsCheckpoint
{
    [TestClass]
    public class TestsBefore
    {

        [TestMethod]
        public async Task Test1()
        {
            string result = "";
            await foreach (var student in GetStudentsAsync())
            {
                result = result + ($"{student.FirstName} {student.LastName} - ");
            }

            Assert.AreEqual("John Doe - Jane Doe - John Smith - ", result);
        }

        static async IAsyncEnumerable<Student> GetStudentsAsync()
        {
            await Task.Delay(1000);
            yield return new Student() { FirstName = "John", LastName = "Doe", Email = "john.doe@gmail.com", Grade = 'A' };
            await Task.Delay(1000);
            yield return new Student() { FirstName = "Jane", LastName = "Doe", Email = "jane.doe@galvanize.com", Grade = 'B' };
            await Task.Delay(1000);
            yield return new Student() { FirstName = "John", LastName = "Smith", Email = "john.smith@galvanize.com", Grade = 'C' };
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public char Grade { get; set; }
    }
}
