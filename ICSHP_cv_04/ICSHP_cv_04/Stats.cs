using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICSHP_cv_04
{
    class Stats
    {
        public int Correct { get; private set; } = 0;
        public int Missed { get; private set; } = 0;
        public float Accuracy { get; private set; }

        public delegate void UpdateStatusEventHandler(object sender, EventArgs e);

        public event UpdateStatusEventHandler UpdatedStats;
        private void OnUpdatedStats()
        {
            UpdateStatusEventHandler handler = UpdatedStats;
            if (handler != null)
                handler(this, new EventArgs());
        }
        public void Update(bool correctKey)
        {
            if (correctKey)
                Correct++;
            else
                Missed++;

            Accuracy = ((float)Correct/((float)Correct + (float)Missed))*100;
            OnUpdatedStats();
        }
    }
}
