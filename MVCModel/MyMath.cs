using System;
using System.Numerics;

namespace WinFormMVC.Model
{
    public static class MyMath
    {
        /// <summary>
        /// (b^e) mod m
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns>remainder</returns>
        public static int ModPow(int b, int e, int m)
        {
            int pot = 1;

            while (e > 0)
            {
                // checking if e is odd
                if ((e & 1) == 1)
                {
                    pot = (pot * b) % m;
                    e -= 1;
                }
                else
                {
                    b = (b * b) % m;
                    // division by 2
                    e >>= 1;
                }
            }

            return pot;
        }

        /// <summary>
        /// (b^e) mod m
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <param name="m"></param>
        /// <returns>remainder</returns>
        public static long ModPow(long b, long e, long m)
        {
            long pot = 1;

            while (e > 0)
            {
                //checking if e is odd
                if ((e & 1) == 1)
                {
                    pot = (pot * b) % m;
                    e -= 1;
                }
                else
                {
                    b = (b * b) % m;
                    // division by 2
                    e >>= 1;
                }
            }

            return pot;
        }

        public static BigInteger ModPow(BigInteger b, BigInteger e, BigInteger m)
        {
            BigInteger pot = 1;

            while (e > 0)
            {
                //checking if e is odd
                if ((e & 1) == 1)
                {
                    pot = (pot * b) % m;
                    e -= 1;
                }
                else
                {
                    b = (b * b) % m;
                    // division by 2
                    e >>= 1;
                }
            }

            return pot;
        }

        /// <summary>
        /// a * b mod m = 1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns>b</returns>
        public static int ModInverse(int a, int m)
        {
            if (m == 1) { return 0; }
            int m0 = m;
            (int x, int y) = (1, 0);

            while (a > 1)
            {
                int q = a / m;
                (a, m) = (m, a % m);
                (x, y) = (y, x - q * y);
            }
            return x < 0 ? x + m0 : x;
        }


        /// <summary>
        /// a * b mod m = 1
        /// </summary>
        /// <param name="a"></param>
        /// <param name="m"></param>
        /// <returns>b</returns>
        public static int ModInverse(long a, long m)
        {
            if (m == 1) { return 0; }
            long m0 = m;
            (long x, long y) = (1, 0);

            while (a > 1)
            {
                long q = a / m;
                (a, m) = (m, a % m);
                (x, y) = (y, x - q * y);
            }
            return (int)(x < 0 ? x + m0 : x);
        }

        public static BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            if (m == 1) { return 0; }
            BigInteger m0 = m;
            (BigInteger x, BigInteger y) = (1, 0);

            while (a > 1)
            {
                BigInteger q = a / m;
                (a, m) = (m, a % m);
                (x, y) = (y, x - q * y);
            }
            return (BigInteger)(x < 0 ? x + m0 : x);
        }

        public static int PhiFunc(int m)
        {
            int relativePrimeCounter = 0;

            for (int i = 1; i <= m; i++)
            {
                if (GCD(i, m) == 1) { relativePrimeCounter++; }
            }

            return relativePrimeCounter;
        }

        public static int PhiFunc(long m)
        {
            int relativePrimeCounter = 0;

            for (int i = 1; i <= m; i++)
            {
                if (GCD(i, m) == 1) { relativePrimeCounter++; }
            }

            return relativePrimeCounter;
        }

        public static BigInteger PhiFunc(BigInteger m)
        {
            BigInteger relativePrimeCounter = 0;

            for (BigInteger i = 1; i <= m; i++)
            {
                if (GCD(i, m) == 1) { relativePrimeCounter++; }
            }

            return relativePrimeCounter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prime1"></param>
        /// <param name="prime2"></param>
        /// <returns></returns>
        public static int PhiFuncPrime(int prime1, int prime2)
        {
            return (prime1 - 1) * (prime2 - 1);
        }

        public static long PhiFuncPrime(long prime1, long prime2)
        {
            return (prime1 - 1) * (prime2 - 1);
        }

        public static BigInteger PhiFuncPrime(BigInteger prime1, BigInteger prime2)
        {
            return (prime1 - 1) * (prime2 - 1);
        }

        public static int PhiFuncPrime(int prime1)
        {
            return (prime1 - 1);
        }

        public static BigInteger PhiFuncPrime(BigInteger prime1)
        {
            return (prime1 - 1);
        }

        public static long PhiFuncPrime(long prime1)
        {
            return (prime1 - 1);
        }

        public static int GCD(int number1, int number2)
        {
            int rest;
            int gcd = number1;
            int divisor = number2;
            do
            {
                rest = gcd % divisor;
                gcd = divisor;
                divisor = rest;
            } while (rest > 0);

            return gcd;
        }

        public static long GCD(long number1, long number2)
        {
            long rest;
            long gcd = number1;
            long divisor = number2;
            do
            {
                rest = gcd % divisor;
                gcd = divisor;
                divisor = rest;
            } while (rest > 0);

            return gcd;
        }

        public static BigInteger GCD(BigInteger number1, BigInteger number2)
        {
            BigInteger rest;
            BigInteger gcd = number1;
            BigInteger divisor = number2;
            do
            {
                rest = gcd % divisor;
                gcd = divisor;
                divisor = rest;
            } while (rest > 0);

            return gcd;
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) { return false; }
            if (number == 2) { return true; }
            if (number % 2 == 0) { return false; }

            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) { return false; }
            }

            return true;
        }

        public static bool IsPrime(long number)
        {
            if (number <= 1) { return false; }
            if (number == 2) { return true; }
            if (number % 2 == 0) { return false; }

            long boundary = (long)Math.Floor(Math.Sqrt(number));

            for (long i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) { return false; }
            }

            return true;
        }

        public static bool IsPrime(BigInteger number)
        {
            if (number <= 1) { return false; }
            if (number == 2) { return true; }
            if (number % 2 == 0) { return false; }

            BigInteger boundary = number >> 1;

            for (BigInteger i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) { return false; }
            }

            return true;
        }

    }
}
