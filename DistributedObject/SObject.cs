using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedObject
{
    class SObject
    {
        public int ID;

        public SObject()
        {
            ID = SObjectManager.RegisterObject(this);
        }

        public virtual string GetAttribute(string attributeName)
        {
            return "";
        }

        public virtual bool SetAttribute(string attributeName, string value)
        {
            return true;
        }

        public virtual string ExecuteMethod(string methodName, string[] methodParams)
        {
            return "";
        }
    }
}
