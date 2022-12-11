using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedObject
{
    class CObject
    {
        public int ID;

        public CObject()
        {
            ID = CObjectManager.RegisterObject(this);
        }

        public string GetAttribute(string attributeName)
        {
            return CObjectManager.GetCObjectAttribute(ID, attributeName);
        }

        public bool SetAttribute(string attributeName, string value)
        {
            return CObjectManager.SetCObjectAttribute(ID, attributeName, value);
        }

        public string ExecuteMethod(string methodName, string[] methodParams)
        {
            return CObjectManager.ExecuteCObjectMethod(ID, methodName, methodParams);
        }
    }
}
