using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace 自製linklist
{
    internal class DexterList<T> : IEnumerable, IEnumerator
    {

        public Node<T> head = null;
        public int Count = 0;
        private int index = -1;
        public object Current { 

            get { return this[this.index]; }
        }


        public T this[int i]
        {
            
            get {

                Node<T> tempNode = head;
                for (int j = 0; j < i; j++)
                {

                    tempNode = tempNode.Next;

                }

                return tempNode.Body; }
            set {

                Node<T> tempNode = head;
                for (int j = 0; j < i; j++)
                {

                    tempNode = tempNode.Next;

                }
               tempNode.Body = value;
            }
        }
    



        public void Add(T data)
            {

                if (head == null)
                {
                    head = new Node<T>(data);
                }
                else
                {
                    Node<T> tempNode = head;
                    while (tempNode.Next != null)
                    {
                        tempNode = tempNode.Next;
                    }
                    tempNode.Next = new Node<T>(data);
                }

                Count++;

            }

        public void Remove(T data)
        {
            Node<T> prenode = null;
            Node<T> tempNode = head;

            if (tempNode.Body.Equals(data))
            {

                head = head.Next;

            }
            else
            {
                while (!tempNode.Body.Equals(data))
                {
                    prenode = tempNode;
                    tempNode = tempNode.Next;
                    if (tempNode == null)
                    {
                        break;
                    }
                }
            }

            if (prenode != null && tempNode != null)
            {

                prenode.Next = tempNode.Next;

            }


            Count--;



        }


        //tempNode類指針，移動到哪裡就開始接
        public void Insert(int position, T data)
        {

            Node<T> tempNode = head;
            Node<T> preNode = null;
            Node<T> newNode = new Node<T>(data);
            for (int i = 0; i < position ; i++)
            {
                preNode = tempNode;
                tempNode = tempNode.Next;
                if(tempNode == null)
                {
                    
                    break;
                }
               
            }

            if (tempNode != null && preNode!=null)
            {
                preNode.Next = newNode;
                newNode.Next = tempNode;

            }
            else
            {
                newNode.Next = tempNode;
                head = newNode;
            }

            Count++;

        }

        public void AddRange(DexterList<T> list2)
        {

            /// = 是用指針的方式賦值不是使用新的記憶體，所以list 
            /// addrange list會把指針指回去自己。淺複製（Shallow Copy）
            //Node tempNode = head;
            //Node preNode = null;
            //while(tempNode != null)
            //{
            //    preNode= tempNode;
            //    tempNode = tempNode.Next;
            //    Count++;
            //}
            //preNode.Next = list2.head;

            //Node CurrentNode = list2.head;
            //Node DeepCopy = null;
            //Node TempNode = DeepCopy;
            
            //while (CurrentNode != null)
            //{
            //    Node newNode = new Node(CurrentNode.Body);
            //    if (DeepCopy == null)
            //    {
            //        DeepCopy = newNode;
            //        TempNode = newNode;
            //    }
            //    else
            //    {
            //        TempNode.Next = newNode;
            //        TempNode = TempNode.Next;

            //    }
            //    Count++;
            //    CurrentNode = CurrentNode.Next;
            //}

            Node<T> preNode = head;
            while(preNode.Next != null)
            {
                preNode = preNode.Next;
            }
            preNode.Next = list2.head;
            bool Circular = CheckCircularList(preNode);

            if (Circular)
            {
                preNode.Next = null;
            }
           
        }


        private bool CheckCircularList(Node<T> node)
        {

            Node<T> Slow = node;
            Node<T> Fast = node;

            while(Slow != null)
            {

                Slow = Slow.Next;
                Fast = Fast.Next.Next;
                if(Slow == Fast)
                {
                    return true;
                    
                }

            }
            return false; 
        }

        public void RemoveRange(DexterList<T> list)
        {


            for (int i = 0; i < this.Count; i++)
            {
                for(int j = 0;j<list.Count;j++)
                {

                    if (this[i].Equals(list[j]))
                    {
                        Remove(list[j]);
                    }

                }

            }


            //Node tempNode = head;
            //Node list2Node = list2.head;
            //while(tempNode!=null)
            //{

            //    if(tempNode.Body == list2Node.Body)
            //    {
            //        list1.Remove(list2Node.Body);
            //        list2Node = list2Node.Next;
            //        if(list2Node==null)
            //        {
            //            break;
            //        }
            //        Count--;
            //    }
            //    tempNode = tempNode.Next;

            //}

        }


        public DexterList<T2> Select<T2>(Func<T, T2> callback)
        {
            DexterList<T2> newList = new DexterList<T2>();

            for (int i = 0; i < this.Count; i++)
            {
                var item = callback.Invoke(this[i]);

                newList.Add(item);

            }
            return newList;
        }

        public  DexterList<T> Where(Func<T, bool> callback)
        {
            DexterList<T> newList = new DexterList<T>();
            for(int i = 0; i < this.Count; i++)
            {


                var item = callback.Invoke(this[i]);
                if (item)
                {
                    newList.Add(this[i]);

                }

            }
            return newList;
        }

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        public bool MoveNext()
        {
            this.index++;
            return this.index >= this.Count? false : true;
        }

        public void Reset()
        {
            index = -1;
        }
    }


}
