using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace TowerFall_v2
{
    class NPC : Collision
    {
        public bool Smer { get; set; }
        public bool Chasing { get; set; }
        public int Health { get; set; } = 100;
        public NPC()
        {
            Smer = false;
        }

        public void PohybL(PictureBox box, Control.ControlCollection Controls)
        {
            if (CollisionRight(box, Controls) && !CollisionTop(box, Controls))
            {
                box.Left -= 1;
                box.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Enemy2.png");
            }
            else
                Smer = false;
        }
        public void PohybP(PictureBox box, Control.ControlCollection Controls)
        {
            if (CollisionLeft(box, Controls) && !CollisionTop(box, Controls))
            {
                box.Left += 1;
                box.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Enemy2L.png");
            }
            else
                Smer = true;
        }
        public void Kam(PictureBox box, PictureBox Player)
        {
            if (Player.Top <= box.Top)
            {
                if (Player.Left > box.Left)
                    Smer = false;
                else
                    Smer = true;
            }
        }
        public bool Chase(PictureBox box, PictureBox Player, Control.ControlCollection Controls, string npc)
        {
            Kam(box, Player);
            See(npc, Player, Controls);
            if (Chasing)
            {
                if (Smer)
                {
                    if (CollisionTop(box, Controls))
                        box.Top += 2;
                    PohybL(box, Controls);
                }

                else
                {
                    if (CollisionTop(box, Controls))
                        box.Top += 2;
                    PohybP(box, Controls);
                }
                return true;
            }
            else
                return false;



        }
        public void See(string npc, PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();

            foreach (PictureBox box in Controls)
            {
                if (box.Name == npc)
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X -100 , box.Location.Y-90, box.Width + 200, box.Height +90);
                    if (Player.Bounds.IntersectsWith(temp.Bounds) && !Chasing)
                        Chasing = true;
                }
            }
        }



    }

}
