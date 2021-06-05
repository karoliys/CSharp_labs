using System;
using System.Text.RegularExpressions;

namespace Lab7
{
    class Fraction : IComparable<Fraction>, IFormattable, IConvertible, ICloneable
    {
        private long numerator;
        private long denominator;
        public Fraction(long numerator, long denominator = 1)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        public long Numerator
        {
            get
            {
                return numerator;
            }
            set
            {
                numerator = value;
                if (denominator != 0 && numerator != 0)
                {
                    long gcd = GCD(Math.Abs(denominator), Math.Abs(numerator));
                    denominator /= gcd;
                    numerator /= gcd;
                }
            }
        }
        public long Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                denominator = value;
                if (denominator == 0)
                    throw new ArgumentException("Division by zero");
                if (numerator != 0)
                {
                    long gcd = GCD(Math.Abs(denominator), Math.Abs(numerator));
                    denominator /= gcd;
                    numerator /= gcd;
                }
            }
        }
        private static long GCD(long firstValue, long secondValue)
        {
            long min = Min(firstValue, secondValue);
            long max = Max(firstValue, secondValue);
            if (min != 0)
                return GCD(max - min, min);
            return max;
        }
        private static long Min(long firstValue, long secondValue)
        {
            return firstValue < secondValue ? firstValue : secondValue;
        }
        private static long Max(long firstValue, long secondValue)
        {
            return firstValue > secondValue ? firstValue : secondValue;
        }
        public string ToString(string format)
        {
            return ToString(format, null);
        }
        public override string ToString()
        {
            return ToString("F", null);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "F";
            }
            if (format == "IF")
            {
                if (Math.Abs(numerator) > denominator && denominator != 1)
                {
                    long integral = numerator / denominator;
                    return $"{integral}({Math.Abs(numerator) % denominator}/{denominator})";
                }
                else
                {
                    format = "I";
                }
            }
            if (format == "I")
            {
                if (Math.Abs(numerator) > denominator)
                {
                    long integral = numerator / denominator;
                    return integral.ToString();
                }
                else
                {
                    format = "F";
                }
            }
            if (format == "F")
            {
                return $"{numerator}/{denominator}";
            }
            else if (format == "D")
            {
                return GetDouble().ToString();
            }
            else if (new Regex(@"D\d*").IsMatch(format))
            {
                return GetDouble().ToString("F" + format.Substring(1));
            }
            else
            {
                throw new FormatException($"The \"{format}\" format is not supported.");
            }
        }
        public static Fraction Parse(string number)
        {
            Fraction fraction;
            if (TryParse(number, out fraction))
                return fraction;
            throw new ArgumentException("the input string is not in the correct format");
        }
        public static bool TryParse(string number, out Fraction f)
        {
            f = null;
            Regex sPattern = new Regex(@"^(\d*)[/](\d*)$");
            Regex iPattern = new Regex(@"^\d*$");
            Regex dPattern = new Regex(@"^(\d*)[.,](\d*)$");
            if (sPattern.IsMatch(number))
            {
                string[] words = number.Split(new char[] { '/' });
                long n = long.Parse(words[0]);
                long d = long.Parse(words[1]);
                f = new Fraction(n, d);
                return true;
            }
            else if (iPattern.IsMatch(number))
            {
                long n = long.Parse(number);
                long d = 1;
                f = new Fraction(n, d);
                return true;
            }
            else if (dPattern.IsMatch(number))
            {
                string[] words = number.Split(new char[] { '.', ',' });
                long n = long.Parse(words[0]);
                long d = long.Parse(words[1]);
                f = new Fraction(n, d);
                return true;
            }
            else
                return false;
        }

        public double GetDouble()
        {
            return (double)numerator / denominator;
        }
        public int CompareTo(Fraction other)
        {
            Fraction f = this - other;
            if (f.GetDouble() > 0)
                return 1;
            else if (f.GetDouble() < 0)
                return -1;
            return 0;
        }
        public override bool Equals(object obj)
        {
            return obj is Fraction fraction && CompareTo(fraction) == 0;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(numerator, denominator);
        }

        public TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Numerator != 0;
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(GetDouble());
        }
        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(GetDouble());
        }
        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(GetDouble());
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(GetDouble());
        }

        public double ToDouble(IFormatProvider provider)
        {
            return GetDouble();
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(GetDouble());
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(GetDouble());
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(GetDouble());
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(GetDouble());
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(GetDouble());
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString("F", provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(GetDouble(), conversionType);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(GetDouble());
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(GetDouble());
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(GetDouble());
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, b.Numerator * a.Denominator);
        }

        public static Fraction operator -(Fraction b)
        {
            return b * new Fraction(-1);
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            long d = a.Denominator * b.Denominator / GCD(Math.Abs(a.Denominator), Math.Abs(b.Denominator));
            long na = a.Numerator * d / a.Denominator;
            long nb = b.Numerator * d / b.Denominator;
            return new Fraction(na + nb, d);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + (-b);
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }
        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 0;
        }

        public static explicit operator sbyte(Fraction f)
        {
            return f.ToSByte(null);
        }

        public static explicit operator short(Fraction f)
        {
            return f.ToInt16(null);
        }

        public static explicit operator int(Fraction f)
        {
            return f.ToInt32(null);
        }

        public static explicit operator long(Fraction f)
        {
            return f.ToInt64(null);
        }

        public static explicit operator float(Fraction f)
        {
            return f.ToSingle(null);
        }

        public static implicit operator double(Fraction f)
        {
            return f.ToDouble(null);
        }

        public static explicit operator decimal(Fraction f)
        {
            return f.ToDecimal(null);
        }

        public object Clone()
        {
            return new Fraction(Numerator, Denominator);
        }
    }
}