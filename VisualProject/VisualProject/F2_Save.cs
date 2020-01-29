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
    public partial class F2_Save : Form
    {
        public F2_Save()
        {
            InitializeComponent();
        }

        private void F2_Save_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount = 10;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            System.IO.Stream myStream;

            SaveFileDialog saveTags = new SaveFileDialog();
            saveTags.Filter = "All file (*.*) | *.*| Text file |*.txt";
            saveTags.FilterIndex = 2;

            if (saveTags.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveTags.OpenFile()) != null)
                {
                    StreamWriter myWriter = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                myWriter.Write(dataGridView1.Rows[i].Cells[j].Value.ToString());
                                if ((dataGridView1.ColumnCount - j) != 1) myWriter.Write("|");
                            }

                            if (((dataGridView1.RowCount - 1) - i - 1) != 0) myWriter.WriteLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWriter.Close();
                    }
                }
                myStream.Close();
            }
            MessageBox.Show("Сохранено!");
            Form Start = new F1_Start();
            Start.Show();
            this.Hide();
        }
    }
}
