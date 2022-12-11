using System;

namespace DistributedObject
{
    class Program
    {
        static void Main(string[] args)
        {
            CStaff staff = new CStaff();
            staff.Salary = 3;
            staff.MonthsWorked = 2;
            Console.WriteLine(staff.Name);
            Console.WriteLine(staff.GetTotalSalary());
        }
    }
}
