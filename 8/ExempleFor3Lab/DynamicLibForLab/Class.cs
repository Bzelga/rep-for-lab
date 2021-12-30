using System;
using System.Runtime.InteropServices;

namespace DynamicLibForLab
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)]
        public int M;
    }

    [StructLayout(LayoutKind.Explicit)]
    public struct Output
    {
        [FieldOffset(0)]
        public double AbosluteTime;
        [FieldOffset(8)]
        public double RelativeTime;
    }

    public class Calc
    {
        [DllImport("milib.so")]
        private static extern void FoundPi(ref Input S1, ref Output S2);

        public void Do()
        {
            Input input = new Input();
            input.M = 100000000;
            Output output = new Output();
            FoundPi(ref input, ref output);
            
            Console.WriteLine(output.AbosluteTime +" and "+ output.RelativeTime);
        }
    }
}