using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4
{
    public partial class Form4 : Form
    {
        public Form1 form1;
        public Helper help;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(Form1 f, Helper h)
        {
            InitializeComponent();
            form1 = f;
            help = h;
        }
        public void Confirm()
        {

            int iserror = 0;
            int sameid = 0;
            //MessageBox.Show((Convert.ToInt32(dataGridView1.Rows.Count) - 1).ToString());
            for (int i = 0; i < Convert.ToInt32(dataGridView1.Rows.Count) - 1; i++)
            {
                //MessageBox.Show(i.ToString());
                try
                {
                    form1.dataGridView1.Rows.Add(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[2].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString(), dataGridView1.Rows[i].Cells[4].Value.ToString(), dataGridView1.Rows[i].Cells[5].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Error, ID and Price must be numbers", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iserror = 1;
                }
                catch
                {
                    MessageBox.Show("Error, fill all the fields", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    iserror = 1;
                }
                if (help.SameId(form1.dataGridView1) == true)
                {
                    sameid = 1;
                    form1.dataGridView1.Rows.RemoveAt(form1.dataGridView1.RowCount-2);
                    //MessageBox.Show("Items can't have the same Id");
                }
            }
            if (sameid == 1) MessageBox.Show("Items can't have the same Id", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (iserror == 0 && sameid==0)
            {
                JSON js = new JSON();
                js.Ser(form1.dataGridView1, help);
                /*Rep_Form rep = new Rep_Form();
                rep.Ser_Form(form1.dataGridView1);*/
                //MessageBox.Show("Successfuly saved");
                this.Close();

            }
            /*else if (help.SameId(form1.dataGridView1) == true)
            {
                MessageBox.Show("Items can't have the same Id");
                j.DeSer(form1.dataGridView1, help);
            }
            //MessageBox.Show("Done");
            //rep.DeSer_Form(form1.dataGridView1);
        }*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
          Confirm();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            JSON j = new JSON();
            //MessageBox.Show(help.path);
            j.DeSer(form1.dataGridView1, help);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
