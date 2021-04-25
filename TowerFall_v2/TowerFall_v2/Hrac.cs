using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerFall_v2
{
    class Hrac
    {
        public int Health { get; set; }
        public int Mana { get; set; }
        public bool IsFalling{ get; set; }
        public bool Weapon { get; set; }
        public bool Key { get; set; } = false;
        public Hrac()
        {
            Health = 100;
            Mana = 100;
        }
    }
}
