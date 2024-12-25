using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 自製linklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
           DexterList<int> list = new DexterList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);


            //list.Remove("C");
            //list.Remove("A");
            //list.Remove("G");


            //list.Insert(9, "F");

            //DexterList list2 = new DexterList();
            //list2.Add("L");
            //list2.Add("K");
            //list.AddRange(list2);//加尾端

            //DexterList list3 = new DexterList();
            //list3.Add("B");
            //list3.Add("C");
            //list.RemoveRange(list, list3);//找到一段符合的

            //Hw1: 思考為甚麼AddRange過後再次新增資料會跑不出來?
            //Hw2: 如何解決 or 如何預防/檢測問題發生?

            //DexterList<int> list2 = new DexterList<int>();
            //list2.Add(1);
            //list2.Add(2);
            //list2.Add(3);
            //list.Add(4);

            //list.RemoveRange(list2);


            //for (int i = 0; i < list.Count; i++)
            //{
            //    Console.WriteLine(list[i]);
            //}




            DexterList<Student> dexterList = list.Select(
                x =>
                {
                    if (x % 2 == 0)
                        x =  x * 2;
                    x = x;
                    Student student = new Student();
                    student.Id = x;
                    student.Name = "Mary";
                    return student;

                });


            foreach(Student data in dexterList)
            {
                Console.WriteLine(data.Id);
                Console.WriteLine(data.Name);
            }


            Console.ReadLine();


        }
    }
}
