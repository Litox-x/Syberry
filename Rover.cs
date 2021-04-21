using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{
    public class Rover
    {

        public static void CalculateRoverPath(int[,] map)
        {
            int l1 = -1, r1 = -1;
            int n = map.GetLength(0);
            int m = map.GetLength(1);
            int ans;
            bool[,] isvisited = new bool[n, m];
            int[,] way = new int[2, n * m];
            int stepscount = 0;
            int calculate(int l, int r)
            {
                if (l1 != -1 && r1 != -1)
                    isvisited[l1, r1] = true;
                if (isvisited[l, r] == true)
                    return int.MaxValue-1000;
                isvisited[l, r] = true;
                //way[0, stepscount] = l;
                //way[1, stepscount] = r;
                stepscount++;

                if (l == 0 && r == 0)
                {
                    isvisited = new bool[n, m];
                    return 0;
                }
                else
                if (n == 1)
                {
                    return calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1;
                }
                else
                if (m == 1)
                {
                    return calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1;

                }
                else
                if (l == 0 && r != m - 1)
                {
                    return Math.Min(calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1, calculate(l + 1, r) + Math.Abs(map[l, r] - map[l + 1, r]) + 1);
                }
                else
                if (l == 0 && r == m - 1)
                {
                    return calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1;
                }
                else
                if (r == 0 && l != n - 1)
                {
                    return Math.Min(calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1, calculate(l, r + 1) + Math.Abs(map[l, r] - map[l, r + 1]) + 1);
                }
                else
                if (r == 0 && l == n - 1)
                {
                    return calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1;
                }
                else
                if (l == n - 1 && r != 0 && r != m - 1)
                {
                    return Math.Min(calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1, calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1);
                }
                else
                if (l != 0 && l != n - 1 && r == m - 1)
                {
                    return Math.Min(calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1, calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1);
                }
                else
                if (l == n - 1 && r == m - 1)
                {
                    return Math.Min(calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1, calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1);
                }
                else
                {
                    Console.WriteLine("suka cicle");
                    l1 = l; r1 = r;

                    int a = calculate(l + 1, r) + Math.Abs(map[l, r] - map[l + 1, r]) + 1;
                    int b = calculate(l, r + 1) + Math.Abs(map[l, r] - map[l, r + 1]) + 1;
                    int c = calculate(l - 1, r) + Math.Abs(map[l, r] - map[l - 1, r]) + 1;
                    int d = calculate(l, r - 1) + Math.Abs(map[l, r] - map[l, r - 1]) + 1;

                    return Math.Min(Math.Min(Math.Min(a, b), c), d);     
                }

            }

            ans = calculate(n - 1, m - 1);

            using (StreamWriter sw = new StreamWriter("path-plan.txt", false, System.Text.Encoding.Default))
            {
                
              //  for(int i=0;i<stepscount;i++)
                {
               //     sw.Write($"[{way[0,i]}][{way[1, i]}]->");
                }
                sw.WriteLine($"\nsteps:{stepscount.ToString()}");

                sw.WriteLine($"fuel:{ans.ToString()}");

            }
        }

    }

}
