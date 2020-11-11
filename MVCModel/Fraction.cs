namespace WinFormMVC.Model
{
    public class Fraction
    {
        private int denominator;
        private int numerator;

        // Getter and Setter for Numerator and Denominator
        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        //Constructor
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        //Constructor
        public Fraction()
        {
            Numerator = 0;
            Denominator = 1;
        }

        //Reduce Fraction
        public void Reduce()
        {
            bool negative = false;
            int numerator;
            int denominator = Denominator;
            if (Numerator < 0)
            {
                negative = true;
                numerator = Numerator * -1;
            }
            else
            {
                numerator = Numerator;
            }

            if (numerator != 0)
            {
                int rest;
                int ggt = numerator;
                int divisor = denominator;
                do
                {
                    rest = ggt % divisor;
                    ggt = divisor;
                    divisor = rest;
                } while (rest > 0);

                numerator /= ggt;
                denominator /= ggt;

                if (negative)
                {
                    Numerator = numerator * -1;
                }
                else
                {
                    Numerator = numerator;
                }
                Denominator = denominator;
            }
        }
    }

    public class FractionCalculation
    {
        //Multiplication
        public Fraction Multiplication(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction();

            result.Numerator = fractionA.Numerator * fractionB.Numerator;
            result.Denominator = fractionA.Denominator * fractionB.Denominator;

            return result;
        }

        //Division
        public Fraction Division(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction();

            if (fractionB.Numerator < 0)
            {
                result.Numerator = (-1) * fractionA.Numerator * fractionB.Denominator;
                result.Denominator = fractionA.Denominator * fractionB.Numerator * (-1);
            }
            else
            {
                result.Numerator = fractionA.Numerator * fractionB.Denominator;
                result.Denominator = fractionA.Denominator * fractionB.Numerator;
            }

            return result;
        }

        //Addition
        public Fraction Addition(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction();

            if (fractionA.Denominator == fractionB.Denominator)
            {
                result.Numerator = fractionA.Numerator + fractionB.Numerator;
                result.Denominator = fractionA.Denominator;
            }
            else
            {
                result.Numerator = fractionA.Numerator * fractionB.Denominator + fractionB.Numerator * fractionA.Denominator;
                result.Denominator = fractionA.Denominator * fractionB.Denominator;
            }

            return result;
        }

        //Subtraction
        public Fraction Subtraction(Fraction fractionA, Fraction fractionB)
        {
            Fraction result = new Fraction();

            if (fractionA.Denominator == fractionB.Denominator)
            {
                result.Numerator = fractionA.Numerator - fractionB.Numerator;
                result.Denominator = fractionA.Denominator;
            }
            else
            {
                result.Numerator = fractionA.Numerator * fractionB.Denominator - fractionB.Numerator * fractionA.Denominator;
                result.Denominator = fractionA.Denominator * fractionB.Denominator;
            }

            return result;
        }
    }
}
