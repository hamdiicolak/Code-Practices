using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
class Result
{
    // n -> board size
    // k -> number of obstacle
    // r_q -> row of queen
    // c_q -> column of queen
    // Points of obstacles (r,c) if any
    public static bool isObstacle (int r, int c, List<List<int>> obstacles)
    {
        foreach (var subList in obstacles)
        {
            if (subList[0] == r && subList[1] == c)
                return true;
        }
        return false;
    }

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int possibleMoveCount = 0;
        List<List<int>> queenMoves = new List<List<int>>();
        int local_r_q = r_q, local_c_q = c_q;
        //upper
        while (local_r_q + 1 <= n)
        {
            if (!isObstacle(local_r_q + 1, local_c_q, obstacles))
            {
                possibleMoveCount++;
                local_r_q++;
            }
            else
                break;
        }

        local_r_q = r_q;
        //lower
        while (local_r_q - 1 >= 1)
        {
            if (!isObstacle(local_r_q - 1, local_c_q, obstacles))
            {
                possibleMoveCount++;
                local_r_q--;
            }
            else
                break;
        }
        local_r_q = r_q;
        //right
        while (local_c_q + 1 <= n)
        {
            if (!isObstacle(local_r_q, local_c_q + 1, obstacles))
            {
                possibleMoveCount++;
                local_c_q++;
            }
            else
                break;
        }

        local_c_q = c_q;
        //left
        while (local_c_q - 1 >= 1)
        {
            if (!isObstacle(local_r_q, local_c_q - 1, obstacles))
            {
                possibleMoveCount++;
                local_c_q--;
            }
            else
                break;
        }
        local_c_q = c_q;
        //upperrightcross
        while (local_r_q + 1 <= n && local_c_q + 1 <= n)
        {
            if (!isObstacle(local_r_q + 1, local_c_q + 1, obstacles))
            {
                possibleMoveCount++;
                local_r_q++;
                local_c_q++;
            }
            else
                break;
        }

        local_r_q = r_q; local_c_q = c_q;
        //upperleftcross
        while (local_r_q + 1 <= n && local_c_q - 1 >= 1)
        {
            if (!isObstacle(local_r_q + 1, local_c_q - 1, obstacles))
            {
                possibleMoveCount++;
                local_r_q++;
                local_c_q--;
            }
            else
                break;
        }

        local_r_q = r_q; local_c_q = c_q;
        //lowerrightcross
        while (local_r_q - 1 >= 1 && local_c_q + 1 <= n)
        {
            if (!isObstacle(local_r_q - 1, local_c_q + 1, obstacles))
            {
                possibleMoveCount++;
                local_r_q--;
                local_c_q++;
            }
            else
                break;
        }

        local_r_q = r_q; local_c_q = c_q;
        //lowerleftcross
        while (local_r_q - 1 >= 1 && local_c_q - 1 >= 1)
        {
            if (!isObstacle(local_r_q - 1, local_c_q - 1, obstacles))
            {
                possibleMoveCount++;
                local_r_q--;
                local_c_q--;
            }
            else
                break;
        }

        return possibleMoveCount;
    }
}

class Solution  
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());       
        }

        Console.WriteLine(Result.queensAttack(n, k, r_q, c_q, obstacles));
    }
}

// The alternative solution
// class Solution {
//     static int n;
//     static void Main(String[] args) {
//         var tmp = Console.ReadLine().Split(' ');
//         n = int.Parse(tmp[0]);
//         int k = int.Parse(tmp[1]);
//         tmp = Console.ReadLine().Split(' ');
//         int rq = int.Parse(tmp[0]) - 1;
//         int cq = int.Parse(tmp[1]) - 1;
//         HashSet<long> h = new HashSet<long>();
//         for (int i = 0; i < k; i++) {
//             tmp = Console.ReadLine().Split(' ');
//             long a = long.Parse(tmp[0]) - 1;
//             long b = long.Parse(tmp[1]) - 1;
//             h.Add(a << 31 | b);
//         }
        
        
//         long x = 0, y = 0;
//         int[] _u = { 1, 1, 1, 0, 0, -1, -1, -1 };
//         int[] _v = { 0, 1, -1, 1, -1, -1, 0, 1 };
//         int ans = 0;
//         for (int i = 0; i < 8; i++) {
//             int u = _u[i], v = _v[i];
//             x = rq + u; y = cq + v;
//             while (valid(x, y)) {
//                 if (h.Contains(x << 31 | y)) break;
//                 ans++;
//                 x += u; y += v;
//             }
//         }
//         Console.WriteLine(ans);
//     }
//     private static bool valid(long x, long y) {
//         return x >= 0 && y >= 0 && x < n && y < n;
//     }
// }
