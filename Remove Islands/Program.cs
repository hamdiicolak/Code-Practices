using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoveIslands
{
    class Program
    {
        public static Dictionary<(int,int) , bool> matrixInfo = new Dictionary<(int, int), bool>();
        static void Main(string[] args)
        {
// 6
// 1 0 0 0 0 0
// 0 1 0 1 1 1
// 0 0 1 0 1 0
// 1 1 0 0 1 0
// 1 0 1 1 0 0
// 1 0 0 0 0 1
            // Remove 1's that is not connected to the border
            int n = Convert.ToInt32(Console.ReadLine().Trim());
            int [,] matrix = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                string[] matrixRow = Console.ReadLine().TrimEnd().Split(' ');
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(matrixRow[j]);
                }
            }
            RemoveIslands(n,matrix);

            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(matrix[i,j] == 1 && !matrixInfo[(i,j)])
                        matrix[i,j] = 0;
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void FindNeighbor(int n, int mi, int mj, int [,] matrix)
        {
            // left neigh (-1,0)
            // right neigh (+1,0)
            // up neigh (0,-1)
            // down neigh (0,+1)
            if(mi-1 >= 0)
            {
                if(!matrixInfo[(mi-1,mj)])
                {
                    if(matrix[mi-1,mj] == 1)
                    {
                        matrixInfo[(mi-1,mj)] = true;
                        FindNeighbor(n, mi-1, mj, matrix);
                    }
                }
            }
            if(mi+1 < n)
            {
                if(!matrixInfo[(mi+1,mj)])
                {
                    if(matrix[mi+1,mj] == 1)
                    {
                        matrixInfo[(mi+1,mj)] = true;
                        FindNeighbor(n, mi+1, mj, matrix);
                    }
                }
            }
            if(mj-1 >= 0)
            {
                if(!matrixInfo[(mi,mj-1)])
                {
                    if(matrix[mi,mj-1] == 1)
                    {
                        matrixInfo[(mi,mj-1)] = true;
                        FindNeighbor(n, mi, mj-1, matrix);
                    }
                }
            }
            if(mj+1 < n)
            {
                if(!matrixInfo[(mi,mj+1)])
                {
                    if(matrix[mi,mj+1] == 1)
                    {
                        matrixInfo[(mi,mj+1)] = true;
                        FindNeighbor(n, mi, mj+1, matrix);
                    }
                }
            }
        }
        static void RemoveIslands(int n, int [,] matrix)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixInfo.Add((i,j),false);
                }
            }
            for(int i=0; i<n; i++)
            {
                if(i==0 || i == n-1)
                {
                    for(int j=0; j<n; j++)
                    {
                        if(matrix[i,j] == 1)
                        {
                            matrixInfo[(i,j)] = true;
                            FindNeighbor(n,i,j,matrix);
                        }
                    }
                }
                else
                {
                    if(matrix[i,0] == 1)
                    {
                        matrixInfo[(i,0)] = true;
                        FindNeighbor(n,i,0,matrix);
                    }
                    if(matrix[i,n-1] == 1)
                    {
                        matrixInfo[(i,n-1)] = true;
                        FindNeighbor(n,i,n-1,matrix);
                    }
                }
            }
        }
    }
}
