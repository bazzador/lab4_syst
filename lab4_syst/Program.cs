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
            int bankResource = 10;
            int[] currentUsage = new int[4];
            int[] maxUsage = new int[4];
            int[] copyMaxUsage = new int[4];
            maxUsage[0] = 6;
            maxUsage[1] = 5;
            maxUsage[2] = 4;
            maxUsage[3] = 7;
            for (int i = 0; i < 4; i++)
            {
                copyMaxUsage[i] = maxUsage[i];
            }
            bool[] isCompleted = new bool[4];
            while (currentUsage[0] != copyMaxUsage[0] || currentUsage[1] != copyMaxUsage[1] || currentUsage[2] != copyMaxUsage[2] || currentUsage[3] != copyMaxUsage[3])
            {
                Console.WriteLine($"bank: {bankResource}");
                for(int usage = 0; usage < 4; usage++)
                {
                    if (!isCompleted[usage])
                    {
                        if ((bankResource + currentUsage[0] > maxUsage[0] || bankResource + currentUsage[1] > maxUsage[1] ||
                       bankResource + currentUsage[2] > maxUsage[2] || bankResource + currentUsage[3] > maxUsage[3]))
                        {
                            currentUsage[usage]++;
                            bankResource--;
                        }
                        else
                        {
                            for (int i = 0; i < 4; i++)
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
