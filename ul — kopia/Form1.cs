using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemUL
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" }, 175);
            workers[1] = new Worker(new string[] { "Pielegnacja", "Nauczanie pszczolek" },114);
            workers[2] = new Worker(new string[] { "Utrzymanie", "Patrol" },149);
            workers[3] = new Worker(new string[] { "Zbieranie nektaru", "Wytwarzanie", "Pielegnacja", "nauczanie", "utrzymywanie", "patrol" }, 155);

            queen = new Queen(workers, 275);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Queen queen;
        private void button1_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)
            {
                MessageBox.Show("Nie ma dostepnych robotnic do zadan'" + workerBeeJob.Text + "'", "Krolowa mowi..");
            }
            else
            {
                MessageBox.Show("Zadanie '" + workerBeeJob.Text + "' bedzie ukonczone za" + shifts.Value + " zmiany", "Krolowa mowi...");
            }
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
