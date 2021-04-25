using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TowerFall_v2
{
    class Mapa
    {
        List<string> lines;
        public Mapa()
        {

        }
        public void Vykresli(Control.ControlCollection Controls, int lvl)
        {
            var path = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Mapa.txt");

            switch (lvl)
            {
                case 0:
                    lines = File.ReadAllLines(Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Mapa.txt")).ToList();
                    break;
                case 1:
                    lines = File.ReadAllLines(Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Mapa2.txt")).ToList();
                    break;
                case 2:
                    lines = File.ReadAllLines(Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Mapa3.txt")).ToList();
                    break;
            }
            
            int j = -1;
            int poradi = 0;

            foreach (string line in lines)
            {
                j++;
                for (int i = 0; i < line.Length; i++)
                {
                    switch (line[i])
                    {
                        case '#':
                            Point LokaceObj = new Point(i * 50, j * 50);
                            Point SizeObj = new Point(49, 49);
                            PictureBox PictureObj = new PictureBox();
                            PictureObj.Location = LokaceObj;
                            PictureObj.Size = (Size)SizeObj;
                            PictureObj.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\GroundTexture.jpg");
                            PictureObj.Tag = "obj";
                            Controls.Add(PictureObj);
                            break;
                        case 'x':
                            if (poradi < 10)
                            {
                                poradi++;
                                Point LokaceNpc = new Point(i * 50, j * 50);
                                Point SizeNpc = new Point(49, 49);
                                PictureBox PictureNpc = new PictureBox();
                                PictureNpc.Location = LokaceNpc;
                                PictureNpc.Size = (Size)SizeNpc;
                                PictureNpc.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Enemy2.png");
                                PictureNpc.Tag = "npc";
                                PictureNpc.Name = $"npc{poradi}";
                                Controls.Add(PictureNpc);
                                break;
                            }
                            else break;
                        case '/':
                            Point LokaceLock = new Point((i-1) * 50, j * 50);
                            Point SizeLock = new Point(99, 49);
                            PictureBox PictureLock = new PictureBox();
                            PictureLock.Location = LokaceLock;
                            PictureLock.Size = (Size)SizeLock;
                            PictureLock.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Door2.png");
                            PictureLock.Tag = "obj";
                            PictureLock.Name = "lock";
                            Controls.Add(PictureLock);
                            break;
                        case '+':
                            Point LokaceKey = new Point(i * 50 +10, j * 50+10);
                            Point SizeKey = new Point(30, 30);
                            PictureBox PictureKey = new PictureBox();
                            PictureKey.Location = LokaceKey;
                            PictureKey.Size = (Size)SizeKey;
                            PictureKey.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Key2.png");
                            PictureKey.Tag = "key";
                            PictureKey.Name = "key";
                            Controls.Add(PictureKey);
                            break;
                        case 'M':
                            Point LokaceMana = new Point(i * 50 + 10, j * 50 + 10);
                            Point SizeMana = new Point(30, 30);
                            PictureBox PictureMana = new PictureBox();
                            PictureMana.Location = LokaceMana;
                            PictureMana.Size = (Size)SizeMana;
                            PictureMana.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\ManaPotion2.png");
                            PictureMana.Tag = "mana";
                            PictureMana.Name = "mana";
                            Controls.Add(PictureMana);
                            break;
                        case 'H':
                            Point LokaceHealth = new Point(i * 50 + 10, j * 50 + 10);
                            Point SizeHealth = new Point(30, 30);
                            PictureBox PictureHealth = new PictureBox();
                            PictureHealth.Location = LokaceHealth;
                            PictureHealth.Size = (Size)SizeHealth;
                            PictureHealth.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\HealthPotion2.png");
                            PictureHealth.Tag = "health";
                            PictureHealth.Name = "health";
                            Controls.Add(PictureHealth);
                            break;
                        case '*':
                            Point LokaceNew = new Point(i * 50 , j * 50 );
                            Point SizeNew = new Point(49, 49);
                            PictureBox PictureNew = new PictureBox();
                            PictureNew.Location = LokaceNew;
                            PictureNew.Size = (Size)SizeNew;
                            PictureNew.ImageLocation = Path.GetFullPath(Directory.GetCurrentDirectory() + @"\Portal2.jpg");
                            PictureNew.Tag = "new";
                            PictureNew.Name = "new";
                            Controls.Add(PictureNew);
                            break;
                        case 'P':
                            foreach (PictureBox item in Controls)
                            {
                                if((string)item.Name == "Player")
                                {
                                    Point LokacePlayer = new Point(i * 50, j * 50);
                                    item.Location = LokacePlayer;
                                }
                            }
                            break;
                    }

                }
            }


        }


    }
}
