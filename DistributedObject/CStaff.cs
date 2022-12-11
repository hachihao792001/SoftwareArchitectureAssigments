using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedObject
{
    class CStaff : CObject
    {
        const string NameKey = "name";
        const string MonthsWorkedKey = "monthsWorked";
        const string SalaryKey = "salary";
        const string GetTotalSalaryKey = "GetTotalSalary";

        public CStaff()
        {
            Name = "NewStaff";
            MonthsWorked = 1;
            Salary = 1;
        }

        public string Name
        {
            get
            {
                return GetAttribute(NameKey);
            }
            set
            {
                SetAttribute(NameKey, value);
            }
        }

        public int MonthsWorked
        {
            get
            {
                return int.Parse(GetAttribute(MonthsWorkedKey));
            }
            set
            {
                SetAttribute(MonthsWorkedKey, value.ToString());
            }
        }
        public int Salary
        {
            get
            {
                return int.Parse(GetAttribute(SalaryKey));
            }
            set
            {
                SetAttribute(SalaryKey, value.ToString());
            }
        }

        public int GetTotalSalary()
        {
            return int.Parse(ExecuteMethod(GetTotalSalaryKey, null));
        }
    }
}
