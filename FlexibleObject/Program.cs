using System;
using System.Collections.Generic;

namespace FlexibleObject
{
    class MySingleton
    {
        static int maxInstance = 2;
        static int instanceCount = 0;

        private static List<MySingleton> _instances = new List<MySingleton>();
        public static MySingleton BuildInstance()
        {
            if (instanceCount < maxInstance)
            {
                MySingleton newInstance = new MySingleton();
                instanceCount++;
                _instances.Add(newInstance);
                return newInstance;
            }
            return null;
        }

        public static MySingleton GetInstance(int index)
        {
            if (index < 0 || index >= maxInstance)
                return null;
            return _instances[index];
        }
    }

    class MyObject
    {
        public static List<MyObject> allObjects = new List<MyObject>();

        public Dictionary<string, object> attributes = new Dictionary<string, object>();
        public Dictionary<string, Action<object[]>> methods = new Dictionary<string, Action<object[]>>();

        bool autoAddNew = true;

        public MyObject()
        {
            RegisterObject(this);
        }

        public MyObject(string predefinedType)
        {
            if (predefinedType == "Phân số")
            {
                attributes.Add("Tử số", 0);
                attributes.Add("Mẫu số", 1);
                autoAddNew = false;
            }
            RegisterObject(this);
        }

        public void RegisterObject(MyObject obj)
        {
            allObjects.Add(obj);
        }

        public bool SetAttribute(string name, object value)
        {
            if (attributes.ContainsKey(name))
            {
                attributes[name] = value;
                return true;
            }
            if (autoAddNew)
            {
                attributes.Add(name, value);
                return true;
            }
            return false;
        }

        public object GetAttribute(string name)
        {
            if (attributes.ContainsKey(name))
                return attributes[name];
            else
                return null;
        }

        public bool SetMethod(string name, Action<object[]> action)
        {
            if (methods.ContainsKey(name))
            {
                methods[name] = action;
                return true;
            }
            if (autoAddNew)
            {
                methods.Add(name, action);
                return true;
            }
            return false;
        }

        public bool InvokeMethod(string name, object[] methodParams)
        {
            if (methods.ContainsKey(name))
            {
                methods[name].Invoke(methodParams);
                return true;
            }
            return false;
        }

        public object this[string name]
        {
            get
            {
                return GetAttribute(name);
            }
            set
            {
                SetAttribute(name, value);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyObject phanso = new MyObject();
            phanso["Tử số"] = 1;
            phanso["Mẫu số"] = 3;
            phanso.SetMethod("Nhân", (par) =>
            {
                MyObject other = (MyObject)par[0];
                phanso["Tử số"] = (int)phanso["Tử số"] * (int)other["Tử số"];
                phanso["Mẫu số"] = (int)phanso["Mẫu số"] * (int)other["Mẫu số"];
            });

            Console.WriteLine(phanso["Tử số"].ToString() + " " + phanso["Mẫu số"].ToString());

            MyObject phanso2 = new MyObject("Phân số");
            phanso2["Tử số"] = 2;
            phanso2["Mẫu số"] = 4;
            phanso.InvokeMethod("Nhân", new object[] { phanso2 });
            Console.WriteLine(phanso["Tử số"].ToString() + " " + phanso["Mẫu số"].ToString());
        }
    }
}
