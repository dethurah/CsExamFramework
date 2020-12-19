using System;
namespace CsExam.Examples
{
    public class OperatorOverloading
    {
        public static void TestMethod()
        {
            var complexN1 = new ComplexNumber(1.1, 2.2);
            var complexN2 = new ComplexNumber(3.3, 4.4);

            // Add two object as follows:
            var result = complexN1 + complexN2;
            Console.WriteLine("Value addition is : {0}", result);

            result = complexN1 - complexN2;
            Console.WriteLine("Value addition is : {0}", result);

            result = complexN1 * complexN2;
            Console.WriteLine("Value addition is : {0}", result);

            Console.ReadKey();
        }
    }

    class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        // Overload + operator to add two Box objects.
        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber c)
        {
            var cn = new ComplexNumber(0.0, 0.0);
            cn.Real = a.Real + c.Real;
            cn.Imaginary = a.Imaginary + c.Imaginary;
            return cn;
        }
        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            var cn = new ComplexNumber(0.0, 0.0);
            cn.Real = a.Real - b.Real;
            cn.Imaginary = a.Imaginary - b.Imaginary;
            return cn;
        }
        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            var cn = new ComplexNumber(0.0, 0.0);
            cn.Real = (a.Real * b.Real) - (a.Imaginary * b.Imaginary);
            cn.Imaginary = (a.Real * b.Imaginary) + (a.Imaginary * b.Real);
            return cn;
        }

        public override string ToString()
        {
            var str = "";
            if (Imaginary > 0)
                str = string.Format("{0} + {1}i", Real, Imaginary);
            else
                str = string.Format("{0} {1}i", Real, Imaginary);

            return str;
        }
    }
}
