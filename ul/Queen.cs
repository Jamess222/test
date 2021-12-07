using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUL
{
    class Queen : Bee
    {
        public Queen(Worker[] workers, double weightMg):base(weightMg)
        {
            this.workers = workers;
        }
        private Worker[] workers;
        private int shiftNumber = 0;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for(int i=0; i<workers.Length; i++)
            if (workers[i].DoThisJob(job, numberOfShifts))
                return true;
            return false;
        }

        public string WorkTheNextShift()
        {
            double HoneyConsumed = HoneyConsumptionRate();
            shiftNumber++;
            string report = "Raport nr " + shiftNumber + "\r\n";
            for(int i=0; i<workers.Length; i++)
            {
                HoneyConsumed += workers[i].HoneyConsumptionRate();
                if (workers[i].DidYouFinish())
                    report += "Robotnica nr " + (i + 1) + " zakonczyla zadanie\r\n";
                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                    report += "Robotnica nr " + (i + 1) + " nie pracuje\r\n";
                else
                    if (workers[i].ShiftsLeft > 0)
                    report += "Robotnica numer " + (i + 1) + "robi '" + workers[i].CurrentJob + "' jeszcze przez " + workers[i].ShiftsLeft + "zmiany\r\n";
                else
                    report += "Robotnica nr "+(i + 1) + "zakonczy '" + workers[i].CurrentJob + "' po tej zmianie\r\n";
            }
            report += "Calkowite spozycie miodu: " + HoneyConsumed + "jednostek\r\n";
            return report;
        }

    }
}
