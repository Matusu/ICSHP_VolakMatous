
namespace ICSHP_cv_05
{
    partial class Form4
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
            this.None_CB = new System.Windows.Forms.CheckBox();
            this.FC_Porto_CB = new System.Windows.Forms.CheckBox();
            this.Arsenal_CB = new System.Windows.Forms.CheckBox();
            this.Real_Madrid_CB = new System.Windows.Forms.CheckBox();
            this.Chelsea_CB = new System.Windows.Forms.CheckBox();
            this.Barcelona_CB = new System.Windows.Forms.CheckBox();
            this.Ok_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // None_CB
            // 
            this.None_CB.AutoSize = true;
            this.None_CB.Location = new System.Drawing.Point(12, 12);
            this.None_CB.Name = "None_CB";
            this.None_CB.Size = new System.Drawing.Size(55, 19);
            this.None_CB.TabIndex = 0;
            this.None_CB.Text = "None";
            this.None_CB.UseVisualStyleBackColor = true;
            // 
            // FC_Porto_CB
            // 
            this.FC_Porto_CB.AutoSize = true;
            this.FC_Porto_CB.Location = new System.Drawing.Point(12, 37);
            this.FC_Porto_CB.Name = "FC_Porto_CB";
            this.FC_Porto_CB.Size = new System.Drawing.Size(74, 19);
            this.FC_Porto_CB.TabIndex = 1;
            this.FC_Porto_CB.Text = "FC_Porto";
            this.FC_Porto_CB.UseVisualStyleBackColor = true;
            // 
            // Arsenal_CB
            // 
            this.Arsenal_CB.AutoSize = true;
            this.Arsenal_CB.Location = new System.Drawing.Point(12, 62);
            this.Arsenal_CB.Name = "Arsenal_CB";
            this.Arsenal_CB.Size = new System.Drawing.Size(65, 19);
            this.Arsenal_CB.TabIndex = 2;
            this.Arsenal_CB.Text = "Arsenal";
            this.Arsenal_CB.UseVisualStyleBackColor = true;
            // 
            // Real_Madrid_CB
            // 
            this.Real_Madrid_CB.AutoSize = true;
            this.Real_Madrid_CB.Location = new System.Drawing.Point(12, 87);
            this.Real_Madrid_CB.Name = "Real_Madrid_CB";
            this.Real_Madrid_CB.Size = new System.Drawing.Size(89, 19);
            this.Real_Madrid_CB.TabIndex = 3;
            this.Real_Madrid_CB.Text = "Real Madrid";
            this.Real_Madrid_CB.UseVisualStyleBackColor = true;
            // 
            // Chelsea_CB
            // 
            this.Chelsea_CB.AutoSize = true;
            this.Chelsea_CB.Location = new System.Drawing.Point(12, 112);
            this.Chelsea_CB.Name = "Chelsea_CB";
            this.Chelsea_CB.Size = new System.Drawing.Size(67, 19);
            this.Chelsea_CB.TabIndex = 4;
            this.Chelsea_CB.Text = "Chelsea";
            this.Chelsea_CB.UseVisualStyleBackColor = true;
            // 
            // Barcelona_CB
            // 
            this.Barcelona_CB.AutoSize = true;
            this.Barcelona_CB.Location = new System.Drawing.Point(12, 137);
            this.Barcelona_CB.Name = "Barcelona_CB";
            this.Barcelona_CB.Size = new System.Drawing.Size(78, 19);
            this.Barcelona_CB.TabIndex = 5;
            this.Barcelona_CB.Text = "Barcelona";
            this.Barcelona_CB.UseVisualStyleBackColor = true;
            // 
            // Ok_Button
            // 
            this.Ok_Button.Location = new System.Drawing.Point(15, 170);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(75, 23);
            this.Ok_Button.TabIndex = 6;
            this.Ok_Button.Text = "Ok";
            this.Ok_Button.UseVisualStyleBackColor = true;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 205);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Barcelona_CB);
            this.Controls.Add(this.Chelsea_CB);
            this.Controls.Add(this.Real_Madrid_CB);
            this.Controls.Add(this.Arsenal_CB);
            this.Controls.Add(this.FC_Porto_CB);
            this.Controls.Add(this.None_CB);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox None_CB;
        private System.Windows.Forms.CheckBox FC_Porto_CB;
        private System.Windows.Forms.CheckBox Arsenal_CB;
        private System.Windows.Forms.CheckBox Real_Madrid_CB;
        private System.Windows.Forms.CheckBox Chelsea_CB;
        private System.Windows.Forms.CheckBox Barcelona_CB;
        private System.Windows.Forms.Button Ok_Button;
    }
}