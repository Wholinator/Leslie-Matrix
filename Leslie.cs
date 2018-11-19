// Decompiled with JetBrains decompiler
// Type: Stable_Age_Dist.Leslie
// Assembly: Stable Age Dist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66147A2C-38C1-4B2F-834D-E3695FC60FE1
// Assembly location: C:\Users\s524063\Desktop\Stable Age Dist.exe

using System;
using System.Text;

namespace Stable_Age_Dist
{
  public class Leslie
  {
    public double eigenValue = 0.0;
    public int fSelect = 2;
    public int sSelect = 1;
    public double[,] matrix;
    public double[] fecundity;
    public double[] survival;
    public double[] initPop;
    public double[] currentPop;
    public double[] currentPopPercentage;
    public int generation;

    public Leslie(int rows)
    {
      this.matrix = new double[rows, rows];
      this.fecundity = new double[4]{ 0.7, 2.2, 2.0, 0.2 };
      this.survival = new double[4]{ 0.5, 0.7, 0.8, 0.3 };
      this.initPop = new double[5]
      {
        0.0,
        50.0,
        50.0,
        0.0,
        0.0
      };
      this.currentPopPercentage = new double[5];
      this.makeArray();
    }

    public void makeArray()
    {
      for (int index = 0; index < 4; ++index)
      {
        this.matrix[0, index + 1] = this.fecundity[index];
        this.matrix[index + 1, index] = this.survival[index];
      }
    }

    public double[,] getMatrix()
    {
      return this.matrix;
    }

    public override string ToString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < 5; ++index)
      {
        string str = string.Format("{0,-4} {1,-4} {2,-4} {3,-4} {4,-4}", (object) this.matrix[index, 0], (object) this.matrix[index, 1], (object) this.matrix[index, 2], (object) this.matrix[index, 3], (object) this.matrix[index, 4]);
        stringBuilder.Append(str).Append("\n");
      }
      return stringBuilder.ToString();
    }

    public void setF(int f)
    {
      this.fSelect = f;
    }

    public void setS(int s)
    {
      this.sSelect = s;
    }

    public void changeFecundity(int value)
    {
      switch (this.fSelect)
      {
        case 2:
          this.fecundity[1] = (double) value / 10.0;
          this.matrix[0, 1] = this.fecundity[1];
          break;
        case 3:
          this.fecundity[2] = (double) value / 10.0;
          this.matrix[0, 2] = this.fecundity[2];
          break;
        case 4:
          this.fecundity[3] = (double) value / 10.0;
          this.matrix[0, 3] = this.fecundity[3];
          break;
      }
    }

    public void changeSurvival(int value)
    {
      switch (this.sSelect)
      {
        case 1:
          this.survival[0] = (double) value / 100.0;
          this.matrix[1, 0] = this.survival[0];
          break;
        case 2:
          this.survival[1] = (double) value / 100.0;
          this.matrix[2, 1] = this.survival[1];
          break;
        case 3:
          this.survival[2] = (double) value / 100.0;
          this.matrix[3, 2] = this.survival[2];
          break;
      }
    }

    public void changeGeneration(int value)
    {
      this.generation = value;
    }

    public double[] charEq()
    {
      return new double[6]
      {
        1.0,
        0.0,
        this.fecundity[0] * this.survival[0],
        this.fecundity[1] * this.survival[0] * this.survival[1],
        this.fecundity[2] * this.survival[0] * this.survival[1] * this.survival[2],
        this.fecundity[3] * this.survival[0] * this.survival[1] * this.survival[2] * this.survival[3]
      };
    }

    public string charEqToString(double[] characteristic)
    {
      return string.Format("({0})λ\x2075 - ({1:0.000})λ\x00B3 - ({2:0.0000})λ\x00B2 - ({3:0.0000})λ - {4:0.0000} = 0", (object) characteristic[0], (object) characteristic[2], (object) characteristic[3], (object) characteristic[4], (object) characteristic[5]);
    }

    public double rootConverge()
    {
      double[] func = this.charEq();
      double num1 = 0.0;
      double X1 = 2.0;
      double num2 = -func[5];
      double num3 = this.polyCalc(X1, func);
      double num4 = num2;
      while (num2 < 1E-07 && num3 > 1E-07)
      {
        double X2 = (num1 + X1) / 2.0;
        double num5 = this.polyCalc(X2, func);
        if (num5 < 0.0)
        {
          num1 = X2;
          num2 = num5;
        }
        else
        {
          X1 = X2;
          num3 = num5;
        }
        num4 = X2;
        this.eigenValue = X2;
      }
      return num4;
    }

    public double polyCalc(double X, double[] func)
    {
      return func[0] * Math.Pow(X, 5.0) - func[2] * Math.Pow(X, 3.0) - func[3] * Math.Pow(X, 2.0) - func[4] * X - func[5];
    }

    public double[] matrixMult(double[] pop)
    {
      double[] numArray = new double[5];
      for (int index = 0; index < 5; ++index)
        numArray[0] += pop[index] * this.matrix[0, index];
      numArray[1] = this.matrix[1, 0] * pop[0];
      numArray[2] = this.matrix[2, 1] * pop[1];
      numArray[3] = this.matrix[3, 2] * pop[2];
      numArray[4] = this.matrix[4, 3] * pop[3];
      return numArray;
    }

    public double[] matMultIter(int iter, double[] pop)
    {
      for (int index = 0; index < iter; ++index)
        pop = this.matrixMult(pop);
      this.currentPop = pop;
      double num1 = 0.0;
      foreach (double num2 in pop)
        num1 += num2;
      for (int index = 0; index < 5; ++index)
        this.currentPopPercentage[index] = this.currentPop[index] / num1;
      return pop;
    }

    public string percentPopVecToString(double[] pop)
    {
      double num1 = 0.0;
      foreach (double num2 in pop)
        num1 += num2;
      string str = "";
      foreach (double num2 in pop)
        str = str + string.Format("{0:0.00}", (object) (num2 / num1 * 100.0)) + "\n";
      return str;
    }

    public string popVecToString(double[] pop)
    {
      string str = "";
      foreach (double num in pop)
        str = str + string.Format("{0:0}", (object) num) + "\n";
      return str;
    }

    public string getEigenVector()
    {
      double[] numArray = new double[5]
      {
        1.0,
        Math.Pow(this.eigenValue, -1.0) * this.survival[0],
        Math.Pow(this.eigenValue, -2.0) * this.survival[0] * this.survival[1],
        Math.Pow(this.eigenValue, -3.0) * this.survival[0] * this.survival[1] * this.survival[2],
        Math.Pow(this.eigenValue, -4.0) * this.survival[0] * this.survival[1] * this.survival[2] * this.survival[3]
      };
      string str = "[ ";
      foreach (double num in numArray)
        str = str + string.Format("{0:0.000}", (object) num) + " ";
      return "Eigen Vector: " + (str + "]");
    }
  }
}
