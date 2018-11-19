// Decompiled with JetBrains decompiler
// Type: Stable_Age_Dist.Program
// Assembly: Stable Age Dist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66147A2C-38C1-4B2F-834D-E3695FC60FE1
// Assembly location: C:\Users\s524063\Desktop\Stable Age Dist.exe

using System;
using System.Windows.Forms;

namespace Stable_Age_Dist
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new Form1());
    }
  }
}
