using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class WaveEditor : Form
    {
        Menu menu = new Menu();

        public WaveEditor(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
        }
    }
}
