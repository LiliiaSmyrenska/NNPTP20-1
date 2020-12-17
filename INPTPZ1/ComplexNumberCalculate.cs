using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumberCalculate
        {
            public double RealPart { get; set; }
            public double ImaginaryPart { get; set; }

            public override bool Equals(object newОbject)
            {
                if (newОbject is ComplexNumberCalculate)
                {
                    ComplexNumberCalculate NewComplexNumber = newОbject as ComplexNumberCalculate;
                    return NewComplexNumber.RealPart == RealPart && NewComplexNumber.ImaginaryPart == ImaginaryPart;
                }
                return base.Equals(newОbject);
            }

            public readonly static ComplexNumberCalculate ComplexNumberZero = new ComplexNumberCalculate()
            {
                RealPart = 0,
                ImaginaryPart = 0
            };

            public ComplexNumberCalculate Multiply(ComplexNumberCalculate multiplier)
            {
                return new ComplexNumberCalculate()
                {
                    RealPart = RealPart * multiplier.RealPart - ImaginaryPart * multiplier.ImaginaryPart,
                    ImaginaryPart = RealPart * multiplier.ImaginaryPart + ImaginaryPart * multiplier.RealPart
                };
            }
            public double GetAbS()
            {
                return Math.Sqrt( RealPart * RealPart + ImaginaryPart * ImaginaryPart);
            }

            public ComplexNumberCalculate Add(ComplexNumberCalculate addition)
            {
                return new ComplexNumberCalculate()
                {
                    RealPart = RealPart + addition.RealPart,
                    ImaginaryPart = ImaginaryPart + addition.ImaginaryPart
                };
            }
            public double GetAngleInRadians()
            {
                return Math.Atan(ImaginaryPart / RealPart);
            }
            public ComplexNumberCalculate Subtract(ComplexNumberCalculate reducer)
            {
                return new ComplexNumberCalculate()
                {
                    RealPart = RealPart - reducer.RealPart,
                    ImaginaryPart = ImaginaryPart - reducer.ImaginaryPart
                };
            }

            public override string ToString()
            {
                return $"({RealPart} + {ImaginaryPart}i)";
            }

            internal ComplexNumberCalculate Divide(ComplexNumberCalculate denominator)
            {
                var divisorPart = this.Multiply(new ComplexNumberCalculate() { RealPart = denominator.RealPart, ImaginaryPart = -denominator.ImaginaryPart });
                var denominatorPart = denominator.RealPart * denominator.RealPart + denominator.ImaginaryPart * denominator.ImaginaryPart;

                return new ComplexNumberCalculate()
                {
                    RealPart = divisorPart.RealPart / denominatorPart,
                    ImaginaryPart =(divisorPart.ImaginaryPart / denominatorPart)
                };
            }
        }
    }
}
