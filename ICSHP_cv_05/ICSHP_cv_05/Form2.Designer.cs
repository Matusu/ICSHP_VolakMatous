
namespace ICSHP_cv_05
{
    partial class Form2
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
            this.JmenoLabel = new System.Windows.Forms.Label();
            this.KlubLabel = new System.Windows.Forms.Label();
            this.GolLabel = new System.Windows.Forms.Label();
            this.JmenoTextBox = new System.Windows.Forms.TextBox();
            this.GolTextBox = new System.Windows.Forms.TextBox();
            this.KlubComboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // JmenoLabel
            // 
            this.JmenoLabel.AutoSize = true;
            this.JmenoLabel.Location = new System.Drawing.Point(12, 9);
            this.JmenoLabel.Name = "JmenoLabel";
            this.JmenoLabel.Size = new System.Drawing.Size(42, 15);
            this.JmenoLabel.TabIndex = 0;
            this.JmenoLabel.Text = "Jmeno";
            // 
            // KlubLabel
            // 
            this.KlubLabel.AutoSize = true;
            this.KlubLabel.Location = new System.Drawing.Point(12, 61);
            this.KlubLabel.Name = "KlubLabel";
            this.KlubLabel.Size = new System.Drawing.Size(31, 15);
            this.KlubLabel.TabIndex = 1;
            this.KlubLabel.Text = "Klub";
            // 
            // GolLabel
            // 
            this.GolLabel.AutoSize = true;
            this.GolLabel.Location = new System.Drawing.Point(12, 114);
            this.GolLabel.Name = "GolLabel";
            this.GolLabel.Size = new System.Drawing.Size(25, 15);
            this.GolLabel.TabIndex = 2;
            this.GolLabel.Text = "Gol";
            // 
            // JmenoTextBox
            // 
            this.JmenoTextBox.Location = new System.Drawing.Point(70, 9);
            this.JmenoTextBox.Name = "JmenoTextBox";
            this.JmenoTextBox.Size = new System.Drawing.Size(105, 23);
            this.JmenoTextBox.TabIndex = 3;
            // 
            // GolTextBox
            // 
            this.GolTextBox.Location = new System.Drawing.Point(70, 111);
            this.GolTextBox.Name = "GolTextBox";
            this.GolTextBox.Size = new System.Drawing.Size(56, 23);
            this.GolTextBox.TabIndex = 4;
            // 
            // KlubComboBox
            // 
            this.KlubComboBox.FormattingEnabled = true;
            this.KlubComboBox.Location = new System.Drawing.Point(70, 61);
            this.KlubComboBox.Name = "KlubComboBox";
            this.KlubComboBox.Size = new System.Drawing.Size(123, 23);
            this.KlubComboBox.TabIndex = 5;
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(29, 180);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(135, 180);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 213);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.KlubComboBox);
            this.Controls.Add(this.GolTextBox);
            this.Controls.Add(this.JmenoTextBox);
            this.Controls.Add(this.GolLabel);
            this.Controls.Add(this.KlubLabel);
            this.Controls.Add(this.JmenoLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label JmenoLabel;
        private System.Windows.Forms.Label KlubLabel;
        private System.Windows.Forms.Label GolLabel;
        private System.Windows.Forms.TextBox JmenoTextBox;
        private System.Windows.Forms.TextBox GolTextBox;
        private System.Windows.Forms.ComboBox KlubComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}