using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project4
{
    public partial class Form5 : Form
    {
        public Helper help;
        public Form1 form1;
        private string textfield_first;
        public Form5()
        {
            InitializeComponent();
        }
        public Form5(Form1 f, Helper h)
        {
            InitializeComponent();
            form1 = f;
            help = h;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Search()
        {
            if (comboBox1.SelectedIndex == -1) MessageBox.Show("Select a sorting method", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (textBox1.Text == textfield_first) MessageBox.Show("Enter a value", null, MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        LINQ l1 = new LINQ();
                        try { Convert.ToInt32(textBox1.Text); }
                        catch
                        {
                            MessageBox.Show("Enter a number", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        l1.LINQId(Convert.ToInt32(textBox1.Text), help, dataGridView1);
                        break;
                    case 1:
                        LINQ l2 = new LINQ();
                        l2.LINQName(textBox1.Text.ToString(), help, dataGridView1);
                        break;
                    case 2:
                        LINQ l3 = new LINQ();
                        l3.LINQTopic(textBox1.Text.ToString(), help, dataGridView1);
                        break;
                    case 3:
                        LINQ l4 = new LINQ();
                        l4.LINQPlace(textBox1.Text.ToString(), help, dataGridView1);
                        break;

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Search();
           
        }
        public class LINQ
        {
            async public void LINQId(int i, Helper help, DataGridView dg)
            {
                using (FileStream fs = new FileStream(help.path, FileMode.OpenOrCreate))
                {
                    help.ClearTable(dg);
                    var conf = await JsonSerializer.DeserializeAsync<List<Conf>>(fs);
                    var search = conf.Where(x => x.ID==i).ToList();
                    if (search.Count() == 0) MessageBox.Show("There's no such elements", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach(var s in search)
                    {
                        dg.Rows.Add(s.ID, s.Name, s.Term, s.Topic, s.Organizer, s.Place, s.Price);
                    }
                }
            }
            async public void LINQName(string i, Helper help, DataGridView dg)
            {
                using (FileStream fs = new FileStream(help.path, FileMode.OpenOrCreate))
                {
                    help.ClearTable(dg);
                    var conf = await JsonSerializer.DeserializeAsync<List<Conf>>(fs);
                    var search = conf.Where(x => x.Name == i).ToList();
                    if (search.Count() == 0) MessageBox.Show("There's no such elements", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (var s in search)
                    {
                        dg.Rows.Add(s.ID, s.Name, s.Term, s.Topic, s.Organizer, s.Place, s.Price);
                    }
                }
            }
            async public void LINQTopic(string i, Helper help, DataGridView dg)
            {
                using (FileStream fs = new FileStream(help.path, FileMode.OpenOrCreate))
                {
                    help.ClearTable(dg);
                    var conf = await JsonSerializer.DeserializeAsync<List<Conf>>(fs);
                    var search = conf.Where(x => x.Topic == i).ToList();
                    if (search.Count() == 0) MessageBox.Show("There's no such elements", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (var s in search)
                    {
                        dg.Rows.Add(s.ID, s.Name, s.Term, s.Topic, s.Organizer, s.Place, s.Price);
                    }
                }
            }
            async public void LINQPlace(string i, Helper help, DataGridView dg)
            {
                using (FileStream fs = new FileStream(help.path, FileMode.OpenOrCreate))
                {
                    help.ClearTable(dg);
                    var conf = await JsonSerializer.DeserializeAsync<List<Conf>>(fs);
                    var search = conf.Where(x => x.Place == i).ToList();
                    if (search.Count() == 0) MessageBox.Show("There's no such elements", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    foreach (var s in search)
                    {
                        dg.Rows.Add(s.ID, s.Name, s.Term, s.Topic, s.Organizer, s.Place, s.Price);
                    }
                }
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textfield_first=textBox1.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
