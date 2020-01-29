using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualProject
{
    public partial class F3_Load : Form
    {
        public F3_Load()
        {
            InitializeComponent();
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStr = null;
            OpenFileDialog OpenTags = new OpenFileDialog();
            OpenTags.Filter = "All file (*.*) | *.*| Text file |*.txt";
            OpenTags.FilterIndex = 2;
            if (OpenTags.ShowDialog() == DialogResult.OK)
            {
                if ((myStr = OpenTags.OpenFile()) != null)
                {
                    StreamReader myRead = new StreamReader(myStr, System.Text.Encoding.Default);
                    string[] str;

                    int num = 0;
                    try
                    {

                        string[] str1 = myRead.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num + 1;
                        for (int i = 0; i < num; i++)
                        {
                            {

                                str = str1[i].Split('|');
                                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                                {
                                    try
                                    {
                                        dataGridView1.Rows[i].Cells[j].Value = str[j];
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                            }
                        }
                    }
                    catch { MessageBox.Show("Произошла сбоя в электраэнергии"); }
                }
            }
            MessageBox.Show("Выполнено, епрст");
        }

        private void F3_Load_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form Start = new F1_Start();
            Start.Show();
        }
    }
}
