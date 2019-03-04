using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DILib
{
    public class DIContainer
    {
        public DIContainer()
        {
            RegisterTypes = new Dictionary<Type, Type>();
        }
        public IDictionary<Type, Type> RegisterTypes { get; private set; }

        public void Register<T1, T2>()
        {
            var myType = typeof(T1); //.IsAbstract;
            var myType2 = typeof(T2);

            foreach (var m in myType2.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine(m.Name);

            }


            if (myType2.IsAbstract || myType2.IsInterface)
            {
                throw new InvalidOperationException();
            }
            RegisterTypes.Add(myType, myType2);
        }

        public T1 Resolve<T1>()
        {
            var myType = RegisterTypes[typeof(T1)];
            return (T1)Activator.CreateInstance(myType);
        }

    }
}
