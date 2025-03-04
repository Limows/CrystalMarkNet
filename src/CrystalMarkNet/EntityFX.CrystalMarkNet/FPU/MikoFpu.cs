﻿using System.Threading;

namespace CrystalMarkNet.FPU
{
    class MikoFpu : CrystalBenchmarkBase
    {
        private const int MemSize = 2048;

        protected override int BenchImplementation(CancellationToken cancellationToken)
        {
            double count = 0;

            float a = 1.0f;
            float b = 0.0f;
            float c = 0.0f;
            float d = 0.0f;

            float xch = 0.0f;

            for (; ; )
            {

                b += a;
                a -= d;

                xch = c;
                c = a;
                a = xch;

                a += d;

                xch = c;
                c = a;
                a = xch;

                a *= b;

                count++;

                if (cancellationToken.IsCancellationRequested)
                {
                    return (int) (count / 100000 / 30);
                }
            }
        }
    }
}