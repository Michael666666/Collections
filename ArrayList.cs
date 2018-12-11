using System;
using System.Collections;

namespace CollectionsDemo{
    class ArrayListClass{
        public static void arrayListOperation(){
            ArrayList myAL=new ArrayList();
            myAL.Add("Hello");
            myAL.Add("World");           
            myAL.Add("!");         
         
            Console.WriteLine(" Count:   {0}",myAL.Count);
            Console.WriteLine(" Capacity:{0}",myAL.Capacity);
          
            string[] strArray={"123","456"};
            myAL.AddRange(strArray);
            Console.WriteLine($" newCapacity:{myAL.Capacity}");

        }

        public static void PrintValues(IEnumerable myList){
            foreach(var obj in myList)
                Console.Write(" {0}",obj);
            Console.WriteLine();
        }
    } 
}