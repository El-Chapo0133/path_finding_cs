using path_finding_cs.mapSetter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace path_finding_cs
{
    public partial class MainForm : Form
    {
        public MapSetter mapSetter;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            mapSetter.resetMap();
        }
    }
}
