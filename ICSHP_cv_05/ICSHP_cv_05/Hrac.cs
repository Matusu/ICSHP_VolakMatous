using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_05
{
    class Hrac
    {
        public enum FotbalovyKlub
        {
            None,
            FC_Porto,
            Arsenal,
            Real_Madrid,
            Chelsea,
            Barcelona
        }
        public string Jmeno { get; set; }
        public FotbalovyKlub Klub { get; set; }
        public int GolPocet { get; set; }

        public override string ToString()
        {
            return $"{Jmeno} {FotbalovyKlubInfo.DejNazev((int)Klub)} {GolPocet}";
        }
    }
}
