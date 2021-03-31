using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_05
{
    static class FotbalovyKlubInfo
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
        public static int Pocet{ get; } = Enum.GetNames(typeof(FotbalovyKlub)).Length;

        public static string DejNazev(int konstanta)
        {
            string s = Convert.ToString((FotbalovyKlub)konstanta);
            return s;
        }
        public static string GetName(FotbalovyKlubInfo.FotbalovyKlub klub)
        {
            int i = (int)klub;
            switch (i)
            {
                case 0:
                    return "None";
                case 1:
                    return "FC_Porto";
                case 2:
                    return "Arsenal";
                case 3:
                    return "Real_Madrid";
                case 4:
                    return "Chelsea";
                case 5:
                    return "Barcelona";
                default:
                    return "";
            }
        }
    }
}
