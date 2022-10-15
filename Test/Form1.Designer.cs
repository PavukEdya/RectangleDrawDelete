
namespace Test
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
            this.turnOff_On_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // turnOff_On_Button
            // 
            this.turnOff_On_Button.Location = new System.Drawing.Point(0, 0);
            this.turnOff_On_Button.Name = "turnOff_On_Button";
            this.turnOff_On_Button.Size = new System.Drawing.Size(128, 23);
            this.turnOff_On_Button.TabIndex = 0;
            this.turnOff_On_Button.Text = "ВКЛ/ВЫКЛ";
            this.turnOff_On_Button.UseVisualStyleBackColor = true;
            this.turnOff_On_Button.Click += new System.EventHandler(this.turnOff_On_Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.turnOff_On_Button);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button turnOff_On_Button;
    }
}

