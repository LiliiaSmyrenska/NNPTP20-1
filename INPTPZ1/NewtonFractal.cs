using System;
using System.Collections.Generic;
using System.Drawing;
using INPTPZ1.Mathematics;

namespace INPTPZ1
{
    class NewtonFractal
    {
        private const double NEWNUMBERZERO = 0.0001;
        private static Bitmap bitmap;
        private static double xMinimum, xMaximum, yMinimum, yMaximum, xStep, yStep;
        private static Polynom polynoms, polinomDerive;
        private static string path;



        static void Main(string[] args)
        {
            path = args[6];
            bitmap = new Bitmap(int.Parse(args[0]), int.Parse(args[1]));
            xMinimum = double.Parse(args[2]);
            xMaximum = double.Parse(args[3]);
            yMinimum = double.Parse(args[4]);
            yMaximum = double.Parse(args[5]);
            xStep = (xMaximum - xMinimum) / int.Parse(args[0]);
            yStep = (yMaximum - yMinimum) / int.Parse(args[1]);
            var colors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };
            List<ComplexNumber> roots = Polynoms();
            Console.WriteLine(polynoms);
            Console.WriteLine(polinomDerive);
            var maxId = 0;
            for (int i = 0; i < int.Parse(args[0]); i++)
            {
                for (int j = 0; j < int.Parse(args[1]); j++)
                {
                    ComplexNumber complexNumber = ComplexNumber(i, j);
                    float iteration = Iteration(ref complexNumber);
                    int id = RootNumbers(roots, ref maxId, complexNumber);
                    ChoiceColors(colors, i, j, iteration, id);
                }
            }
            bitmap.Save(path ?? "../../../out.png");
        }

        private static void ChoiceColors(Color[] colors, int i, int j, float iteration, int id)
        {
            var color = colors[id % colors.Length];
            color = Color.FromArgb(color.R, color.G, color.B);
            color = Color.FromArgb(Math.Min(Math.Max(0, color.R - (int)iteration * 2), 255), Math.Min(Math.Max(0, color.G - (int)iteration * 2), 255), Math.Min(Math.Max(0, color.B - (int)iteration * 2), 255));
            bitmap.SetPixel(j, i, color);
        }

        private static int RootNumbers(List<ComplexNumber> roots, ref int maxId, ComplexNumber complexNumber)
        {
            var known = false;
            var id = 0;
            for (int i = 0; i < roots.Count; i++)
            {
                if (Math.Pow(complexNumber.RealPart - roots[i].RealPart, 2) + Math.Pow(complexNumber.ImaginaryPart - roots[i].ImaginaryPart, 2) <= 0.01)
                {
                    known = true;
                    id = i;
                }
            }
            if (!known)
            {
                roots.Add(complexNumber);
                id = roots.Count;
                maxId = id + 1;
            }

            return id;
        }

        private static float Iteration(ref ComplexNumber complexNumber)
        {
            float iteration = 0;
            for (int i = 0; i < 30; i++)
            {
                var diff = polynoms.Eval(complexNumber).Divide(polinomDerive.Eval(complexNumber));
                complexNumber = complexNumber.Subtract(diff);

                if (Math.Pow(diff.RealPart, 2) + Math.Pow(diff.ImaginaryPart, 2) >= 0.5)
                {
                    i--;
                }
                iteration++;
            }

            return iteration;
        }

        private static ComplexNumber ComplexNumber(int width, int height)
        {
            double newNumberImaginary = yMinimum + width * yStep;
            double newNumberReal = xMinimum + height * xStep;

            ComplexNumber complexNumber = new ComplexNumber()
            {
                RealPart = newNumberReal,
                ImaginaryPart = newNumberImaginary
            };

            if (complexNumber.RealPart == 0)
                complexNumber.RealPart = NEWNUMBERZERO;
            if (complexNumber.ImaginaryPart == 0)
                complexNumber.ImaginaryPart = NEWNUMBERZERO;
            return complexNumber;
        }

        private static List<ComplexNumber> Polynoms()
        {
            List<ComplexNumber> roots = new List<ComplexNumber>();
            polynoms = new Polynom();
            polynoms.ComplexNumberList.Add(new ComplexNumber() { RealPart = 1 });
            polynoms.ComplexNumberList.Add(Mathematics.ComplexNumber.ComplexNumberZero);
            polynoms.ComplexNumberList.Add(Mathematics.ComplexNumber.ComplexNumberZero);
            polynoms.ComplexNumberList.Add(new ComplexNumber() { RealPart = 1 });
            polinomDerive = polynoms.Derive();
            return roots;
        }
    }

}
