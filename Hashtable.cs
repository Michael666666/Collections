using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsDemo{
    class HashTableClass{
        public static void hashTableOperation(){
            Hashtable hashtable=new Hashtable();
            hashtable.Add("E","e");
            hashtable.Add("A","a");
            hashtable.Add("B","b");
            hashtable.Add("C","c");

            hashTableOutput(hashtable);

            ArrayList arrayList=new ArrayList(hashtable.Keys);
            arrayList.Sort();
            Console.WriteLine("排序后:");
            foreach(var array in arrayList)
                Console.WriteLine($"key:{array},value:{hashtable[array]}");

            string s=(string)hashtable["A"];
            if(hashtable.Contains("E"))
                Console.WriteLine("THE E KEY EXIST");
            hashtable.Remove("C");
            Console.WriteLine(hashtable["A"]);
            hashtable.Clear();
            Console.WriteLine($"----{hashtable["A"]}----");

            Dictionary<object,object> dic=new Dictionary<object,object>(); //字典
            Hashtable ht=new Hashtable(); //哈希表
        }

        /// <summary>
        /// 遍历哈希表
        /// </summary>
        /// <param name="hashtable"></param>
        public static void hashTableOutput(Hashtable hashtable){
            foreach(DictionaryEntry  table in hashtable)
                Console.WriteLine($"key:{table.Key},value:{table.Value}");
        }
    }
}