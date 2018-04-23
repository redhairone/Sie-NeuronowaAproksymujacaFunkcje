namespace IADZadaniePierwsze
{
    partial class Form1
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
            this.IleNeuronow = new System.Windows.Forms.TextBox();
            this.IleEpok = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.DaneDuo = new System.Windows.Forms.CheckBox();
            this.DaneUno = new System.Windows.Forms.CheckBox();
            this.START = new System.Windows.Forms.Button();
            this.wspolczynnik = new System.Windows.Forms.Label();
            this.IleNauki = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IleNeuronow
            // 
            this.IleNeuronow.Location = new System.Drawing.Point(6, 28);
            this.IleNeuronow.Name = "IleNeuronow";
            this.IleNeuronow.Size = new System.Drawing.Size(249, 20);
            this.IleNeuronow.TabIndex = 0;
            // 
            // IleEpok
            // 
            this.IleEpok.Location = new System.Drawing.Point(6, 78);
            this.IleEpok.Name = "IleEpok";
            this.IleEpok.Size = new System.Drawing.Size(249, 20);
            this.IleEpok.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.IleNauki);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.DaneDuo);
            this.splitContainer1.Panel1.Controls.Add(this.DaneUno);
            this.splitContainer1.Panel1.Controls.Add(this.START);
            this.splitContainer1.Panel1.Controls.Add(this.wspolczynnik);
            this.splitContainer1.Panel1.Controls.Add(this.IleNeuronow);
            this.splitContainer1.Panel1.Controls.Add(this.IleEpok);
            this.splitContainer1.Size = new System.Drawing.Size(776, 426);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "NEURONY";
            // 
            // DaneDuo
            // 
            this.DaneDuo.AutoSize = true;
            this.DaneDuo.Location = new System.Drawing.Point(165, 122);
            this.DaneDuo.Name = "DaneDuo";
            this.DaneDuo.Size = new System.Drawing.Size(90, 17);
            this.DaneDuo.TabIndex = 9;
            this.DaneDuo.Text = "Baza Nauki 2";
            this.DaneDuo.UseVisualStyleBackColor = true;
            // 
            // DaneUno
            // 
            this.DaneUno.AutoSize = true;
            this.DaneUno.Location = new System.Drawing.Point(6, 122);
            this.DaneUno.Name = "DaneUno";
            this.DaneUno.Size = new System.Drawing.Size(90, 17);
            this.DaneUno.TabIndex = 8;
            this.DaneUno.Text = "Baza Nauki 1";
            this.DaneUno.UseVisualStyleBackColor = true;
            // 
            // START
            // 
            this.START.BackColor = System.Drawing.Color.Red;
            this.START.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.START.Location = new System.Drawing.Point(6, 201);
            this.START.Name = "START";
            this.START.Size = new System.Drawing.Size(249, 222);
            this.START.TabIndex = 7;
            this.START.Text = "NAPRZÓD";
            this.START.UseVisualStyleBackColor = false;
            // 
            // wspolczynnik
            // 
            this.wspolczynnik.AutoSize = true;
            this.wspolczynnik.Location = new System.Drawing.Point(113, 62);
            this.wspolczynnik.Name = "wspolczynnik";
            this.wspolczynnik.Size = new System.Drawing.Size(39, 13);
            this.wspolczynnik.TabIndex = 5;
            this.wspolczynnik.Text = "EPOKI";
            // 
            // textBox1
            // 
            this.IleNauki.Location = new System.Drawing.Point(6, 168);
            this.IleNauki.Name = "textBox1";
            this.IleNauki.Size = new System.Drawing.Size(249, 20);
            this.IleNauki.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Współczynnik nauki";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Data";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox IleNeuronow;
        private System.Windows.Forms.TextBox IleEpok;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label wspolczynnik;
        private System.Windows.Forms.Button START;
        private System.Windows.Forms.CheckBox DaneDuo;
        private System.Windows.Forms.CheckBox DaneUno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IleNauki;
    }
}

