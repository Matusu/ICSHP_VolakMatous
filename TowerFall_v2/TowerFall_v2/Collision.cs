using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace TowerFall_v2
{
    class Collision
    {
        public Collision()
        {

        }
        public bool CollisionTop(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Tag;
                if (tag == "obj")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X+2, box.Location.Y - 1, box.Width - 3, 1);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }
            }
            return true;
        }
        public bool CollisionLeft(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Tag;
                if (tag == "obj")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X - 1, box.Location.Y + 4, 1, box.Height - 3);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }
            }
            return true;
        }
        public bool CollisionRight(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Tag;
                if (tag == "obj")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X + temp.Width, box.Location.Y + 4, 1, box.Height - 3);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }

            }
            return true;
        }
        public bool CollisionBot(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Tag;
                if (tag == "obj")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X + 2, box.Location.Y + box.Height, box.Width - 3, 1);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }

            }
            return true;
        }

        public bool CollisionTopLock(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Name;
                if (tag == "lock")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X + 2, box.Location.Y - 1, box.Width - 3, 1);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }
            }
            return true;
        }
        public bool CollisionLeftLock(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Name;
                if (tag == "lock")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X - 1, box.Location.Y + 4, 1, box.Height - 3);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }
            }
            return true;
        }
        public bool CollisionRightLock(PictureBox Player, Control.ControlCollection Controls)
        {
            PictureBox temp = new PictureBox();
            foreach (PictureBox box in Controls)
            {
                string tag = (string)box.Name;
                if (tag == "lock")
                {
                    temp.Bounds = box.Bounds;
                    temp.SetBounds(box.Location.X + temp.Width, box.Location.Y + 4, 1, box.Height - 3);
                    if (Player.Bounds.IntersectsWith(temp.Bounds))
                        return false;
                }

            }
            return true;
        }
    }
}
