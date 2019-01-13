namespace RoPro
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
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.pbDetected = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetected)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSource
            // 
            this.pbSource.Location = new System.Drawing.Point(58, 51);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(176, 168);
            this.pbSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // pbDetected
            // 
            this.pbDetected.Location = new System.Drawing.Point(276, 51);
            this.pbDetected.Name = "pbDetected";
            this.pbDetected.Size = new System.Drawing.Size(182, 168);
            this.pbDetected.TabIndex = 1;
            this.pbDetected.TabStop = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(58, 287);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(402, 89);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(542, 184);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 67);
            this.button2.TabIndex = 4;
            this.button2.Text = "Распознать";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(542, 51);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 90);
            this.button1.TabIndex = 5;
            this.button1.Text = "Загрузить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pbDetected);
            this.Controls.Add(this.pbSource);
            this.Name = "Form1";
            this.Text = "Распознавание дорожных знаков ";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDetected)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbDetected;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

