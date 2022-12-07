using System.ComponentModel;

namespace Project4
{
    public partial class Form1 : Form
    {
        public Helper help;
        private int test_per, temp_timer=0, isloaded=0;
        //private bool license = false;
        private int tries = 0;
        private string license_key = "X51yK7HV5017Q1NmaT4H71B";
        public Form1()
        {
            InitializeComponent();
        }
        public Form1(Helper h)
        {
            InitializeComponent();
            help = h;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            /*try
            {
                JSON j = new JSON();
                j.DeSer(dataGridView1,help);
                MessageBox.Show("Successfuly loaded");
                isloaded = 1;
            }
            catch
            {
                MessageBox.Show("Error while loading");
            }*/



            //help.cancel_license(420);



            if (help.set_regstart_key()==false) help.first_reg();
                help.update_free_time();
                help.update_license();

            
            
            help.registr();
            test_per = help.seconds();
            
            if (help.license==false) MessageBox.Show("This is a test version of the program. You have a limited time to work with the program (" + (test_per / 60).ToString() + " minutes, " + (test_per % 60).ToString() + " seconds)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                button9.Hide();
                textBox1.Hide();
                label1.Hide();
                timer1.Stop();
            }
            //MessageBox.Show(test_per.ToString());
            isloaded = 1;
        }


        //Serialization
        private void button1_Click(object sender, EventArgs e)
        {
            /* try
             {
                 JSON j = new JSON();
                 j.Ser(dataGridView1);
                 MessageBox.Show("Success");
             }
             catch
             {
                 MessageBox.Show("Error");
             }*/
            JSON j = new JSON();
            j.Ser(dataGridView1, help);
            /*Rep_Form rep = new Rep_Form();
            rep.Ser_Form(dataGridView1);*/
        }


        //Deserialization
        private void button2_Click(object sender, EventArgs e)
        {
            /*try
            {
                JSON j = new JSON();
                j.DeSer(dataGridView1);
                MessageBox.Show("Success");
            }
            catch
            {
                MessageBox.Show("Error");
            }*/
            JSON j = new JSON();
            j.DeSer(dataGridView1, help);
            /*Rep_Form rep = new Rep_Form();
            rep.DeSer_Form(dataGridView1);*/
        }
        /*public void DeSer_Form(DataGridView dg)
        {
            try
            {
                JSON j = new JSON();
                j.DeSer(dg);
                //MessageBox.Show("Successfuly loaded");
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }
        public void Ser_Form(DataGridView dg)
        {
            try
            {
                JSON j = new JSON();
                j.Ser(dg);
                
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }*/


        //Delete a row
        public void delete()
        {
            if (dataGridView1.Rows.Count > 1 && dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                //g.RemoveAt(dataGridView1.CurrentRow.Index);
            }
            if (help.path!=null) MessageBox.Show("Successfuly deleted");
            Update();
        }


        //Serealization after deletion
        public void Update()
        {
            if (help.path == null) MessageBox.Show("Choose a JSON file", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                JSON j = new JSON();
                j.Ser(dataGridView1, help);
                //j.DeSer(dataGridView1, help);
            }
            /*Rep_Form rep = new Rep_Form();
            rep.Ser_Form(dataGridView1);
            rep.DeSer_Form(dataGridView1);*/
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       

        //Closing a form handler
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
                DialogResult result = MessageBox.Show("Save changes?", "¿Dilemma?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                JSON j = new JSON();
                j.Ser(dataGridView1, help);
            }
                else if (result == System.Windows.Forms.DialogResult.No)
                {

                }
                else e.Cancel = true;
           
}


        // button "About"
        private void button3_Click(object sender, EventArgs e)
        {
            Check_form2();
        }


        //button "Delete"
        private void button4_Click(object sender, EventArgs e)
        {
            delete();
        }


        //button "Add"
        private void button5_Click(object sender, EventArgs e)
        {
            Check_form4();
            
        }


        //Сhecking for the existence of only one form
        private void Check_form3()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form3")
                {
                    
                    return;

                }
            }
            if (help.path != null)
            {
                Form3 newForm3 = new Form3(this, help);
                newForm3.Show();
            }
            else MessageBox.Show("Choose a JSON file", null, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Check_form2()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form2")
                {

                    return;

                }
            }

            Form2 newForm2 = new Form2();
            newForm2.Show();

        }
        private void Check_form4()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form4")
                {

                    return;

                }
            }
            if (help.path != null)
            {
                Form4 newForm4 = new Form4(this, help);
                newForm4.Show();
            }
            else MessageBox.Show("Choose a JSON file", null, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Check_form5()
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form5")
                {

                    return;

                }
            }
            if (help.path != null)
            {
                Form5 newForm5 = new Form5(this, help);
                newForm5.Show();
            }
            else MessageBox.Show("Choose a JSON file", null, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        


        //Button "Edit"
        private void button6_Click(object sender, EventArgs e)
        {
            Check_form3();
            
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
        

        //Button "Open File"
        private void button7_Click(object sender, EventArgs e)
        {

            help.OpenFile(openFileDialog1);
            JSON j = new JSON();
            j.DeSer(dataGridView1, help);
            //MessageBox.Show(openFileDialog1.FileName.ToString());

        }


        //Button "Search"
        private void button8_Click(object sender, EventArgs e)
        {
            Check_form5();
        }
        private void ActLicense(Helper help)
        {
            help.license = true;
            help.activate_license();
            MessageBox.Show("Thanks for buying", "Thanks☻");
            button9.Hide();
            textBox1.Hide();
            label1.Hide();
            timer1.Stop();

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == license_key) ActLicense(help);
            else if (tries<4) MessageBox.Show("Wrong key", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            if (tries >= 4) MessageBox.Show("Stop guessing or i will format your SSD", "The first and the last warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            tries++;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        //Timer handler
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            
            if (help.time >= test_per && temp_timer==0) { temp_timer = 1; JSON j = new JSON(); j.Ser(dataGridView1, help); MessageBox.Show("Goodbye, have a nice day :)");   this.Close(); }
            if (temp_timer == 0 && isloaded==1)
            {
                help.IncreaseTime();
                help.registr();
                label1.Text = null;
                if (((test_per - help.time) / 60) > 9) label1.Text = label1.Text + "Time left: " + ((test_per - help.time) / 60).ToString() + ":";
                else label1.Text = label1.Text + "Time left: " + "0"+((test_per - help.time) / 60).ToString() + ":";
                if (((test_per - help.time) % 60) > 9) label1.Text = label1.Text+ ((test_per - help.time) % 60).ToString();
                else label1.Text = label1.Text+ "0" + ((test_per - help.time) % 60).ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}