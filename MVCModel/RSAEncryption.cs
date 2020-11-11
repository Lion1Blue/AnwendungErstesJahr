using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace WinFormMVC.Model
{
    public class RSAEncryption
    {
        public RSAEncryption(BigInteger p, BigInteger q, BigInteger e)
        {
            P = p;
            Q = q;
            E = e;
        }
        public RSAEncryption(BigInteger p, BigInteger q)
        {
            P = p;
            Q = q;
        }
        public RSAEncryption()
        {

        }
        private BigInteger p, q, n, e, d;
        private List<BigInteger> bigIntEncrypted = new List<BigInteger>();

        public BigInteger P
        {
            get { return p; }
            set
            {
                p = value;
                if (q != null)
                {
                    n = p * q;
                }
            }
        }

        public BigInteger Q
        {
            get { return q; }
            set
            {
                q = value;
                if (p != null)
                {
                    n = p * q;
                }
            }
        }

        public BigInteger E
        {
            get { return e; }
            set
            {
                e = value;
            }
        }

        public BigInteger D
        {
            get { return d; }
            set { d = value; }
        }

        public BigInteger N
        {
            get { return n; }
            private set { n = value; }
        }

        public string Encryption(byte[] plaintext)
        {
            List<byte[]> byteArrayList = new List<byte[]>();
            string plaintextEncrypted = string.Empty;

            DivideByteArrayInBlocks(byteArrayList, plaintext);

            foreach (byte[] byteArray in byteArrayList)
            {
                bigIntEncrypted.Add(MyMath.ModPow(new BigInteger(byteArray), e, n));
                plaintextEncrypted += $"{bigIntEncrypted[bigIntEncrypted.Count - 1].ToString("X")}";
            }

            return plaintextEncrypted;
        }

        public string Decryption()
        {
            string plaintextDecrypted = string.Empty;

            foreach (BigInteger bigInt in bigIntEncrypted)
            {
                byte[] bytes = MyMath.ModPow(bigInt, d, n).ToByteArray();
                plaintextDecrypted += $"{ASCIIEncoding.ASCII.GetString(bytes)}";
            }

            bigIntEncrypted.Clear();

            return plaintextDecrypted;
        }

        private void DivideByteArrayInBlocks(List<byte[]> byteArrayList, byte[] plaintext)
        {
            int byteCounter = 0;

            //RSA-Encryption can only encrypt Numbers that are smaller than n = p * q,
            //so the message hast to be divided into blocks that are smaller than n
            List<byte> byteList = new List<byte>();
            byteList.Add(127); //because 127 it is the biggest number assigned to a ascci code

            while (new BigInteger(byteList.ToArray()) < n)
            {
                byteList.Add(127);
                byteCounter++;
            }

            int iterations = Math.DivRem(plaintext.Length, byteCounter, out int remainder);

            for (int i = 0, startindex = plaintext.Length - byteCounter; i < iterations; i++, startindex -= byteCounter)
            {
                byte[] array = new byte[byteCounter];
                Array.Copy(plaintext, startindex, array, 0, byteCounter);
                byteArrayList.Add(array);
            }

            if (remainder != 0)
            {
                byte[] array = new byte[remainder];
                Array.Copy(plaintext, 0, array, 0, remainder);
                byteArrayList.Add(array);
            }

            byteArrayList.Reverse();
        }

    }
}
