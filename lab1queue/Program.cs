using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Queuel<int> ql = new Queuel<int>();

            var time = System.Diagnostics.Stopwatch.StartNew(); 

            for (int i = 0; i < 100000; i++)
            {
                ql.Enqueue(i);
            }
            ql.Contains(1);
            ql.Peek();
            for (int i = 0; i < 100000; i++)
            {
                ql.Dequeue();
            }

            time.Stop();
            var res = time.Elapsed;
            string eltime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                res.Hours,
                res.Minutes,
                res.Seconds,
                res.Milliseconds);
            Console.WriteLine("Lab queue - {0}", eltime);


            Queue<int> qd = new Queue<int>();
            time = System.Diagnostics.Stopwatch.StartNew();


            for (int i = 0; i < 100000; i++)
            {
                qd.Enqueue(i);
            }
            qd.Contains(1);
            qd.Peek();
            for (int i = 0; i < 100000; i++)
            {
                qd.Dequeue();
            }

            time.Stop();
            res = time.Elapsed;
            eltime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                res.Hours,
                res.Minutes,
                res.Seconds,
                res.Milliseconds);
            Console.WriteLine("Default queue - {0}", eltime);
            Console.ReadKey();
        }
    }
}
