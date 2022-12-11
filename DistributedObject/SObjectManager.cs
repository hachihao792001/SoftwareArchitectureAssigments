using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedObject
{
    class SObjectManager
    {
        static Dictionary<int, SObject> sObjects = new Dictionary<int, SObject>();
        static int nextAvailableId = 1;

        public static int RegisterObject(SObject sObject)
        {
            int newObjectId = nextAvailableId++;
            sObjects.Add(newObjectId, sObject);
            return newObjectId;
        }

        public static int CreateNewObjectOnServer(string typeName)
        {
            switch (typeName)
            {
                case "Staff":
                    return new SStaff().ID;
                default:
                    return -1;
            }
        }

        public static string GetSObjectAttribute(int objectId, string attribName)
        {
            return sObjects[objectId].GetAttribute(attribName);
        }
        public static bool SetSObjectAttribute(int objectId, string attribName, string newValue)
        {
            return sObjects[objectId].SetAttribute(attribName, newValue);
        }

        public static string ExecuteSObjectMethod(int objectId, string methodName, string[] methodParams)
        {
            return sObjects[objectId].ExecuteMethod(methodName, methodParams);
        }
    }
}
