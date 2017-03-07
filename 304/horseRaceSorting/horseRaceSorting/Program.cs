using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace horseRaceSorting
{
    class Program
    {
        public static readonly int size = 125;

        
        static void Main(string[] args)
        {
            int[] horse = { 107, 47, 102, 64, 50, 100, 28, 91, 27, 5, 22, 114, 23, 42, 13, 3, 93, 8, 92, 79,
                53, 83, 63, 7, 15, 66, 105, 57, 14, 65, 58, 113, 112, 1, 62, 103, 120, 72, 111, 51,
                9, 36, 119, 99, 30, 20, 25, 84, 16, 116, 98, 18, 37, 108, 10, 80, 101, 35, 75, 39,
                109, 17, 38, 117, 60, 46, 85, 31, 41, 12, 29, 26, 74, 77, 21, 4, 70, 61, 88, 44,
                49, 94, 122, 2, 97, 73, 69, 71, 86, 45, 96, 104, 89, 68, 40, 6, 87, 115, 54, 123,
                125, 90, 32, 118, 52, 11, 33, 106, 95, 76, 19, 82, 56, 121, 55, 34, 24, 43, 124, 81,
                48, 110, 78, 67, 59 };

            //int[,] compare = new int [horse.Length,horse.Length]; // 0 - no data, 1 - [a] > [b], 2 - [a] < [b], 3 - [a] = [b]
            Horse[] horses = new Horse[size];
            for(int i = 0; i < size; i++)
            {
                horses[i] = new Horse(i, horse[i]);
            }

            start(horses);

            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("speed : " + horses[i].speed +"\tRanking : " + horses[i].rank + "\tRaces : " + horses[i].race);
                //Console.WriteLine("spexd : " + first.sortedHorse[i].speed + "\tRankixg : " + first.sortedHorse[i].rank);
            }
            Console.ReadKey();
        }

        static void start(Horse[] horses)
        {
            Race[] tour = new Race[5000000];
            Horse[] fiveH = new Horse[5];
            int raceCount = 0;
            int i;
            for (i = 0; i < size; i++)
            {
                fiveH[i % 5] = horses[i];
                if (i % 5 == 4)
                {
                    tour[raceCount] = new Race(fiveH);
                    raceCount++;
                }
            }
            int tilFive = 0;
            bool r = true;
            do
            {
                if (i >= size)
                {
                    i = 0;
                }
                if (tilFive==0)
                {
                    fiveH[tilFive] = horses[i];
                    tilFive++;
                }else if (tilFive == 5)
                {

                    tour[raceCount] = new Race(fiveH);
                    raceCount++;
                    
                    for(tilFive = 0;tilFive < 5; tilFive++)
                    {
                        if(fiveH[tilFive].rank > 130)
                        {
                            Console.WriteLine("fastest");
                            r = false;
                        }
                    }
                    tilFive = 0;
                }else
                {

                }
                i++;
            } while (r);
            
        }

    }

    class Horse
    {
        public int speed;
        public int index;
        public int race; // # of racing
        public int rank;
        public bool[] faster;
        public bool[] slower;

        public Horse(int index, int speed)
        {
            this.index = index;
            this.speed = speed;
            race = 0;
            rank = 0;
            faster = new bool[125];
            slower = new bool[125];
            faster[index] = true;
        }
        
    }

    class Race
    {
        public Horse[] sortedHorse;
        public int repetetive;
        public Race(Horse[] horses)
        {
            sortedHorse = horses;
            Array.Sort(sortedHorse, (x, y) => y.speed.CompareTo(x.speed));
            //horses.OrderBy(x => x.speed);
            for(int x = sortedHorse.Length-1; x >= 0; x--)
            {
                for (int y = x+1; y < horses.Length; y++)
                {
                    sortedHorse[x].faster[sortedHorse[y].index] = true;
                    sortedHorse[y].slower[sortedHorse[x].index] = true;
                }
                for (int z = 0; z < sortedHorse[x].faster.Length && x + 1 < horses.Length; z++)
                {
                    sortedHorse[x].faster[z] = sortedHorse[x].faster[z] || sortedHorse[x+1].faster[z];
                }
                sortedHorse[x].rank = sortedHorse[x].faster.Count(c => c);
                sortedHorse[x].race++;
            }
        }

    }


}
