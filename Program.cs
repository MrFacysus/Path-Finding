using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversePathSearch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> Map = new List<int>();
            Random r = new Random();
            GenerateMap(Map, r);
            PrintMap(Map);
            FindPath(ref Map);
        }

        private static void FindPath(ref List<int> map)
        {
            Console.WriteLine("Finding Path");
            int x = 8;
            int y = 8;
            int index = 0;
            int path = 7;
            int pathCount = 0;

            while (x != 1 || y != 1)
            {
                index = (y * 10) + x;
                if (map[index] == 0)
                {
                    map[index] = path;
                    pathCount++;
                    if (x > 1 && map[index - 1] == 0)
                    {
                        x--;
                    }
                    else if (y > 1 && map[index - 10] == 0)
                    {
                        y--;
                    }
                    else if (x < 10 && map[index + 1] == 0)
                    {
                        x++;
                    }
                    else if (y < 10 && map[index + 10] == 0)
                    {
                        y++;
                    }
                    else
                    {
                        Console.WriteLine("No Path Found");
                        break;
                    }
                }
                else
                {
                    path++;
                    x = 8;
                    y = 8;
                }
            }
            PrintMap(map);
        }

        private static void PrintMap(List<int> map)
        {
            for (int i = 0; i < 10; i++)
            {
                string mapRow = "";
                for (int j = 0; j < 10; j++)
                {
                    mapRow += map[i * 10 + j] + " ";
                }
                Console.WriteLine(mapRow);
            }
        }

        private static void GenerateMap(List<int> Map, Random r)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 0 || j == 0 || i == 9 || j == 9)
                    {
                        Map.Add(1);
                    }
                    else
                    {
                        if (r.Next(0, 100) < 50)
                        {
                            if (i != 1 && j != 1)
                            {
                                Map.Add(1);
                            }
                            else
                            {
                                Map.Add(0);
                            }
                        }
                        else
                        {
                            Map.Add(0);
                        }
                    }
                }
            }
        }
    }
}
