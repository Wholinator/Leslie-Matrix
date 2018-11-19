// Decompiled with JetBrains decompiler
// Type: Stable_Age_Dist.Form1
// Assembly: Stable Age Dist, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 66147A2C-38C1-4B2F-834D-E3695FC60FE1
// Assembly location: C:\Users\s524063\Desktop\Stable Age Dist.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Stable_Age_Dist
{
  public class Form1 : Form
  {
    public Leslie l = new Leslie(5);
    private IContainer components = (IContainer) null;
    private TrackBar Fecundity;
    private TrackBar Survival;
    private TrackBar Generation;
    private Button F4;
    private Button S1;
    private Button S2;
    private Button F2;
    private Button F3;
    private Button S3;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label MatrixVisual;
    private Label GenerationText;
    private Chart LeslieChart;
    private Label CharEq;
    private Label label7;
    private Label domEigen;
    private Label PerPopVec;
    private Label label6;
    private Label label8;
    private Label label9;
    private Label TotPopVec;
    private Label EigenVector;

    public Form1()
    {
      this.InitializeComponent();
      this.chart_Init(this.l.initPop);
      this.updateEverything();
    }

    private void updateEverything()
    {
      this.MatrixVisual.Text = this.l.ToString();
      this.CharEq.Text = this.l.charEqToString(this.l.charEq());
      this.domEigen.Text = "Dominant Eigenvalue: " + (object) this.l.rootConverge();
      double[] pop = this.l.matMultIter(this.Generation.Value, this.l.initPop);
      this.PerPopVec.Text = this.l.percentPopVecToString(pop);
      this.TotPopVec.Text = this.l.popVecToString(pop);
      this.EigenVector.Text = this.l.getEigenVector();
      this.chart_Update(this.l.currentPop);
    }

    private void Fecundity_Scroll(object sender, EventArgs e)
    {
      this.l.changeFecundity(this.Fecundity.Value);
      this.updateEverything();
    }

    private void Survival_Scroll(object sender, EventArgs e)
    {
      this.l.changeSurvival(this.Survival.Value);
      this.updateEverything();
    }

    private void Generation_Scroll(object sender, EventArgs e)
    {
      this.l.changeGeneration(this.Generation.Value);
      this.GenerationText.Text = string.Concat((object) this.Generation.Value);
      this.updateEverything();
    }

    private void F2_Click(object sender, EventArgs e)
    {
      this.l.setF(2);
      this.F2.BackColor = SystemColors.ControlDark;
      this.F3.BackColor = SystemColors.Control;
      this.F4.BackColor = SystemColors.Control;
    }

    private void F3_Click(object sender, EventArgs e)
    {
      this.l.setF(3);
      this.F3.BackColor = SystemColors.ControlDark;
      this.F2.BackColor = SystemColors.Control;
      this.F4.BackColor = SystemColors.Control;
    }

    private void F4_Click(object sender, EventArgs e)
    {
      this.l.setF(4);
      this.F4.BackColor = SystemColors.ControlDark;
      this.F3.BackColor = SystemColors.Control;
      this.F2.BackColor = SystemColors.Control;
    }

    private void S1_Click(object sender, EventArgs e)
    {
      this.l.setS(1);
      this.S1.BackColor = SystemColors.ControlDark;
      this.S2.BackColor = SystemColors.Control;
      this.S3.BackColor = SystemColors.Control;
    }

    private void S2_Click(object sender, EventArgs e)
    {
      this.l.setS(2);
      this.S2.BackColor = SystemColors.ControlDark;
      this.S1.BackColor = SystemColors.Control;
      this.S3.BackColor = SystemColors.Control;
    }

    private void S3_Click(object sender, EventArgs e)
    {
      this.l.setS(3);
      this.S3.BackColor = SystemColors.ControlDark;
      this.S2.BackColor = SystemColors.Control;
      this.S1.BackColor = SystemColors.Control;
    }

    private void chart_Init(double[] pop)
    {
      Series series1 = this.LeslieChart.Series.Add("Class Total");
      Series series2 = this.LeslieChart.Series.Add("Class Percentage");
      this.LeslieChart.Series[0].YAxisType = AxisType.Primary;
      this.LeslieChart.Series[1].YAxisType = AxisType.Secondary;
      this.LeslieChart.ChartAreas[0].AxisY2.Maximum = 1.0;
      for (int index = 0; index < pop.Length; ++index)
      {
        series1.Points.Add(pop[index]);
        series2.Points.Add(this.l.currentPopPercentage[index]);
      }
    }

    private void chart_Update(double[] pop)
    {
      this.LeslieChart.Series["Class Total"].Points.Clear();
      this.LeslieChart.Series["Class Percentage"].Points.Clear();
      for (int index = 0; index < 5; ++index)
      {
        this.LeslieChart.Series["Class Percentage"].Points.Add(this.l.currentPopPercentage[index]);
        this.LeslieChart.Series["Class Total"].Points.Add(pop[index]);
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ChartArea chartArea = new ChartArea();
      this.Fecundity = new TrackBar();
      this.Survival = new TrackBar();
      this.Generation = new TrackBar();
      this.F4 = new Button();
      this.S1 = new Button();
      this.S2 = new Button();
      this.F2 = new Button();
      this.F3 = new Button();
      this.S3 = new Button();
      this.label1 = new Label();
      this.label2 = new Label();
      this.label3 = new Label();
      this.label4 = new Label();
      this.label5 = new Label();
      this.MatrixVisual = new Label();
      this.GenerationText = new Label();
      this.LeslieChart = new Chart();
      this.CharEq = new Label();
      this.label7 = new Label();
      this.domEigen = new Label();
      this.PerPopVec = new Label();
      this.label6 = new Label();
      this.label8 = new Label();
      this.label9 = new Label();
      this.TotPopVec = new Label();
      this.EigenVector = new Label();
      this.Fecundity.BeginInit();
      this.Survival.BeginInit();
      this.Generation.BeginInit();
      this.LeslieChart.BeginInit();
      this.SuspendLayout();
      this.Fecundity.Location = new Point(480, 35);
      this.Fecundity.Maximum = 25;
      this.Fecundity.Minimum = 1;
      this.Fecundity.Name = "Fecundity";
      this.Fecundity.Size = new Size(173, 45);
      this.Fecundity.TabIndex = 0;
      this.Fecundity.Value = 1;
      this.Fecundity.Scroll += new EventHandler(this.Fecundity_Scroll);
      this.Survival.Location = new Point(480, 95);
      this.Survival.Maximum = 90;
      this.Survival.Minimum = 10;
      this.Survival.Name = "Survival";
      this.Survival.Size = new Size(173, 45);
      this.Survival.TabIndex = 1;
      this.Survival.Value = 10;
      this.Survival.Scroll += new EventHandler(this.Survival_Scroll);
      this.Generation.Location = new Point(480, 155);
      this.Generation.Maximum = 60;
      this.Generation.Minimum = 1;
      this.Generation.Name = "Generation";
      this.Generation.Size = new Size(173, 45);
      this.Generation.TabIndex = 2;
      this.Generation.Value = 1;
      this.Generation.Scroll += new EventHandler(this.Generation_Scroll);
      this.F4.Location = new Point(460, 35);
      this.F4.Name = "F4";
      this.F4.Size = new Size(20, 20);
      this.F4.TabIndex = 3;
      this.F4.Text = "4";
      this.F4.UseVisualStyleBackColor = true;
      this.F4.Click += new EventHandler(this.F4_Click);
      this.S1.BackColor = SystemColors.ControlDark;
      this.S1.Location = new Point(420, 95);
      this.S1.Name = "S1";
      this.S1.Size = new Size(20, 20);
      this.S1.TabIndex = 4;
      this.S1.Text = "1";
      this.S1.UseVisualStyleBackColor = false;
      this.S1.Click += new EventHandler(this.S1_Click);
      this.S2.Location = new Point(440, 95);
      this.S2.Name = "S2";
      this.S2.Size = new Size(20, 20);
      this.S2.TabIndex = 5;
      this.S2.Text = "2";
      this.S2.UseVisualStyleBackColor = true;
      this.S2.Click += new EventHandler(this.S2_Click);
      this.F2.BackColor = SystemColors.ControlDark;
      this.F2.Location = new Point(420, 35);
      this.F2.Name = "F2";
      this.F2.Size = new Size(20, 20);
      this.F2.TabIndex = 6;
      this.F2.Text = "2";
      this.F2.UseVisualStyleBackColor = false;
      this.F2.Click += new EventHandler(this.F2_Click);
      this.F3.Location = new Point(440, 35);
      this.F3.Name = "F3";
      this.F3.Size = new Size(20, 20);
      this.F3.TabIndex = 7;
      this.F3.Text = "3";
      this.F3.UseVisualStyleBackColor = true;
      this.F3.Click += new EventHandler(this.F3_Click);
      this.S3.Location = new Point(460, 95);
      this.S3.Name = "S3";
      this.S3.Size = new Size(20, 20);
      this.S3.TabIndex = 8;
      this.S3.Text = "3";
      this.S3.UseVisualStyleBackColor = true;
      this.S3.Click += new EventHandler(this.S3_Click);
      this.label1.AutoSize = true;
      this.label1.Location = new Point(420, 13);
      this.label1.Name = "label1";
      this.label1.Size = new Size(55, 13);
      this.label1.TabIndex = 9;
      this.label1.Text = "Parameter";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(538, 13);
      this.label2.Name = "label2";
      this.label2.Size = new Size(53, 13);
      this.label2.TabIndex = 10;
      this.label2.Text = "Fecundity";
      this.label3.AutoSize = true;
      this.label3.Location = new Point(420, 76);
      this.label3.Name = "label3";
      this.label3.Size = new Size(55, 13);
      this.label3.TabIndex = 11;
      this.label3.Text = "Parameter";
      this.label4.AutoSize = true;
      this.label4.Location = new Point(541, 75);
      this.label4.Name = "label4";
      this.label4.Size = new Size(45, 13);
      this.label4.TabIndex = 12;
      this.label4.Text = "Survival";
      this.label5.AutoSize = true;
      this.label5.Location = new Point(541, 136);
      this.label5.Name = "label5";
      this.label5.Size = new Size(59, 13);
      this.label5.TabIndex = 13;
      this.label5.Text = "Generation";
      this.MatrixVisual.AutoSize = true;
      this.MatrixVisual.Font = new Font("Courier New", 8.25f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.MatrixVisual.Location = new Point(457, 216);
      this.MatrixVisual.Name = "MatrixVisual";
      this.MatrixVisual.Size = new Size(0, 14);
      this.MatrixVisual.TabIndex = 14;
      this.GenerationText.AutoSize = true;
      this.GenerationText.Location = new Point(467, 155);
      this.GenerationText.Name = "GenerationText";
      this.GenerationText.Size = new Size(13, 13);
      this.GenerationText.TabIndex = 15;
      this.GenerationText.Text = "0";
      chartArea.Name = "ChartArea1";
      this.LeslieChart.ChartAreas.Add(chartArea);
      this.LeslieChart.Location = new Point(12, 136);
      this.LeslieChart.Name = "LeslieChart";
      this.LeslieChart.Palette = ChartColorPalette.Fire;
      this.LeslieChart.Size = new Size(428, 351);
      this.LeslieChart.TabIndex = 16;
      this.LeslieChart.Text = "chart1";
      this.CharEq.AutoSize = true;
      this.CharEq.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.CharEq.Location = new Point(13, 35);
      this.CharEq.Name = "CharEq";
      this.CharEq.Size = new Size(0, 20);
      this.CharEq.TabIndex = 17;
      this.label7.AutoSize = true;
      this.label7.Location = new Point(13, 13);
      this.label7.Name = "label7";
      this.label7.Size = new Size(119, 13);
      this.label7.TabIndex = 18;
      this.label7.Text = "Characteristic Equation:";
      this.domEigen.AutoSize = true;
      this.domEigen.Location = new Point(13, 67);
      this.domEigen.Name = "domEigen";
      this.domEigen.Size = new Size(114, 13);
      this.domEigen.TabIndex = 19;
      this.domEigen.Text = "Dominant Eigenvalue: ";
      this.PerPopVec.AutoSize = true;
      this.PerPopVec.Location = new Point(457, 306);
      this.PerPopVec.Name = "PerPopVec";
      this.PerPopVec.Size = new Size(0, 13);
      this.PerPopVec.TabIndex = 20;
      this.label6.AutoSize = true;
      this.label6.Location = new Point(457, 203);
      this.label6.Name = "label6";
      this.label6.Size = new Size(68, 13);
      this.label6.TabIndex = 21;
      this.label6.Text = "Leslie Matrix:";
      this.label8.AutoSize = true;
      this.label8.Location = new Point(454, 291);
      this.label8.Name = "label8";
      this.label8.Size = new Size(134, 13);
      this.label8.TabIndex = 22;
      this.label8.Text = "Percent Population Vector:";
      this.label9.AutoSize = true;
      this.label9.Location = new Point(454, 380);
      this.label9.Name = "label9";
      this.label9.Size = new Size(121, 13);
      this.label9.TabIndex = 23;
      this.label9.Text = "Total Population Vector:";
      this.TotPopVec.AutoSize = true;
      this.TotPopVec.Location = new Point(457, 393);
      this.TotPopVec.Name = "TotPopVec";
      this.TotPopVec.Size = new Size(0, 13);
      this.TotPopVec.TabIndex = 24;
      this.EigenVector.AutoSize = true;
      this.EigenVector.Location = new Point(13, 90);
      this.EigenVector.Name = "EigenVector";
      this.EigenVector.Size = new Size(71, 13);
      this.EigenVector.TabIndex = 25;
      this.EigenVector.Text = "Eigen Vector:";
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(674, 499);
      this.Controls.Add((Control) this.EigenVector);
      this.Controls.Add((Control) this.TotPopVec);
      this.Controls.Add((Control) this.label9);
      this.Controls.Add((Control) this.label8);
      this.Controls.Add((Control) this.label6);
      this.Controls.Add((Control) this.PerPopVec);
      this.Controls.Add((Control) this.domEigen);
      this.Controls.Add((Control) this.label7);
      this.Controls.Add((Control) this.CharEq);
      this.Controls.Add((Control) this.LeslieChart);
      this.Controls.Add((Control) this.GenerationText);
      this.Controls.Add((Control) this.MatrixVisual);
      this.Controls.Add((Control) this.label5);
      this.Controls.Add((Control) this.label4);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.S3);
      this.Controls.Add((Control) this.F3);
      this.Controls.Add((Control) this.F2);
      this.Controls.Add((Control) this.S2);
      this.Controls.Add((Control) this.S1);
      this.Controls.Add((Control) this.F4);
      this.Controls.Add((Control) this.Generation);
      this.Controls.Add((Control) this.Survival);
      this.Controls.Add((Control) this.Fecundity);
      this.Name = nameof (Form1);
      this.Text = nameof (Form1);
      this.Fecundity.EndInit();
      this.Survival.EndInit();
      this.Generation.EndInit();
      this.LeslieChart.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
