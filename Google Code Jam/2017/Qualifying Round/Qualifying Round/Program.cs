using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Qualifying_Round
{
    class Program
    {
        
        static string flip(string c)
        {
            string fliped = "";
            for(int i=0;i<c.Length;i++)
            {
                fliped += c[i] == '-' ? '+' : '-';
            }
            return fliped;
        }

        static bool all_happy_Sides(string input)
        {
            return input.Contains('-') ? false : true;
        }

        static void readFile()
        {
            string[] lines = File.ReadAllLines("A-large-practice.in");
            TextWriter writer = File.CreateText("Output-Large_2.in");
            for (int i = 20; i <= 20; i++)
            {
                string[] data = lines[i].Split();

                int min_flips = flip(data[0], Convert.ToInt32(data[1]));
                string answer = min_flips == -1 ? "IMPOSSIBLE" : "" + min_flips;
                Console.WriteLine($"Case #{i}: {answer}");
                writer.WriteLine($"Case #{i}: {answer}");
                //Console.WriteLine("INPUT : {0} {1}\nOUTPUT: {2}", data[0], data[1], flip(data[0], Convert.ToInt32(data[1])));

            }
            writer.Close();
            //Console.WriteLine(lines[100]);
        }
        static int flip(string S, int K)
        {
            string flipped = "";
            Random rnd = new Random();
            int minimum_flips = 5000;
            int numOfFlips = 0;
            int i = 0;
            int z = 0;
            int prevIdx = 0;
            while (i < 10000)
            {
                int idx = rnd.Next(0, S.Length - K + 1);
                string input = S.Substring(idx, K);
                string fliper = !all_happy_Sides(input)? flip(input):input;

                numOfFlips = fliper != input ? 1 : 0;
                
                flipped = S.Substring(0, idx) + fliper + S.Substring(K + idx);
                Console.ForegroundColor = ConsoleColor.Green;
                //List<string> history = new List<string>();

                z = 0;
                while (!all_happy_Sides(flipped))
                {
                    CHOOSE_IDX:
                    idx = rnd.Next(0, flipped.Length - K + 1);
                    input = flipped.Substring(idx, K);
                    
                    if (all_happy_Sides(input)) goto CHOOSE_IDX;
                    fliper = flip(input);
                    prevIdx = idx;

                    flipped = flipped.Substring(0, idx) + fliper + flipped.Substring(K + idx);
                    //history.Add(flipped);
                    //Console.ForegroundColor = ConsoleColor.Green;
                    //Console.WriteLine(flipped);
                    numOfFlips++;
                    z++;
                    if (z == 100000 && minimum_flips==5000)
                    {
                        z = -1; //Console.WriteLine("IMPOSSIBLE!");
                        break;
                    }
                }
                if (z == -1) break;
                //if (numOfFlips == 3) Console.WriteLine("-------------------------------SPECIAL CASE-------: HISTORY : [{0}]", string.Join(", ", history));
               // Console.WriteLine("Test {0} : flips = {1} ",(i+1),numOfFlips);
                if (numOfFlips < minimum_flips) minimum_flips = numOfFlips;
                numOfFlips = 0;
                i++;
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (z != -1) return minimum_flips;      //Console.WriteLine("Minimum number of flips was recorded as : {0}",minimum_flips);
            else return z;                //Console.WriteLine("Minimum number of flips was recorded as : IMPOSSIBLE");
            //return flipped;
        }

        static void Main(string[] args)
        {/*
            string input = "---+-++-";
            Console.WriteLine("INPUT : {0}\nOUTPUT: {1}",input,flip(input,3));

            input = "+++++";
            Console.WriteLine("INPUT : {0}\nOUTPUT: {1}", input, flip(input, 4));

            input = "-+-+-";
            Console.WriteLine("INPUT : {0}\nOUTPUT: {1}", input, flip(input, 4));
            Console.Read();
            */
           // string t = "hello";
            //Console.WriteLine(t.Substring(3, 5));
            readFile();

        }
    }
}
