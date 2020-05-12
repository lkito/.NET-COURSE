using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<string> st = new MyStack<string>();
            st.Push("BLAAAAAAA");
            st.Pop();
            st.Push("ULALALA");
            st.Push("RAMEDAME");

            Console.WriteLine("SIZE IS: " + st.Size());
            Console.WriteLine("IS IT EMPTY?: " + st.IsEmpty());
            Console.WriteLine("POP: " + st.Pop());
            Console.WriteLine("SIZE IS: " + st.Size());
            st.Flush();
            Console.WriteLine("SIZE AFTER FLUSHING IS: " + st.Size());
            Console.ReadLine();
        }
    }
}
