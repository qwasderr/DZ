using System.Windows.Forms;

namespace DZ_WinForm_
{
    public partial class Form1 : Form
    {
        string n="";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            n = textBox1.Text;
        }   

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    int num = Int32.Parse(n);
                    MessageBox.Show("Ви ввели число " + n);
            }
                catch (FormatException)
                {
                    MessageBox.Show("INT NUMBER, do you know how to read?");
                    
                }
            
            
        }
    }
}