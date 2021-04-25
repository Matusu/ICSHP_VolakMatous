using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TowerFall_v2
{
    public partial class Form1 : Form
    {
        bool Up, Right, Left, SideJumpR, SideJumpL;
        bool jump = false;
        bool zasah = false;
        bool Zbran = false;
        bool Left1_2 = false;
        bool Right1_2 = false;
        int PlayerSpeed = 2;
        int i = 0;
        int Atck = 0;
        int AtckNPC = 0;
        int CurentLvl = 0;
        Collision collision = new Collision();
        Mapa mapa = new Mapa();
        Hrac hrac = new Hrac();

        NPC npc1 = new NPC();
        NPC npc2 = new NPC();
        NPC npc3 = new NPC();
        NPC npc4 = new NPC();
        NPC npc5 = new NPC();
        NPC npc6 = new NPC();
        NPC npc7 = new NPC();
        NPC npc8 = new NPC();
        NPC npc9 = new NPC();
        NPC npc10 = new NPC();

        // ošetřit okraje
        private delegate void PicktureBoxFce(PictureBox picture, Form1 form);

        Timer MainTmr = new Timer();


        public Form1()
        {
            InitializeComponent();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            mapa.Vykresli(Controls, CurentLvl);
            foreach (PictureBox item in Controls)
            {
                item.MouseDown += Form1_MouseDown;
            }
            MainTmr.Tick += new EventHandler(MainTmr_Tick);
            MainTmr.Interval = 10;
        }

        private void Start_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 200)
            {
                foreach (PictureBox box in Controls)
                {
                    if ((string)box.Tag == "obj" || (string)box.Tag == "npc" || (string)box.Tag == "key" || (string)box.Tag == "mana" || (string)box.Tag == "health" || (string)box.Tag == "new" || (string)box.Name == "Player")
                        box.Top -= 2;
                }
            }
            else
            {
                Start.Stop();
                Spust();
            }
        }

        private void Spust()
        {

            MainTmr.Start();
        }

        private void MainTmr_Tick(object sender, EventArgs e)
        {
            if (!Left && !Right && !Up)
                Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Standing.jpg");
            if(hrac.IsFalling)
                Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Jumping.jpg");

            if (hrac.Health > 0)
            {
                // invent klíč
                if (hrac.Key)
                    InventKey.Visible = true;
                else
                    InventKey.Visible = false;
                // invent zbraň
                if (Zbran)
                {
                    InventProjectile.Visible = true;
                    InventMelee.Visible = false;
                    // ranged
                }
                else
                {
                    InventProjectile.Visible = false;
                    InventMelee.Visible = true;
                    // melee
                }
                // životy
                Point SizeH = new Point(hrac.Health, 30);
                Health.Size = (Size)SizeH;
                // mana
                Point SizeM = new Point(hrac.Mana, 30);
                Mana.Size = (Size)SizeM;
                // když nejsem na zemi tak padej
                if (!collision.CollisionTop(Player, Controls))
                    hrac.IsFalling = false;
                // sidejump pokud není nic nad tebou
                if (!collision.CollisionTop(Player, Controls))
                {
                    SideJumpL = true;
                    SideJumpR = true;
                }
                // skok
                if (Up && !collision.CollisionTop(Player, Controls))
                {
                    Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Jumping.jpg");
                    Jumperino();
                }
                // pád když není na správné pozici na obrazovce
                if (!jump && collision.CollisionTop(Player, Controls))
                {
                    hrac.IsFalling = true;
                    if (Player.Top < 200)
                    {
                        Player.Top += 2;
                    }
                    else
                    {
                        Projdi(PadHraceDelegate);
                    }


                }
                // Jdi doleva
                if (Left && collision.CollisionRight(Player, Controls))
                {
                    Player.Left -= PlayerSpeed;
                }
                // Jdi doprava
                if (Right && collision.CollisionLeft(Player, Controls))
                {
                    Player.Left += PlayerSpeed;
                }
                // sidejump doleva
                if (Left && Up && !collision.CollisionRight(Player, Controls) && SideJumpL)
                {
                    SideJumpL = false;
                    Jumperino();
                }
                // sidejump doprava
                if (Right && Up && !collision.CollisionLeft(Player, Controls) && SideJumpR)
                {
                    SideJumpR = false;
                    Jumperino();
                }
                Projdi(OpenDoorDelegate);
                Projdi(TakeKeyDelegate);
                Projdi(ManaPotionDelegate);
                Projdi(HealthPotionDelegate);
                Projdi(NPCHitDelegate);
                // new lvl
                Projdi(NewLvlDelegate);

            }
            else
                Application.Exit();

        }

        private void NPCTmr_Tick(object sender, EventArgs e)
        {
            if (npc1 != null)
                NPC("npc1", npc1);
            if (npc2 != null)
                NPC("npc2", npc2);
            if (npc3 != null)
                NPC("npc3", npc3);
            if (npc4 != null)
                NPC("npc4", npc4);
            if (npc5 != null)
                NPC("npc5", npc5);
            if (npc6 != null)
                NPC("npc6", npc6);
            if (npc7 != null)
                NPC("npc7", npc7);
            if (npc8 != null)
                NPC("npc8", npc8);
            if (npc9 != null)
                NPC("npc9", npc9);
            if (npc10 != null)
                NPC("npc10", npc10);
        }

        private void Jumping_Tick(object sender, EventArgs e)
        {

            if (jump && i < 20)
            {
                if (collision.CollisionBot(Player, Controls))
                {
                    {
                        foreach (PictureBox box in Controls)
                        {
                            if ((string)box.Tag == "obj" || (string)box.Tag == "npc" || (string)box.Tag == "key" || (string)box.Tag == "mana" || (string)box.Tag == "health" || (string)box.Tag == "new" || (string)box.Tag == "trans")
                                box.Top += 4;
                        }
                    }
                    i++;
                }
                else if (!collision.CollisionBot(Player, Controls))
                {
                    i = 0;
                    jump = false;
                }
            }
            else
            {
                i = 0;
                jump = false;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (Zbran)
                {
                    if (hrac.Mana > 0)
                    {
                        Projectile projectile = new Projectile();
                        projectile.Strelba(Player, this, e.X);
                        hrac.Mana -= 20;
                    }

                }
                else
                {
                    if (!AtckTmr.Enabled)
                    {
                        Melee weapon = new Melee();
                        weapon.Utok(Player, this, e.X);
                        Atck = 0;
                        AtckTmr.Start();
                    }
                }
            }

        }

        private void ProjectileTmr_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox pro in Controls)
            {
                if ((string)pro.Tag == "Pravo")
                {
                    foreach (PictureBox box in Controls)
                    {
                        if ((string)box.Tag == "npc" && pro.Bounds.IntersectsWith(box.Bounds))
                        {
                            Zasah(box);
                            Controls.Remove(pro);
                        }

                    }
                    if (pro.Left > 0)
                        pro.Left -= 10;
                    else
                        Controls.Remove(pro);
                }

                if ((string)pro.Tag == "Levo")
                {
                    foreach (PictureBox box in Controls)
                    {
                        if ((string)box.Tag == "npc" && pro.Bounds.IntersectsWith(box.Bounds))
                        {
                            Zasah(box);
                            Controls.Remove(pro);
                        }

                    }
                    if (pro.Left < 550)
                        pro.Left += 10;
                    else
                        Controls.Remove(pro);
                }


            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Up = true;
                    break;
                case Keys.Down:
                    break;
                case Keys.Left:
                    Left = true;
                    break;
                case Keys.Right:
                    Right = true;
                    break;
            }
        }

        private void AtckTmr_Tick(object sender, EventArgs e)
        {
            Atck++;
            if (!(Atck < 30))
            {
                foreach (PictureBox weapon in Controls)
                {
                    if ((string)weapon.Tag == "Weapon")
                    {
                        Controls.Remove(weapon);
                        zasah = false;
                        AtckTmr.Stop();
                    }

                }
            }
            else
            {

                if (Left && collision.CollisionRight(Player, Controls))
                {
                    foreach (PictureBox weapon in Controls)
                    {
                        if ((string)weapon.Tag == "Weapon")
                        {
                            weapon.Left -= PlayerSpeed;
                        }

                    }
                }
                if (Right && collision.CollisionLeft(Player, Controls))
                {
                    foreach (PictureBox weapon in Controls)
                    {
                        if ((string)weapon.Tag == "Weapon")
                        {
                            weapon.Left += PlayerSpeed;
                        }

                    }
                }
            }
            foreach (PictureBox weapon in Controls)
            {
                if ((string)weapon.Tag == "Weapon" && !zasah)
                    foreach (PictureBox npc in Controls)
                    {
                        if ((string)npc.Tag == "npc" && weapon.Bounds.IntersectsWith(npc.Bounds))
                        {
                            Zasah(npc);
                            zasah = true;
                        }

                    }
            }

        }

        private void AtckTmrNPC_Tick(object sender, EventArgs e)
        {
            AtckNPC++;
            if (!(AtckNPC < 50))
                AtckTmrNPC.Stop();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Up = false;
                    break;
                case Keys.Down:
                    break;
                case Keys.Left:
                    Left = false;
                    break;
                case Keys.Right:
                    Right = false;
                    break;
                case Keys.M:
                    if (Zbran)
                        Zbran = false;
                    else
                        Zbran = true;
                    break;

            }
        }

        private void Jumperino()
        {
            i = 0;
            jump = true;
            Jumping.Start();
        }

        private void NPC(string npc, NPC Npc)
        {
            foreach (PictureBox box in Controls)
            {
                // když je hráč v dosahu chase
                if (box.Name == npc && box.Top - 90 <= Player.Top)
                {
                    if (box.Name == npc)
                        Npc.Chase(box, Player, Controls, npc);
                }
                // jinak dopadni na zem
                else if (box.Name == npc && collision.CollisionTop(box, Controls))
                    box.Top += 2;
            }
        }
        private void Zasah(PictureBox picture)
        {
            switch (picture.Name)
            {
                case "npc1":
                    npc1.Health -= 25;
                    if (npc1.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc2":
                    npc2.Health -= 25;
                    if (npc2.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc3":
                    npc3.Health -= 25;
                    if (npc3.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc4":
                    npc4.Health -= 25;
                    if (npc4.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc5":
                    npc5.Health -= 25;
                    if (npc5.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc6":
                    npc6.Health -= 25;
                    if (npc6.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc7":
                    npc7.Health -= 25;
                    if (npc7.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc8":
                    npc8.Health -= 25;
                    if (npc8.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc9":
                    npc9.Health -= 25;
                    if (npc9.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
                case "npc10":
                    npc10.Health -= 25;
                    if (npc10.Health <= 0)
                    {
                        Controls.Remove(picture);
                    }
                    break;
            }
        }



        private void Projdi(PicktureBoxFce funkce)
        {
            foreach (PictureBox picture in Controls)
            {
                funkce(picture, this);
            }
        }
        static private void NPCHit(PictureBox item, Form1 form)
        {
            if (form.Player.Bounds.IntersectsWith(item.Bounds) && (string)item.Tag == "npc")
            {
                if (!form.AtckTmrNPC.Enabled)
                {
                    form.hrac.Health -= 10;
                    form.AtckNPC = 0;
                    form.AtckTmrNPC.Start();
                }
            }
        }
        static private void HealthPotion(PictureBox item, Form1 form)
        {
            if (form.Player.Bounds.IntersectsWith(item.Bounds) && (string)item.Tag == "health")
            {
                int health = form.hrac.Health;
                int healthtotal = health + 50;
                int healthplus;
                if (healthtotal > 100)
                {
                    healthplus = 50 - (healthtotal - 100);
                }
                else
                {
                    healthplus = 50;
                }
                form.hrac.Health += healthplus;
                form.Controls.Remove(item);
            }
        }
        static private void ManaPotion(PictureBox item, Form1 form)
        {
            if (form.Player.Bounds.IntersectsWith(item.Bounds) && (string)item.Tag == "mana")
            {
                int mana = form.hrac.Mana;
                int manatotal = mana + 50;
                int manaplus;
                if (manatotal > 100)
                {
                    manaplus = 50 - (manatotal - 100);
                }
                else
                {
                    manaplus = 50;
                }
                form.hrac.Mana += manaplus;
                form.Controls.Remove(item);
            }
        }
        static private void TakeKey(PictureBox item, Form1 form)
        {
            if (form.Player.Bounds.IntersectsWith(item.Bounds) && (string)item.Tag == "key")
            {
                form.hrac.Key = true;
                form.Controls.Remove(item);
            }
        }
        static private void OpenDoor(PictureBox item, Form1 form)
        {
            if (!form.collision.CollisionLeftLock(form.Player, form.Controls) || !form.collision.CollisionTopLock(form.Player, form.Controls) || !form.collision.CollisionRightLock(form.Player, form.Controls))
            {
                if (form.hrac.Key && (string)item.Name == "lock")
                {
                    form.Controls.Remove(item);
                    form.hrac.Key = false;
                }
            }
        }
        static private void PadHrace(PictureBox box, Form1 form)
        {
            if ((string)box.Tag == "obj" || (string)box.Tag == "npc" || (string)box.Tag == "key" || (string)box.Tag == "mana" || (string)box.Tag == "health" || (string)box.Tag == "new" || (string)box.Tag == "trans")
            {
                box.Top -= 2;
            }
        }

        // new lvl 
        static private void NewLvl(PictureBox box, Form1 form)
        {
            if (box.Bounds.IntersectsWith(form.Player.Bounds) && (string)box.Tag == "new")
            {
                form.MainTmr.Stop();
                form.CurentLvl++;
                // ?? 
                for (int i = 0; i < 7; i++)
                {
                    foreach (PictureBox item in form.Controls)
                    {
                        if ((string)item.Tag != "UI")
                            form.Controls.Remove(item);
                    }
                }


                form.mapa.Vykresli(form.Controls, form.CurentLvl);
                form.Start.Start();
            }
        }

        private void GoLeftAnimation_Tick(object sender, EventArgs e)
        {
            if (Left && Left1_2 && !hrac.IsFalling)
            {
                Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\WalkingL1.jpg");
                Left1_2 = false;
            }
            else if (Left && !Left1_2 && !hrac.IsFalling)
            {
                Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\WalkingL2.jpg");
                Left1_2 = true;
            }
        }

        private void GoRightAnimation_Tick(object sender, EventArgs e)
        {
            if (Right && Right1_2 && !hrac.IsFalling)
            {
                Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Walking1.jpg");
                Right1_2 = false;
            }
            else if (Right && !Right1_2 && !hrac.IsFalling)
            {
                Player.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Walking2.jpg");
                Right1_2 = true;
            }
        }

        PicktureBoxFce NewLvlDelegate = NewLvl;
        PicktureBoxFce PadHraceDelegate = PadHrace;
        PicktureBoxFce OpenDoorDelegate = OpenDoor;
        PicktureBoxFce TakeKeyDelegate = TakeKey;
        PicktureBoxFce ManaPotionDelegate = ManaPotion;
        PicktureBoxFce HealthPotionDelegate = HealthPotion;
        PicktureBoxFce NPCHitDelegate = NPCHit;
    }
}
