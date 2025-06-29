using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace dzStek
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводить данные через пробел:");
            string input = Console.ReadLine();
            var separators = new char[] { ' ' };
            var words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Stack<KeyValuePair<string, int>> st = new Stack<KeyValuePair<string, int>>();

            foreach (string slovo in words)
            {
                int prior = Prioritet(slovo);
                if(prior!=-1)
                {
                    if (slovo == ")" && st.Peek().Key == "(")
                    {
                        st.Pop();
                    }
                    else if (slovo == "]" && st.Peek().Key == "[")
                    {
                        st.Pop();
                    }
                    else if (slovo == ">" && st.Peek().Key == "<")
                    {
                        st.Pop();
                    }
                    else
                    {
                        st.Push(new KeyValuePair<string, int>(slovo, prior));
                    }
                }
            }
            if (st.Count == 0)
                Console.WriteLine("баланс не нарушен");
            else Console.WriteLine("баланс нарушен");
            Console.ReadKey();
        }
        static int Prioritet(string input)
        {
            int prior;
            switch (input)
            {
                case "(": case "[": prior = 0; break;
                case ")": case "]": prior = 1; break;
                case ">": case "<": prior = 6; break;
                default: prior = -1; break;
            }
            return prior;
        }
    }
}
