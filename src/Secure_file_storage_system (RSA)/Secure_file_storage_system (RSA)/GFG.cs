using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System;

class GFG
{
    public static int PowerMod(int p, int e, int n)
    {
        int r2 = 1;
        int r1 = 0;
        int Q = 0;
        int R = 0;

        while (e != 0)
        {
            R = (e % 2);
            Q = ((e - R) / 2);

            r1 = ((p * p) % n);

            if (R == 1)
            {
                r2 = ((r2 * p) % n);
            }
            p = r1;
            e = Q;
        }
        return r2;
    }

    public int Encryption(int m,int e, int n) {
        return PowerMod(m, e, n);
    }

    public int Decryption(int c, int d, int n)
    {
        return PowerMod(c, d, n);
    }
}