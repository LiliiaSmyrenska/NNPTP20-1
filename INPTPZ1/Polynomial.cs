using System.Collections.Generic;
namespace INPTPZ1
{

    namespace Mathematics
    {
        class Polynomial
        {
            public List<ComplexNumberCalculate> ComplexNumberList { get; set; }

            public Polynomial() => ComplexNumberList = new List<ComplexNumberCalculate>();

            public Polynomial Derive()
            {
                Polynomial newPolynom = new Polynomial();
                for (int i = 1; i < ComplexNumberList.Count; i++)
                {
                    newPolynom.ComplexNumberList.Add(ComplexNumberList[i].Multiply(new ComplexNumberCalculate() { RealPart = i }));
                }

                return newPolynom;
            }

            public ComplexNumberCalculate Eval(ComplexNumberCalculate newNumber)
            {
                ComplexNumberCalculate number = ComplexNumberCalculate.ComplexNumberZero;
                for (int i = 0; i < ComplexNumberList.Count; i++)
                {
                    ComplexNumberCalculate PolynomialСoefficient = ComplexNumberList[i];
                    ComplexNumberCalculate multiplication = newNumber;
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
