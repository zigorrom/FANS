using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FANS;
using FANS.classes;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MotorizedVoltageApplier ma = new MotorizedVoltageApplier(1, 1, 2, 0.001);
            ma.SetVoltage(2);
            
        }
    }
}
