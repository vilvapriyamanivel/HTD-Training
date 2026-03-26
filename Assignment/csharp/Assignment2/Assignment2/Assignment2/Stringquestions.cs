using System;


namespace Assignment2
{
    public class Strassignment
    {
        public static void Main(string[] args)
        {
            Strassignment str = new Strassignment();
            str.wordlength();
            str.reverseword();
            str.sameword();
        }
        public void wordlength()
        {
            Console.Write("Enter a string:");
            string s1 = Console.ReadLine();
            int f = 0;
            int l = s1.Length;
            while (s1[f] == ' ')
            {
                f++;
            }
            while (s1[l - 1] == ' ')
            {
                l--;
            }
            int count = 0;
            for (int i = f; i < l; i++)
            {
                count++;
            }
            Console.WriteLine($"The length of the string is {count}");
        }

        public void reverseword()
        {
            Console.Write("Enter a string:");
            string s1 = Console.ReadLine();
            for (int i = s1.Length - 1; i >= 0; i--)
            {
                Console.Write(s1[i]);
            }
        }
        public void sameword()
        {
            Console.Write("Enter first string:");
            string s1 = Console.ReadLine();
            Console.Write("Enter second string:");
            string s2 = Console.ReadLine();
            if (s1 == s2)
            {
                Console.WriteLine("The two strings are same.");
            }
            else
            {
                Console.WriteLine("The two strings are different.");
            }
        }
    }
}

