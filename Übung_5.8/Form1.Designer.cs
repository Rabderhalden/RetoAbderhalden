namespace Übung_5._8
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
            this.buttonStartInUIThread = new System.Windows.Forms.Button();
            this.buttonBackgroundThrad = new System.Windows.Forms.Button();
            this.labelFix = new System.Windows.Forms.Label();
            this.textBoxInputValue = new System.Windows.Forms.TextBox();
            this.labelCurrentValue = new System.Windows.Forms.Label();
            this.labelOutputFix = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStartInUIThread
            // 
            this.buttonStartInUIThread.Location = new System.Drawing.Point(534, 112);
            this.buttonStartInUIThread.Name = "buttonStartInUIThread";
            this.buttonStartInUIThread.Size = new System.Drawing.Size(165, 50);
            this.buttonStartInUIThread.TabIndex = 0;
            this.buttonStartInUIThread.Text = "HardWork >UI-Thread";
            this.buttonStartInUIThread.UseVisualStyleBackColor = true;
            this.buttonStartInUIThread.Click += new System.EventHandler(this.buttonStartInUIThread_Click);
            // 
            // buttonBackgroundThrad
            // 
            this.buttonBackgroundThrad.Location = new System.Drawing.Point(534, 201);
            this.buttonBackgroundThrad.Name = "buttonBackgroundThrad";
            this.buttonBackgroundThrad.Size = new System.Drawing.Size(165, 43);
            this.buttonBackgroundThrad.TabIndex = 1;
            this.buttonBackgroundThrad.Text = "HardWork >Background";
            this.buttonBackgroundThrad.UseVisualStyleBackColor = true;
            this.buttonBackgroundThrad.Click += new System.EventHandler(this.buttonBackgroundThrad_Click);
            // 
            // labelFix
            // 
            this.labelFix.AutoSize = true;
            this.labelFix.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFix.Location = new System.Drawing.Point(89, 144);
            this.labelFix.Name = "labelFix";
            this.labelFix.Size = new System.Drawing.Size(102, 17);
            this.labelFix.TabIndex = 2;
            this.labelFix.Text = "MyMaxValue:";
            // 
            // textBoxInputValue
            // 
            this.textBoxInputValue.Location = new System.Drawing.Point(210, 139);
            this.textBoxInputValue.Name = "textBoxInputValue";
            this.textBoxInputValue.Size = new System.Drawing.Size(112, 22);
            this.textBoxInputValue.TabIndex = 3;
            // 
            // labelCurrentValue
            // 
            this.labelCurrentValue.AutoSize = true;
            this.labelCurrentValue.Location = new System.Drawing.Point(210, 226);
            this.labelCurrentValue.Name = "labelCurrentValue";
            this.labelCurrentValue.Size = new System.Drawing.Size(23, 17);
            this.labelCurrentValue.TabIndex = 4;
            this.labelCurrentValue.Text = "...";
            // 
            // labelOutputFix
            // 
            this.labelOutputFix.AutoSize = true;
            this.labelOutputFix.Location = new System.Drawing.Point(89, 226);
            this.labelOutputFix.Name = "labelOutputFix";
            this.labelOutputFix.Size = new System.Drawing.Size(62, 17);
            this.labelOutputFix.TabIndex = 5;
            this.labelOutputFix.Text = "Output:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 450);
            this.Controls.Add(this.labelOutputFix);
            this.Controls.Add(this.labelCurrentValue);
            this.Controls.Add(this.textBoxInputValue);
            this.Controls.Add(this.labelFix);
            this.Controls.Add(this.buttonBackgroundThrad);
            this.Controls.Add(this.buttonStartInUIThread);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartInUIThread;
        private System.Windows.Forms.Button buttonBackgroundThrad;
        private System.Windows.Forms.Label labelFix;
        private System.Windows.Forms.TextBox textBoxInputValue;
        private System.Windows.Forms.Label labelCurrentValue;
        private System.Windows.Forms.Label labelOutputFix;
    }
}

