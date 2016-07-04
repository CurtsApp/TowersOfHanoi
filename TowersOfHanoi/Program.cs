using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TowersOfHanoi;

namespace TowersOfHanoi
{
    class Program
    {
        private ulong stepCount = 1;
        static void Main(string[] args)
        {

            Nonstatic Helper = new Nonstatic();
            //Promp the user for input
            Console.Write("How many disks would you like to calculate?");
            String numberOfDisksToGenerateString = Console.ReadLine();
            ulong numberOfDisksToGenerateNum = UInt64.Parse(numberOfDisksToGenerateString);
            //Number of moves is calculted with 2^n - 1.
            double numberOfMoves = Math.Pow(2,numberOfDisksToGenerateNum) - 1;
            Console.WriteLine("It will take {0} moves to finish the puzzle.", numberOfMoves);
            Console.WriteLine("-------------------MOVES----------------------");
            List<Disk> StartStack = new List<Disk>();
            //Build the original stack of disks, incrementing size each time.
            for (ulong i = 0; i < numberOfDisksToGenerateNum; i++)
            {
                StartStack.Add(new Disk(i));
            }
            //Begins our recursive loop
            Helper.MoveStack(StartStack, Post.Start, Post.Mid, Post.End);

            String temp = Console.ReadLine();
        }
    }

    public class Nonstatic
    {
        public ulong StepCount;

        public void MoveStack(List<Disk> stack, Post start, Post aux, Post end)
        {
            //Recrusive loop exit
            if (stack.Count == 1)
            {
                Console.WriteLine("Move {0}, to, {1} post. Step {2}", stack[0].Size, end, StepCount);
                StepCount = StepCount + 1;

            }
            else
            {

                List<Disk> shortenedStack = new List<Disk>(stack);
                List<Disk> lastDiskStack = new List<Disk>();
                lastDiskStack.Add(stack[stack.Count() - 1]);
                shortenedStack.RemoveAt(shortenedStack.Count - 1);
                MoveStack(shortenedStack, start, end, aux);
                MoveStack(lastDiskStack, start, aux, end);
                MoveStack(shortenedStack, aux, start, end);

            }
            
        }
    }
    public class Disk
    {
        public ulong Size;

        public Disk(ulong size)
        {
            Size = size;
        }
    }

    public enum Post
    {
        Start, Mid, End,
    
    }
}
