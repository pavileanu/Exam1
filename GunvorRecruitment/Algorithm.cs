using System;
using System.Linq;

namespace GunvorRecruitment
{
    public class Algorithm
    {
        public string ReverseEveryOtherWord(string inputString)
        {
            string[] words = inputString.Split(' ');

            for (int i= 0; i < words.Length; i++)
            {
                if(i % 2 == 1)
                {
                    char[] array = words[i].ToCharArray();
                    Array.Reverse(array);
                    words[i] = new String(array);
                }
            }

            return string.Join(" ", words);
        }

      
    }
}