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
    public partial class Form3 : Form
    {
        public Form1 form1;
        public Helper help;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(Form1 f, Helper h)
        {
            InitializeComponent();
            form1 = f;
            help = h;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            JSON j = new JSON();
            j.DeSer(dataGridView1, help);
            /*Rep_Form rep = new Rep_Form();
            rep.DeSer_Form(dataGridView1);*/
        }
        public void Confirm()
        {
            JSON j = new JSON();
            j.Ser(dataGridView1, help); j.DeSer(form1.dataGridView1, help); 

            /*Rep_Form rep = new Rep_Form();
            rep.Ser_Form(dataGridView1);*/
            //MessageBox.Show("Done");

            //rep.DeSer_Form(form1.dataGridView1);
            //MessageBox.Show(rep.iserror.ToString());
            if (j.iserror == 0)
            {
                MessageBox.Show("Successfuly saved");
                this.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Confirm();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
