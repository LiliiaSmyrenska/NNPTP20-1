using System.Collections.Generic;
namespace INPTPZ1
{

    namespace Mathematics
    {
        class Polynom
        {
            public List<ComplexNumber> ComplexNumberList { get; set; }

            public Polynom() => ComplexNumberList = new List<ComplexNumber>();

            public Polynom Derive()
            {
                Polynom newPolynom = new Polynom();
                for (int i = 1; i < ComplexNumberList.Count; i++)
                {
                    newPolynom.ComplexNumberList.Add(ComplexNumberList[i].Multiply(new ComplexNumber() { RealPart = i }));
                }

                return newPolynom;
            }

            public ComplexNumber Eval(ComplexNumber newNumber)
            {
                ComplexNumber number = ComplexNumber.ComplexNumberZero;
                for (int i = 0; i < ComplexNumberList.Count; i++)
                {
                    ComplexNumber PolynomialСoefficient = ComplexNumberList[i];
                    ComplexNumber multiplication = newNumber;
                    int power = i;

                    if (i > 0)
                    {
                        for (int j = 0; j < power - 1; j++)
                            multiplication = multiplication.Multiply(newNumber);

                        PolynomialСoefficient = PolynomialСoefficient.Multiply(multiplication);
                    }

                    number = number.Add(PolynomialСoefficient);
                }

                return number;
            }

            public override string ToString()
            {
                string returnedString = "";
                for (int i = 0; i < ComplexNumberList.Count; i++)
                {
                    returnedString += ComplexNumberList[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            returnedString += "x";
                        }
                    }
                    returnedString += " + ";
                }
                return returnedString;
            }
        }
    }
}
