using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{   
    class Fraction : IEquatable, IComparable
    {
        private readonly int numerator;
        public int Numerator
        {
            get; private set;
        }
        private readonly int nominative;
        public int Nominative
        {
            get; private set;
        }

        public Fraction()
        {
            this.numerator = 0;
            this.nominative = 1;
        }

        public Fraction(int numerator, int nominative)
        {
            this.numerator = numerator;
            this.nominative = nominative;
        }

        public Fraction(Fraction fraction)
        {
            this.numerator = fraction.numerator;
            this.nominative = fraction.nominative;
        }

        public override string ToString()
        {
            return $"{numerator}" + "/" + $"{nominative}";
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public static Fraction operator +(Fraction a) => a;
        public static Fraction operator -(Fraction a) => new Fraction(-a.numerator, a.nominative);

        public static Fraction operator +(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.nominative + b.numerator * a.nominative, a.nominative * b.nominative);

        public static Fraction operator -(Fraction a, Fraction b)
            => a + (-b);

        public static Fraction operator *(Fraction a, Fraction b)
            => new Fraction(a.numerator * b.numerator, a.nominative * b.nominative);

        public static Fraction operator /(Fraction a, Fraction b)
        {
            if (b.numerator == 0)
            {
                throw new DivideByZeroException();
            }
            return new Fraction(a.numerator * b.nominative, a.nominative * b.numerator);
        }

        public int RoundCeiling(Fraction a)
        {
            if (a.numerator == 0 || a.nominative == 0)
                throw new DivideByZeroException();
            int result = (int)Math.Ceiling((double)a.numerator/(double)a.nominative);
            return result;
        }

        public int RoundFloor(Fraction a)
        {
            if (a.numerator == 0 || a.nominative == 0)
                throw new DivideByZeroException();
            int result = (int)Math.Floor((double)a.numerator / (double)a.nominative);
            return result;
        }
    }
}
