﻿using System.Threading;

namespace CrystalMarkNet.ALU
{
    class Eratosthenes : CrystalBenchmarkBase
    {
        private const int N = 1024;

        protected override int BenchImplementation(CancellationToken cancellationToken)
        {
            int i, p, k, count = 0, cnt;
            bool[] flag = new bool[N + 1];

            for (; ; )
            {
                cnt = 1;
                for (i = 0; i <= N; i++) { flag[i] = true; }
                for (i = 0; i <= N; i++)
                {
                    if (flag[i])
                    {
                        p = i + i + 3;
                        for (k = i + p; k <= N; k += p) { flag[k] = false; }
                        cnt++;
                    }
                }
                count++;

                if (cancellationToken.IsCancellationRequested)
                {
                    return (int)(count * (N / 70000.0 / 10));
                }
            }
        }
    }
}