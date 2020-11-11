using System;

namespace WinFormMVC.Model
{
    public class Conversion
    {
        public string decimalToBinary(string text)
        {
            ulong input = Convert.ToUInt64(text);
            string outputBinary = "";

            for (int i = 0; i < 64; i++)
            {
                ulong rest = input % 2;
                input = (input - rest) / 2;
                outputBinary = Convert.ToString(rest) + outputBinary;
            }
            return Convert.ToString(outputBinary).TrimStart(new Char[] { '0' });
        }

        public string binaryToDecimal(string text)
        {
            string input = text;
            char[] arrayInput;
            arrayInput = input.ToCharArray();
            int position = (arrayInput.Length - 1);
            ulong outputDecimal = 0;

            for (int i = 0; i < arrayInput.Length; i++)
            {
                switch (arrayInput[i])
                {
                    case '0':
                        outputDecimal += 0 * (UInt64)Math.Pow(2, position);
                        position--;
                        break;

                    case '1':
                        outputDecimal += 1 * (UInt64)Math.Pow(2, position);
                        position--;
                        break;
                }

            }
            return (Convert.ToString(outputDecimal));
        }

        public string hexadecimalToDecimal(string text)
        {
            string input = (text).ToUpper();
            char[] arrayInput;
            arrayInput = input.ToCharArray();
            ulong outputDecimal = 0;

            for (int i = 0; i < arrayInput.Length; i++)
            {
                switch (arrayInput[i])
                {
                    case '0':
                        outputDecimal += 0 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '1':
                        outputDecimal += 1 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '2':
                        outputDecimal += 2 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '3':
                        outputDecimal += 3 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '4':
                        outputDecimal += 4 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '5':
                        outputDecimal += 5 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '6':
                        outputDecimal += 6 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '7':
                        outputDecimal += 7 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '8':
                        outputDecimal += 8 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case '9':
                        outputDecimal += 9 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case 'A':
                        outputDecimal += 10 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case 'B':
                        outputDecimal += 11 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case 'C':
                        outputDecimal += 12 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case 'D':
                        outputDecimal += 13 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case 'E':
                        outputDecimal += 14 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;

                    case 'F':
                        outputDecimal += 15 * (UInt64)Math.Pow(16, arrayInput.Length - (i + 1));
                        break;
                }
            }
            return Convert.ToString(outputDecimal);
        }

        public string decimalToHexdecimal(string text)
        {
            ulong input = Convert.ToUInt64(text);
            char[] arrayInput;
            arrayInput = Convert.ToString(input).ToCharArray();
            string outputHexadecimal = "";

            for (int i = 0; i < arrayInput.Length; i++)
            {
                string strRemain;
                ulong rest = input % 16;
                strRemain = Convert.ToString(rest);
                input = (input - rest) / 16;

                switch (rest)
                {
                    case 10:
                        strRemain = "A";
                        break;
                    case 11:
                        strRemain = "B";
                        break;
                    case 12:
                        strRemain = "C";
                        break;
                    case 13:
                        strRemain = "D";
                        break;
                    case 14:
                        strRemain = "E";
                        break;
                    case 15:
                        strRemain = "F";
                        break;
                }
                outputHexadecimal = strRemain + outputHexadecimal;
            }
            return outputHexadecimal.TrimStart(new Char[] { '0' });
        }

        public string hexadecimalToBinary(string text)
        {
            return decimalToBinary(hexadecimalToDecimal(text));
        }

        public string binaryToHexdecimal(string text)
        {
            return decimalToHexdecimal(binaryToDecimal(text));
        }
    }
}
