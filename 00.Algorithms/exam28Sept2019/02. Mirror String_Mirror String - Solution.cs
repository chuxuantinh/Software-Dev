using System;

    class MirrorString
    {
        public static void Main()
        {
            string str = Console.ReadLine();

            Console.WriteLine(LongestPalSubseq(str));
        }

        private static string LongestPalSubseq(string str)
        {
            string rev = str;
            rev = Reverse(rev);
            return Lcs(str, rev);
        }

        static string Reverse(string str)
        {
            string ans = "";
            char[] try1 = str.ToCharArray();
            for (int i = try1.Length - 1; i >= 0; i--)
            {
                ans += try1[i];
            }

            return ans;
        }

        private static string Lcs(string a, string b)
        {
            int m = a.Length;
            int n = b.Length;
            char[] X = a.ToCharArray();
            char[] Y = b.ToCharArray();

            int[,] L = new int[m + 1, n + 1];

            for (int x = 0; x <= m; x++)
            {
                for (int y = 0; y <= n; y++)
                {
                    if (x == 0 || y == 0)
                    {
                        L[x, y] = 0;
                    }
                    else if (X[x - 1] == Y[y - 1])
                    {
                        L[x, y] = L[x - 1, y - 1] + 1;
                    }
                    else
                    {
                        L[x, y] = Math.Max(L[x - 1, y], L[x, y - 1]);
                    }
                }
            }

            int index = L[m, n];

            char[] lcs = new char[index + 1];

            int i = m, j = n;
            while (i > 0 && j > 0)
            {
                if (X[i - 1] == Y[j - 1])
                {
                    lcs[index - 1] = X[i - 1];
                    i--;
                    j--;
                    index--;
                }
                else if (L[i - 1, j] > L[i, j - 1])
                {
                    i--;
                }
                else
                {
                    j--;
                }
            }

            string ans = "";

            foreach (var ch in lcs)
            {
                ans += ch;
            }

            return ans;
        }
    }
