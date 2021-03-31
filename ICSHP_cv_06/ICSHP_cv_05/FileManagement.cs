using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ICSHP_cv_05
{
    static class FileManagement
    {
        static List<string> lines;

        public static void Nacti(string fileName, LinkedList list)
        {
            string jmeno = "";
            string klub = "";
            string gol = "";
            int status = 0;
            lines = File.ReadAllLines(fileName).ToList();
            foreach (var line in lines)
            {
                jmeno = "";
                klub = "";
                gol = "";
                status = 0;
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ',' && status == 0)
                    {
                        jmeno += line[i];
                    }
                    else if(status == 0)
                    {
                        status++;
                        i++;
                    }
                    if (line[i] != ',' && status == 1)
                    {
                        klub += line[i];
                    }
                    else if(status == 1)
                    {
                        i++;
                        status++;
                    }
                    if (line[i] != '\n' && status == 2)
                    {
                        gol += line[i];
                    }
                }
                Hrac hracik = new Hrac()
                {
                    Jmeno = jmeno,
                    Klub = (Hrac.FotbalovyKlub)Enum.Parse(typeof(FotbalovyKlubInfo.FotbalovyKlub),klub),
                    GolPocet = Int32.Parse(gol)
                };
                list.Add(hracik);
            }
        }

        public static void Uloz(bool none, bool fc_porto, bool arsenal, bool real_madri, bool chelsea, bool barcelona, string fileName, LinkedList list)
        {
            List<string> lines = new List<string>();
            if(none)
            {
                Hrac hracik;
                foreach (LinkedList.PrvekSeznamu item in list)
                {
                    hracik = (Hrac)item.data;
                    if(hracik.Klub == Hrac.FotbalovyKlub.None)
                    {
                        lines.Add(hracik.ToString());
                    }
                }
            }
            if (fc_porto)
            {
                Hrac hracik;
                foreach (LinkedList.PrvekSeznamu item in list)
                {
                    hracik = (Hrac)item.data;
                    if (hracik.Klub == Hrac.FotbalovyKlub.FC_Porto)
                    {
                        lines.Add(hracik.ToString());
                    }
                }
            }
            if (arsenal)
            {
                Hrac hracik;
                foreach (LinkedList.PrvekSeznamu item in list)
                {
                    hracik = (Hrac)item.data;
                    if (hracik.Klub == Hrac.FotbalovyKlub.Arsenal)
                    {
                        lines.Add(hracik.ToString());
                    }
                }
            }
            if (real_madri)
            {
                Hrac hracik;
                foreach (LinkedList.PrvekSeznamu item in list)
                {
                    hracik = (Hrac)item.data;
                    if (hracik.Klub == Hrac.FotbalovyKlub.Real_Madrid)
                    {
                        lines.Add(hracik.ToString());
                    }
                }
            }
            if (chelsea)
            {
                Hrac hracik;
                foreach (LinkedList.PrvekSeznamu item in list)
                {
                    hracik = (Hrac)item.data;
                    if (hracik.Klub == Hrac.FotbalovyKlub.Chelsea)
                    {
                        lines.Add(hracik.ToString());
                    }
                }
            }
            if (barcelona)
            {
                Hrac hracik;
                foreach (LinkedList.PrvekSeznamu item in list)
                {
                    hracik = (Hrac)item.data;
                    if (hracik.Klub == Hrac.FotbalovyKlub.Barcelona)
                    {
                        lines.Add(hracik.ToString());
                    }
                }
            }
            File.WriteAllLines(fileName, lines);
        }
    }
}
