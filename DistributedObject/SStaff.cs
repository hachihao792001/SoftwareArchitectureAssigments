using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedObject
{
    class SStaff : SObject
    {
        const string NameKey = nameof(name);
        const string MonthsWorkedKey = nameof(monthsWorked);
        const string SalaryKey = nameof(salary);
        const string GetTotalSalaryKey = nameof(GetTotalSalary);

        string name;
        int monthsWorked;
        int salary;

        public override string GetAttribute(string attributeName)
        {
            switch (attributeName)
            {
                case NameKey: return name;
                case MonthsWorkedKey: return monthsWorked.ToString();
                case SalaryKey: return salary.ToString();
                default: return base.GetAttribute(attributeName);
            }
        }

        public override bool SetAttribute(string attributeName, string value)
        {
            switch (attributeName)
            {
                case NameKey:
                    name = value;
                    return true;
                case MonthsWorkedKey:
                    monthsWorked = int.Parse(value);
                    return true;
                case SalaryKey:
                    salary = int.Parse(value);
                    return true;
                default:
                    return false;
            }
        }

        int GetTotalSalary()
        {
            return monthsWorked * salary;
        }

        public override string ExecuteMethod(string methodName, string[] methodParams)
        {
            switch (methodName)
            {
                case GetTotalSalaryKey:
                    return GetTotalSalary().ToString();
                default:
                    return base.ExecuteMethod(methodName, methodParams);
            }
        }
    }
}
