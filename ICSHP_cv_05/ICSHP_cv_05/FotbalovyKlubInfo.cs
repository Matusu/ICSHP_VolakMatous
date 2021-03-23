using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_05
{
    static class FotbalovyKlubInfo
    {
        enum FotbalovyKlub
        {
            None,
            FC_Porto,
            Arsenal,
            Real_Madrid,
            Chelsea,
            Barcelona
        }
        public static int Pocet{ get; } = Enum.GetNames(typeof(FotbalovyKlub)).Length;

        public static string DejNazev(int konstanta)
        {
            string s = Convert.ToString((FotbalovyKlub)konstanta);
            return s;
        }
    }
}
