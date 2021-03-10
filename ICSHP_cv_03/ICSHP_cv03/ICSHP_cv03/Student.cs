using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv03
{
    enum FakultaEnum
    {
        FES,
        FF,
        FEI,
        FCHT
    }
    class Student
    {
        public string Jmeno { get; set; }
        public int Cislo { get; set; }
        public FakultaEnum Fakulta { get; set; }

        public Student()
        {

        }
        public override string ToString()
        {
            return $"{Jmeno}, {Cislo}, {Fakulta}";
        }
    }
}
