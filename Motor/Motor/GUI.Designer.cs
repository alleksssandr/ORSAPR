using System;

using System.Windows.Forms;


namespace Motor
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LenBox = new System.Windows.Forms.TextBox();
            this.DiameretBox = new System.Windows.Forms.TextBox();
            this.LenRotor = new System.Windows.Forms.TextBox();
            this.DiameretRotor = new System.Windows.Forms.TextBox();
            this.LenPin = new System.Windows.Forms.TextBox();
            this.WidthFindings = new System.Windows.Forms.TextBox();
            this.LenFindings = new System.Windows.Forms.TextBox();
            this.HeightFindings = new System.Windows.Forms.TextBox();
            this.DiameretPorts = new System.Windows.Forms.TextBox();
            this.CountPorts = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StartBuild = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CountGrille = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.StartTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LenBox
            // 
            this.LenBox.Location = new System.Drawing.Point(101, 16);
            this.LenBox.MaxLength = 3;
            this.LenBox.Name = "LenBox";
            this.LenBox.Size = new System.Drawing.Size(74, 20);
            this.LenBox.TabIndex = 0;
            this.LenBox.Text = "300";
            this.LenBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // DiameretBox
            // 
            this.DiameretBox.Location = new System.Drawing.Point(101, 42);
            this.DiameretBox.MaxLength = 3;
            this.DiameretBox.Name = "DiameretBox";
            this.DiameretBox.Size = new System.Drawing.Size(74, 20);
            this.DiameretBox.TabIndex = 1;
            this.DiameretBox.Text = "200";
            this.DiameretBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // LenRotor
            // 
            this.LenRotor.Location = new System.Drawing.Point(101, 17);
            this.LenRotor.MaxLength = 3;
            this.LenRotor.Name = "LenRotor";
            this.LenRotor.Size = new System.Drawing.Size(74, 20);
            this.LenRotor.TabIndex = 2;
            this.LenRotor.Text = "50";
            this.LenRotor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // DiameretRotor
            // 
            this.DiameretRotor.Location = new System.Drawing.Point(101, 43);
            this.DiameretRotor.MaxLength = 3;
            this.DiameretRotor.Name = "DiameretRotor";
            this.DiameretRotor.Size = new System.Drawing.Size(74, 20);
            this.DiameretRotor.TabIndex = 3;
            this.DiameretRotor.Text = "50";
            this.DiameretRotor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // LenPin
            // 
            this.LenPin.Location = new System.Drawing.Point(101, 78);
            this.LenPin.MaxLength = 3;
            this.LenPin.Name = "LenPin";
            this.LenPin.Size = new System.Drawing.Size(74, 20);
            this.LenPin.TabIndex = 4;
            this.LenPin.Text = "10";
            this.LenPin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // WidthFindings
            // 
            this.WidthFindings.Location = new System.Drawing.Point(86, 16);
            this.WidthFindings.MaxLength = 3;
            this.WidthFindings.Name = "WidthFindings";
            this.WidthFindings.Size = new System.Drawing.Size(74, 20);
            this.WidthFindings.TabIndex = 5;
            this.WidthFindings.Text = "50";
            this.WidthFindings.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // LenFindings
            // 
            this.LenFindings.Location = new System.Drawing.Point(86, 42);
            this.LenFindings.MaxLength = 3;
            this.LenFindings.Name = "LenFindings";
            this.LenFindings.Size = new System.Drawing.Size(74, 20);
            this.LenFindings.TabIndex = 6;
            this.LenFindings.Text = "100";
            this.LenFindings.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // HeightFindings
            // 
            this.HeightFindings.Location = new System.Drawing.Point(86, 68);
            this.HeightFindings.MaxLength = 3;
            this.HeightFindings.Name = "HeightFindings";
            this.HeightFindings.Size = new System.Drawing.Size(74, 20);
            this.HeightFindings.TabIndex = 7;
            this.HeightFindings.Text = "30";
            this.HeightFindings.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // DiameretPorts
            // 
            this.DiameretPorts.Location = new System.Drawing.Point(86, 97);
            this.DiameretPorts.MaxLength = 2;
            this.DiameretPorts.Name = "DiameretPorts";
            this.DiameretPorts.Size = new System.Drawing.Size(74, 20);
            this.DiameretPorts.TabIndex = 8;
            this.DiameretPorts.Text = "10";
            this.DiameretPorts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // CountPorts
            // 
            this.CountPorts.Location = new System.Drawing.Point(86, 143);
            this.CountPorts.MaxLength = 1;
            this.CountPorts.Name = "CountPorts";
            this.CountPorts.Size = new System.Drawing.Size(74, 20);
            this.CountPorts.TabIndex = 9;
            this.CountPorts.Text = "2";
            this.CountPorts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Длина";
            // 
            // StartBuild
            // 
            this.StartBuild.Location = new System.Drawing.Point(219, 205);
            this.StartBuild.Name = "StartBuild";
            this.StartBuild.Size = new System.Drawing.Size(178, 29);
            this.StartBuild.TabIndex = 11;
            this.StartBuild.Text = "Старт";
            this.StartBuild.UseVisualStyleBackColor = true;
            this.StartBuild.Click += new System.EventHandler(this.StartBuild_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Диаметр";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Длина ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Диаметр ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Длина";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ширина";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Длина";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Высота";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Диаметр";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Количество";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.CountGrille);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LenBox);
            this.groupBox1.Controls.Add(this.DiameretBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 114);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры корпуса";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 93);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "радиатора";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "элементов";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CountGrille
            // 
            this.CountGrille.Location = new System.Drawing.Point(101, 80);
            this.CountGrille.MaxLength = 2;
            this.CountGrille.Name = "CountGrille";
            this.CountGrille.Size = new System.Drawing.Size(74, 20);
            this.CountGrille.TabIndex = 24;
            this.CountGrille.Text = "10";
            this.CountGrille.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckCharInt);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 67);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Количество ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.LenRotor);
            this.groupBox2.Controls.Add(this.DiameretRotor);
            this.groupBox2.Controls.Add(this.LenPin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 127);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры вала";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "фиксирующей";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "понки ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.WidthFindings);
            this.groupBox3.Controls.Add(this.LenFindings);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.HeightFindings);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.DiameretPorts);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.CountPorts);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(219, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 187);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры коробки выводов";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 146);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(70, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "подводимых";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 159);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(52, 13);
            this.label17.TabIndex = 22;
            this.label17.Text = "кабелей ";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 13);
            this.label16.TabIndex = 21;
            this.label16.Text = "отверстия";
            // 
            // StartTest
            // 
            this.StartTest.Location = new System.Drawing.Point(219, 240);
            this.StartTest.Name = "StartTest";
            this.StartTest.Size = new System.Drawing.Size(178, 29);
            this.StartTest.TabIndex = 24;
            this.StartTest.Text = "Тест";
            this.StartTest.UseVisualStyleBackColor = true;
            this.StartTest.Click += new System.EventHandler(this.StartTest_Click);
            // 
            // GUI
            // 
            this.ClientSize = new System.Drawing.Size(413, 278);
            this.Controls.Add(this.StartTest);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartBuild);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "GUI";
            this.Text = "Электромотор";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LenBox;
        private System.Windows.Forms.TextBox DiameretBox;
        private System.Windows.Forms.TextBox LenRotor;
        private System.Windows.Forms.TextBox DiameretRotor;
        private System.Windows.Forms.TextBox LenPin;
        private System.Windows.Forms.TextBox WidthFindings;
        private System.Windows.Forms.TextBox LenFindings;
        private System.Windows.Forms.TextBox HeightFindings;
        private System.Windows.Forms.TextBox DiameretPorts;
        private System.Windows.Forms.TextBox CountPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button StartBuild;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox CountGrille;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;

        //функция проверки на вводимые символы (только цифры)
        public void CheckCharInt(Object o, KeyPressEventArgs e)
        {
            //47 - 0 ; 58 - 9 
           // if ((e.KeyChar <= '47' || e.KeyChar >= '58') && e.KeyChar != 8)
            //    e.Handled = true;
        }

        private Button StartTest;

    }
}