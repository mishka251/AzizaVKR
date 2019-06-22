namespace AzizaVKR
{
    partial class InputRect
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
            this.nuX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nuY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nuW = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nuH = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nuX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuH)).BeginInit();
            this.SuspendLayout();
            // 
            // nuX
            // 
            this.nuX.Location = new System.Drawing.Point(89, 12);
            this.nuX.Name = "nuX";
            this.nuX.Size = new System.Drawing.Size(99, 20);
            this.nuX.TabIndex = 0;
            this.nuX.ValueChanged += new System.EventHandler(this.nuX_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y=";
            // 
            // nuY
            // 
            this.nuY.Location = new System.Drawing.Point(89, 43);
            this.nuY.Name = "nuY";
            this.nuY.Size = new System.Drawing.Size(99, 20);
            this.nuY.TabIndex = 2;
            this.nuY.ValueChanged += new System.EventHandler(this.nuY_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "W=";
            // 
            // nuW
            // 
            this.nuW.Location = new System.Drawing.Point(89, 69);
            this.nuW.Name = "nuW";
            this.nuW.Size = new System.Drawing.Size(99, 20);
            this.nuW.TabIndex = 4;
            this.nuW.ValueChanged += new System.EventHandler(this.nuW_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "H=";
            // 
            // nuH
            // 
            this.nuH.Location = new System.Drawing.Point(89, 103);
            this.nuH.Name = "nuH";
            this.nuH.Size = new System.Drawing.Size(99, 20);
            this.nuH.TabIndex = 6;
            this.nuH.ValueChanged += new System.EventHandler(this.nuH_ValueChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(15, 150);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 25);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 150);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 25);
            this.button2.TabIndex = 9;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // InputRect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 187);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nuH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nuW);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nuY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuX);
            this.Name = "InputRect";
            this.Text = "InputRect";
            ((System.ComponentModel.ISupportInitialize)(this.nuX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nuX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nuY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nuW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nuH;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button button2;
    }
}