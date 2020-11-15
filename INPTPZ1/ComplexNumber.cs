using System;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class ComplexNumber
        {
            public double RealPart { get; set; }
            public double ImaginaryPart { get; set; }

            public override bool Equals(object newОbject)
            {
                if (newОbject is ComplexNumber)
                {
                    ComplexNumber NewComplexNumber = newОbject as ComplexNumber;
                    return NewComplexNumber.RealPart == RealPart && NewComplexNumber.ImaginaryPart == ImaginaryPart;
                }
                return base.Equals(newОbject);
            }

            public readonly static ComplexNumber ComplexNumberZero = new ComplexNumber()
            {
                RealPart = 0,
                ImaginaryPart = 0
            };

            public ComplexNumber Multiply(ComplexNumber multiplier)
            {
                return new ComplexNumber()
                {
                    RealPart = RealPart * multiplier.RealPart - ImaginaryPart * multiplier.ImaginaryPart,
                    ImaginaryPart = RealPart * multiplier.ImaginaryPart + ImaginaryPart * multiplier.RealPart
                };
            }
            public double GetAbS()
            {
                return Math.Sqrt( RealPart * RealPart + ImaginaryPart * ImaginaryPart);
            }

            public ComplexNumber Add(ComplexNumber addition)
            {
                return new ComplexNumber()
                {
                    RealPart = RealPart + addition.RealPart,
                    ImaginaryPart = ImaginaryPart + addition.ImaginaryPart
                };
            }
            public double GetAngleInDegrees()
            {
                return Math.Atan(ImaginaryPart / RealPart);
            }
            public ComplexNumber Subtract(ComplexNumber reducer)
            {
                return new ComplexNumber()
                {
                    RealPart = RealPart - reducer.RealPart,
                    ImaginaryPart = ImaginaryPart - reducer.ImaginaryPart
                };
            }

            public override string ToString()
            {
                return $"({RealPart} + {ImaginaryPart}i)";
            }

            internal ComplexNumber Divide(ComplexNumber denominator)
            {
                var divisorPart = this.Multiply(new ComplexNumber() { RealPart = denominator.RealPart, ImaginaryPart = -denominator.ImaginaryPart });
                var denominatorPart = denominator.RealPart * denominator.RealPart + denominator.ImaginaryPart * denominator.ImaginaryPart;

                return new ComplexNumber()
                {
                    RealPart = divisorPart.RealPart / denominatorPart,
                    ImaginaryPart =(divisorPart.ImaginaryPart / denominatorPart)
                };
            }
        }
    }
}
