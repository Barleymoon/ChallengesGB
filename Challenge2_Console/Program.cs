using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue q = new Queue();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);
            q.Enqueue(6);
            q.Dequeue();

            Console.WriteLine("Total number of claims in the Queue are : ");

            Console.WriteLine(q.Count);

            ProgramUI UI = new ProgramUI();
            UI.Run();
        }
    }
}
