
namespace TowerFall_v2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Jumping = new System.Windows.Forms.Timer(this.components);
            this.NPCTmr = new System.Windows.Forms.Timer(this.components);
            this.ProjectileTmr = new System.Windows.Forms.Timer(this.components);
            this.AtckTmr = new System.Windows.Forms.Timer(this.components);
            this.HealthBack = new System.Windows.Forms.PictureBox();
            this.ManaBack = new System.Windows.Forms.PictureBox();
            this.AtckTmrNPC = new System.Windows.Forms.Timer(this.components);
            this.Invent = new System.Windows.Forms.PictureBox();
            this.InventProjectile = new System.Windows.Forms.PictureBox();
            this.InventMelee = new System.Windows.Forms.PictureBox();
            this.InventKey = new System.Windows.Forms.PictureBox();
            this.Mana = new System.Windows.Forms.PictureBox();
            this.Health = new System.Windows.Forms.PictureBox();
            this.Player = new System.Windows.Forms.PictureBox();
            this.Start = new System.Windows.Forms.Timer(this.components);
            this.GoLeftAnimation = new System.Windows.Forms.Timer(this.components);
            this.GoRightAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HealthBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManaBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Invent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventProjectile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventMelee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mana)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // Jumping
            // 
            this.Jumping.Interval = 10;
            this.Jumping.Tick += new System.EventHandler(this.Jumping_Tick);
            // 
            // NPCTmr
            // 
            this.NPCTmr.Enabled = true;
            this.NPCTmr.Interval = 10;
            this.NPCTmr.Tick += new System.EventHandler(this.NPCTmr_Tick);
            // 
            // ProjectileTmr
            // 
            this.ProjectileTmr.Enabled = true;
            this.ProjectileTmr.Interval = 10;
            this.ProjectileTmr.Tick += new System.EventHandler(this.ProjectileTmr_Tick);
            // 
            // AtckTmr
            // 
            this.AtckTmr.Interval = 10;
            this.AtckTmr.Tick += new System.EventHandler(this.AtckTmr_Tick);
            // 
            // HealthBack
            // 
            this.HealthBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.HealthBack.Location = new System.Drawing.Point(12, 12);
            this.HealthBack.Name = "HealthBack";
            this.HealthBack.Size = new System.Drawing.Size(100, 30);
            this.HealthBack.TabIndex = 1;
            this.HealthBack.TabStop = false;
            this.HealthBack.Tag = "UI";
            // 
            // ManaBack
            // 
            this.ManaBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ManaBack.Location = new System.Drawing.Point(12, 43);
            this.ManaBack.Name = "ManaBack";
            this.ManaBack.Size = new System.Drawing.Size(100, 30);
            this.ManaBack.TabIndex = 2;
            this.ManaBack.TabStop = false;
            this.ManaBack.Tag = "UI";
            // 
            // AtckTmrNPC
            // 
            this.AtckTmrNPC.Interval = 10;
            this.AtckTmrNPC.Tick += new System.EventHandler(this.AtckTmrNPC_Tick);
            // 
            // Invent
            // 
            this.Invent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Invent.Location = new System.Drawing.Point(383, 375);
            this.Invent.Name = "Invent";
            this.Invent.Size = new System.Drawing.Size(100, 84);
            this.Invent.TabIndex = 3;
            this.Invent.TabStop = false;
            this.Invent.Tag = "UI";
            // 
            // InventProjectile
            // 
            this.InventProjectile.BackColor = System.Drawing.Color.Green;
            this.InventProjectile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InventProjectile.BackgroundImage")));
            this.InventProjectile.Location = new System.Drawing.Point(452, 419);
            this.InventProjectile.Name = "InventProjectile";
            this.InventProjectile.Size = new System.Drawing.Size(20, 10);
            this.InventProjectile.TabIndex = 8;
            this.InventProjectile.TabStop = false;
            this.InventProjectile.Tag = "UI";
            // 
            // InventMelee
            // 
            this.InventMelee.BackColor = System.Drawing.Color.Green;
            this.InventMelee.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InventMelee.BackgroundImage")));
            this.InventMelee.Location = new System.Drawing.Point(442, 389);
            this.InventMelee.Name = "InventMelee";
            this.InventMelee.Size = new System.Drawing.Size(30, 60);
            this.InventMelee.TabIndex = 7;
            this.InventMelee.TabStop = false;
            this.InventMelee.Tag = "UI";
            // 
            // InventKey
            // 
            this.InventKey.BackColor = System.Drawing.Color.Yellow;
            this.InventKey.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("InventKey.BackgroundImage")));
            this.InventKey.Location = new System.Drawing.Point(401, 429);
            this.InventKey.Name = "InventKey";
            this.InventKey.Size = new System.Drawing.Size(24, 20);
            this.InventKey.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.InventKey.TabIndex = 6;
            this.InventKey.TabStop = false;
            this.InventKey.Tag = "UI";
            // 
            // Mana
            // 
            this.Mana.BackColor = System.Drawing.Color.Blue;
            this.Mana.Location = new System.Drawing.Point(12, 43);
            this.Mana.Name = "Mana";
            this.Mana.Size = new System.Drawing.Size(100, 30);
            this.Mana.TabIndex = 9;
            this.Mana.TabStop = false;
            this.Mana.Tag = "UI";
            // 
            // Health
            // 
            this.Health.BackColor = System.Drawing.Color.Red;
            this.Health.Location = new System.Drawing.Point(12, 12);
            this.Health.Name = "Health";
            this.Health.Size = new System.Drawing.Size(100, 30);
            this.Health.TabIndex = 10;
            this.Health.TabStop = false;
            this.Health.Tag = "UI";
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Player.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Player.BackgroundImage")));
            this.Player.InitialImage = null;
            this.Player.Location = new System.Drawing.Point(323, 72);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(50, 50);
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            this.Player.Tag = "UI";
            this.Player.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            // 
            // Start
            // 
            this.Start.Enabled = true;
            this.Start.Interval = 10;
            this.Start.Tick += new System.EventHandler(this.Start_Tick);
            // 
            // GoLeftAnimation
            // 
            this.GoLeftAnimation.Enabled = true;
            this.GoLeftAnimation.Interval = 50;
            this.GoLeftAnimation.Tick += new System.EventHandler(this.GoLeftAnimation_Tick);
            // 
            // GoRightAnimation
            // 
            this.GoRightAnimation.Enabled = true;
            this.GoRightAnimation.Interval = 50;
            this.GoRightAnimation.Tick += new System.EventHandler(this.GoRightAnimation_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.Health);
            this.Controls.Add(this.Mana);
            this.Controls.Add(this.InventProjectile);
            this.Controls.Add(this.InventMelee);
            this.Controls.Add(this.InventKey);
            this.Controls.Add(this.Invent);
            this.Controls.Add(this.ManaBack);
            this.Controls.Add(this.HealthBack);
            this.Controls.Add(this.Player);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.HealthBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ManaBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Invent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventProjectile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventMelee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InventKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mana)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Health)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer Jumping;
        private System.Windows.Forms.Timer NPCTmr;
        private System.Windows.Forms.Timer ProjectileTmr;
        private System.Windows.Forms.Timer AtckTmr;
        private System.Windows.Forms.PictureBox HealthBack;
        private System.Windows.Forms.PictureBox ManaBack;
        private System.Windows.Forms.Timer AtckTmrNPC;
        private System.Windows.Forms.PictureBox Invent;
        private System.Windows.Forms.PictureBox InventProjectile;
        private System.Windows.Forms.PictureBox InventMelee;
        private System.Windows.Forms.PictureBox InventKey;
        private System.Windows.Forms.PictureBox Mana;
        private System.Windows.Forms.PictureBox Health;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer Start;
        private System.Windows.Forms.Timer GoLeftAnimation;
        private System.Windows.Forms.Timer GoRightAnimation;
    }
}

