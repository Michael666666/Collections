using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsDemo {
    class ListClass {
        public static void GetListProperty () {
            List<int> intList = new List<int> ();
            Console.WriteLine ($"初始容量大小：{intList.Capacity}");

            intList.Add (2);
            Console.WriteLine ($"添加一个元素后，容量大小为：{intList.Capacity}");

            intList.Capacity = 5;
            Console.WriteLine ($"设置了指定的容量大小为5后：{intList.Capacity}");

            intList.AddRange (new [] { 3, 7, 4, 1, 6 });
            Console.WriteLine ($"添加五个元素后，容量大小为：{intList.Capacity}");

            intList.TrimExcess ();
            Console.WriteLine ($"使用TrimExcess清空多于空间后，容量大小为：{intList.Capacity}");

            intList.Insert (2, 2);
            Console.WriteLine ($"下标为2的值为：{intList[2]}");

            intList.RemoveAt (2); //删除索引为2的元素
            intList.Remove (6); //删除元素6
            intList.RemoveRange (3, 1); //删除索引为3及之后的2个元素
            intList.RemoveAll (a => a > 3); //删除值大于3的元素

            foreach (var list in intList) {
                Console.WriteLine (list);
            }
            Console.WriteLine ("-------------");

            // intList.Sort ();
            // foreach (var list in intList) {
            //     Console.WriteLine (list);
            // }
            // Console.WriteLine ("--------------");

            // intList.Sort ((x, y) => -x.CompareTo (y));
            // foreach (var list in intList) {
            //     Console.WriteLine (list);
            // }
            // Console.WriteLine ("---------------");

            // intList.ForEach (num => Console.WriteLine (num));
        }
    }
}