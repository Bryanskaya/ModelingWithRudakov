using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace randMethods
{
    /// <summary>
    /// R(n+1) = (a * R(n) + b) mod N
    /// </summary>
    class CongruentMethod
    {
        private int a { get; }
        private int b { get; }
        private int N { get; }
        private int r;

        public CongruentMethod(int seed)
        {
            a = 430;
            b = 2531;
            N = 11979;
            r = seed;
        }

        public int next(int start, int end)
        {
            r = (a * r + b) % N;
            return Math.Abs(r) % (end - start) + start;
        }

    }
}
