using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace lab4_syst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bankResource = 15;
            int[] currentUsage = new int[10];
            int[] maxUsage = { 6, 5, 4, 4, 7, 9, 4, 7, 2, 5 };
            int[] copyMaxUsage = new int[10];
            for (int i = 0; i < 10; i++)
            {
                copyMaxUsage[i] = maxUsage[i];
            }
            bool[] isCompleted = new bool[10];
            while (currentUsage[0] != copyMaxUsage[0] || currentUsage[1] != copyMaxUsage[1] || currentUsage[2] != copyMaxUsage[2] || currentUsage[3] != copyMaxUsage[3]
                || currentUsage[4] != copyMaxUsage[4] || currentUsage[5] != copyMaxUsage[5] || currentUsage[6] != copyMaxUsage[6] || currentUsage[7] != copyMaxUsage[7]
                || currentUsage[8] != copyMaxUsage[8] || currentUsage[9] != copyMaxUsage[9]) 
            {
                if(bankResource <= 0)
                {
                    Console.WriteLine("BANKROT");
                    break;
                }
                Console.WriteLine($"bank: {bankResource}");
                for(int usage = 0; usage < 10; usage++)
                {
                    if (!isCompleted[usage])
                    {
                        if (bankResource + currentUsage[0] > maxUsage[0] || bankResource + currentUsage[1] > maxUsage[1]
                       || bankResource + currentUsage[2] > maxUsage[2] || bankResource + currentUsage[3] > maxUsage[3]
                       || bankResource + currentUsage[4] > maxUsage[4] || bankResource + currentUsage[5] > maxUsage[5]
                       || bankResource + currentUsage[6] > maxUsage[6] || bankResource + currentUsage[7] > maxUsage[7]
                       || bankResource + currentUsage[8] > maxUsage[8] || bankResource + currentUsage[9] > maxUsage[9]
                       )
                        {
                            currentUsage[usage]++;
                            bankResource--;
                        }
                        else
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                if (currentUsage[i] + bankResource == maxUsage[i])
                                {
                                    currentUsage[i] = maxUsage[i];
                                    bankResource = maxUsage[i];
                                    maxUsage[i] = 99;
                                    
                                    isCompleted[i] = true;
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine($"{currentUsage[usage]} || {copyMaxUsage[usage]}");
                }
                Console.WriteLine("-----------");
            }
        }
    }
}
