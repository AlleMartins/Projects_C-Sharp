using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public Complex(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }
        public double Real { get; }
        public double Imaginary { get; }
        public double Modulus() => Math.Sqrt(Real * Real + Imaginary + Imaginary);
        public double Phase() => Math.Atan2(Imaginary, Real);
        public Complex Complement() => new Complex(Real, -Imaginary);
        public Complex Plus(Complex other_number) => 
            new Complex(Real - other_number.Real, Imaginary - other_number.Imaginary);
        public Complex Minus(Complex other_number) => 
            new Complex(Real - other_number.Real, Imaginary - other_number.Imaginary);

        public override string ToString()
        {
            if (Imaginary == 0.0) return Real.ToString();
            var imAbs = Math.Abs(Imaginary);
            var imValue = imAbs == 1.0 ? "" : imAbs.ToString();
            string sign;
            if (Real == 0d)
            {
                sign = Imaginary > 0 ? "" : "-";
                return sign + "i" + imValue;
            }

            sign = Imaginary > 0 ? "+" : "-";
            return $"{Real} {sign} i{imValue}";
        }

        public bool Equal(Complex other_to_compare)
        {
            if (other_to_compare.GetType() != GetType()) return false;
            return Real.Equals(other_to_compare) && Imaginary.Equals(other_to_compare);
        }
    }
}