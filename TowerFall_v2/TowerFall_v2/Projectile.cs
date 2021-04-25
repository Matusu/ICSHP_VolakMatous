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
    class Projectile 
    {
        PictureBox ProjectileO = new PictureBox();

        public Projectile()
        {

        }
        public void Strelba(PictureBox Player, Form form, int x)
        {
            
            Point Size = new Point(20, 10);
            Point Location = new Point();
            if (x < Player.Left + 75)
            {
                Location.X = Player.Location.X - 20;
                Location.Y = Player.Location.Y + 25;
                ProjectileO.Tag = "Pravo";
            }
            else
            {
                Location.X = Player.Location.X + 50;
                Location.Y = Player.Location.Y + 25;
                ProjectileO.Tag = "Levo";
                
            }
            ProjectileO.Location = Location;
            ProjectileO.Size = (Size)Size;
            ProjectileO.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\ProjectileTexture.jpg");

            form.Controls.Add(ProjectileO);
        }
    }
}
