using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class Pomodoro : Form
    {
        int seconds;
        public Pomodoro()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            seconds = Convert.ToInt32(numericUpDown1.Value * 60);
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds--);

            string answer = string.Format("{0:D2}h : {1:D2}m : {2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);
            CountdownLabel.Text = answer.ToString();
            if(seconds < 0)
            {
                timer.Stop();
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
                seconds = Convert.ToInt32(numericUpDown2.Value * 60);
                timer2.Start();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            seconds = 0;
            numericUpDown1.Value = 0;
            CountdownLabel.Text = "00:00:00";
            timer.Stop();
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;

            TimeSpan t = TimeSpan.FromSeconds(seconds--);

            string answer = string.Format("{0:D2}h : {1:D2}m : {2:D2}s",
                            t.Hours,
                            t.Minutes,
                            t.Seconds);

            CountdownLabel.Text = answer.ToString();
            if (seconds < 0)
            {
                timer2.Stop();
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
        }
    }
}
