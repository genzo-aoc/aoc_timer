using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace timer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        bool stopRequest = false;
        private void buttonStart_Click(object sender, EventArgs e) {
            stopRequest = false;
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = true;
            Task.Factory.StartNew(() => {
                while (!stopRequest) {
                    Thread.Sleep((int)(12500.0 / 1.5));
                    if (stopRequest) {
                        return;
                    }
                    System.Media.SystemSounds.Hand.Play();
                    Thread.Sleep((int)(12500.0 / 1.5));
                    if (stopRequest) {
                        return;
                    }
                    System.Media.SystemSounds.Beep.Play();
                }

            });
        }

        private void buttonStop_Click(object sender, EventArgs e) {
            stopRequest = false;
            this.buttonStart.Enabled = true;
            this.buttonStop.Enabled = false;
        }
    }
}
