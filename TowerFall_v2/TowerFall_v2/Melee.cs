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
    class Melee
    {
        PictureBox Weapon = new PictureBox();

        public Melee()
        {

        }

        public void Utok(PictureBox Player, Form1 form, int x)
        {
            Point Size = new Point(30, 60);
            Point Location = new Point();
            if (x < Player.Left)
            {
                Location.X = Player.Location.X - 30;
                Location.Y = Player.Location.Y - 25;
            }
            else
            {
                Location.X = Player.Location.X + 50;
                Location.Y = Player.Location.Y - 25;

            }
            Weapon.Tag = "Weapon";
            Weapon.Location = Location;
            Weapon.Size = (Size)Size;
            Weapon.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Sword2.jpg");

            form.Controls.Add(Weapon);
        }
    }
}
