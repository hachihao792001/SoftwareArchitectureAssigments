using System;
using System.Collections.Generic;
using System.Text;

namespace DistributedObject
{
    class CObjectManager
    {
        static Dictionary<int, CObject> cObjects = new Dictionary<int, CObject>();

        public static int RegisterObject(CObject cObject)
        {
            int newObjectId = SObjectManager.CreateNewObjectOnServer("Staff");
            cObjects.Add(newObjectId, cObject);

            return newObjectId;
        }

        public static string GetCObjectAttribute(int objectId, string attribName)
        {
            return SObjectManager.GetSObjectAttribute(objectId, attribName);
        }
        public static bool SetCObjectAttribute(int objectId, string attribName, string newValue)
        {
            return SObjectManager.SetSObjectAttribute(objectId, attribName, newValue);
        }
        public static string ExecuteCObjectMethod(int objectId, string methodName, string[] methodParams)
        {
            return SObjectManager.ExecuteSObjectMethod(objectId, methodName, methodParams);
        }
    }
}
