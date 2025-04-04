using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helloworld
{
    internal class strings3
    {
        //3.Write a program in C# to accept two words from user and find out if they are same.

        public static bool check(string first, string second)
        {
            
            if (first.Length != second.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (first[i] != second[i])
                    {
                        return false;
                    }
                }
                    return true;

                
            }
        }
    }
}

