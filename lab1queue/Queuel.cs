using System.Collections.Generic;

namespace lab1queue
{
    // if count == 0    queuel.pop() +exception
    public class Queuel<T>
    {
        Stack<T> s1, s2;
        private int _count;
        public int Count { get { return _count; } }


        public Queuel()
        {            
            s1 = new Stack<T>();
            s2 = new Stack<T>();
            _count = 0;
        }
       
        /// <summary>
        /// Add item to queue
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            s1.Push(item);
            _count++;
        }

        /// <summary>
        /// Remove item from queue
        /// </summary>
        /// <returns></returns>
        public T Dequeue()
        {
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                    s2.Push(s1.Pop());
            }
            _count--;
            return s2.Pop();
        }

        /// <summary>
        /// Show first item
        /// </summary>
        /// <returns></returns>
        public T Peek()
        {
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                    s2.Push(s1.Pop());
            }
            return s2.Peek();
        }

        public void Clear()
        {
            s1.Clear();
            s2.Clear();
        }


       
        public bool Contains(T item)
        {
            if (Count == 0) return false;
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                {
                    if (s1.Peek().Equals(item))
                        return true;
                    s2.Push(s1.Pop());
                }
                return false;
            }

            bool answ = false;
            if (s1.Count == 0)
            {
                while(s2.Count != 0)
                {
                    if (s2.Peek().Equals(item))
                    {
                        answ = true;
                        break;
                    }
                    s1.Push(s2.Pop());
                }
                while (s1.Count != 0)
                    s2.Push(s1.Pop());
                return answ;
            }


            int s1ind = s1.Count;
            int s2ind = s2.Count;
            int i;
            // s1 items -> s2
            for (i = 0; i < s1ind; i++)
            {
                if (s1.Peek().Equals(item))
                {
                    answ = true;
                    break;
                }
                s2.Push(s1.Pop());
            }
            if (answ)   //back items to their prev position
            {
                for (i = i - 1; i >= 0; i--)
                    s1.Push(s2.Pop());
                return answ;
            }
            // s1 items from s2 -> s1 
            for (i = i - 1; i >= 0; i--)
                s1.Push(s2.Pop());

            //s2 items -> s1
            for (i = 0; i < s2ind; i++)
            {
                if (s2.Peek().Equals(item))
                {
                    answ = true;
                    break;
                }
                s1.Push(s2.Pop());
            }
            if (answ)   //back items to their prev position
            {
                for (i = i - 1; i >= 0; i--)
                    s2.Push(s1.Pop());
                return answ;
            }
            return answ;
        }
    }
}
