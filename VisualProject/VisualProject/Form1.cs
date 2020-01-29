using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualProject
{
    public partial class F1_Start : Form
    {
        public F1_Start()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            Form Save = new F2_Save();
            Save.Show();
            this.Hide();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            Form Load = new F3_Load();
            Load.Show();
            this.Hide();
        }
    }
}
