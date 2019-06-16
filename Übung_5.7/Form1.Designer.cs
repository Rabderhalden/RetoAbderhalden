namespace Übung_5._7
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
            this.labelFix = new System.Windows.Forms.Label();
            this.labelDinamic = new System.Windows.Forms.Label();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFix
            // 
            this.labelFix.AutoSize = true;
            this.labelFix.Location = new System.Drawing.Point(44, 63);
            this.labelFix.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelFix.Name = "labelFix";
            this.labelFix.Size = new System.Drawing.Size(77, 29);
            this.labelFix.TabIndex = 0;
            this.labelFix.Text = "Time:";
            // 
            // labelDinamic
            // 
            this.labelDinamic.AutoSize = true;
            this.labelDinamic.Location = new System.Drawing.Point(153, 63);
            this.labelDinamic.Name = "labelDinamic";
            this.labelDinamic.Size = new System.Drawing.Size(34, 29);
            this.labelDinamic.TabIndex = 1;
            this.labelDinamic.Text = "...";
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Location = new System.Drawing.Point(266, 57);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(182, 40);
            this.buttonStartStop.TabIndex = 2;
            this.buttonStartStop.Text = "Start / Stop";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 153);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.labelDinamic);
            this.Controls.Add(this.labelFix);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFix;
        private System.Windows.Forms.Label labelDinamic;
        private System.Windows.Forms.Button buttonStartStop;
    }
}

