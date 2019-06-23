namespace AzizaVKR
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.nuW = new System.Windows.Forms.NumericUpDown();
            this.nuH = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuH)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(930, 195);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Расчёт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(161, 213);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Очистить всё";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            this.button2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // button3
            // 
            this.button3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button3.Location = new System.Drawing.Point(279, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(155, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Очистить результаты";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            this.button3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(0, 255);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(930, 209);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(440, 216);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(193, 27);
            this.button4.TabIndex = 5;
            this.button4.Text = "Добавить границу";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.button4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // nuW
            // 
            this.nuW.Location = new System.Drawing.Point(713, 220);
            this.nuW.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nuW.Name = "nuW";
            this.nuW.Size = new System.Drawing.Size(74, 20);
            this.nuW.TabIndex = 6;
            this.nuW.ValueChanged += new System.EventHandler(this.nuW_ValueChanged);
            // 
            // nuH
            // 
            this.nuH.Location = new System.Drawing.Point(860, 219);
            this.nuH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nuH.Name = "nuH";
            this.nuH.Size = new System.Drawing.Size(58, 20);
            this.nuH.TabIndex = 7;
            this.nuH.ValueChanged += new System.EventHandler(this.nuH_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(806, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "H=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(661, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "W=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nuH);
            this.Controls.Add(this.nuW);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nuH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown nuW;
        private System.Windows.Forms.NumericUpDown nuH;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

