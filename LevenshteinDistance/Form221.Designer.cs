namespace LevenshteinDistance
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
            this.firstStringTextBox = new System.Windows.Forms.TextBox();
            this.secondStringTextBox = new System.Windows.Forms.TextBox();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.operationsListBox = new System.Windows.Forms.ListBox();
            this.distanceLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // firstStringTextBox
            // 
            this.firstStringTextBox.Location = new System.Drawing.Point(229, 50);
            this.firstStringTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.firstStringTextBox.Name = "firstStringTextBox";
            this.firstStringTextBox.Size = new System.Drawing.Size(154, 20);
            this.firstStringTextBox.TabIndex = 0;
            // 
            // secondStringTextBox
            // 
            this.secondStringTextBox.Location = new System.Drawing.Point(256, 315);
            this.secondStringTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.secondStringTextBox.Name = "secondStringTextBox";
            this.secondStringTextBox.Size = new System.Drawing.Size(154, 20);
            this.secondStringTextBox.TabIndex = 1;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(210, 248);
            this.CalculateButton.Margin = new System.Windows.Forms.Padding(2);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(200, 63);
            this.CalculateButton.TabIndex = 2;
            this.CalculateButton.Text = "Calculate";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // operationsListBox
            // 
            this.operationsListBox.FormattingEnabled = true;
            this.operationsListBox.Location = new System.Drawing.Point(2, 1);
            this.operationsListBox.Name = "operationsListBox";
            this.operationsListBox.Size = new System.Drawing.Size(182, 95);
            this.operationsListBox.TabIndex = 0;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Location = new System.Drawing.Point(253, 349);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(173, 13);
            this.distanceLabel.TabIndex = 4;
            this.distanceLabel.Text = "There will be a distance calculation";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Location = new System.Drawing.Point(474, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 95);
            this.panel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.operationsListBox);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.secondStringTextBox);
            this.Controls.Add(this.firstStringTextBox);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(500, 400);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstStringTextBox;
        private System.Windows.Forms.TextBox secondStringTextBox;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.ListBox operationsListBox;
        private System.Windows.Forms.Label distanceLabel;
        private System.Windows.Forms.Panel panel1;
    }
}