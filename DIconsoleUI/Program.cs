using DILib;
using System.Collections;
using System.Collections.Generic;

namespace DIconsoleUI
{
    public interface IDAL {
        int MyProperty { get; }

    }
    public class DAL : IDAL
    {
        public int MyProperty { get => 1000;}

        public bool MyPrivateMethod()
        {
            throw new System.NotImplementedException();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            DIContainer dic = new DIContainer();

            dic.Register<IDAL, DAL>();
            //dic.Register<ICollection<string>, IDictionary>();


            var myObject = dic.Resolve<IDAL>();
            System.Console.WriteLine(myObject.GetType());
            System.Console.WriteLine(myObject.MyProperty);
           // System.Console.WriteLine(myObject.MyPrivateMethod());
            //var myObject2 = dic.Resolve<ICollection<string>>();
            //System.Console.WriteLine(myObject2.GetType());
            //System.Console.WriteLine(myObject.MyProperty);





        }
    }
}
