using System.Security.Policy;
using System.Windows.Forms;

namespace DZ5_2_
{
    public partial class Goodss : Form
    {
        abstract class Goods
        {
            protected double price;
            protected string country, date, name, descr;
            public void SetPrice(double price)
            {
                this.price= price;
            }
            public void SetCountry(string country)
            {
                this.country = country;
            }
            public void SetDate(string date)
            {
                this.date = date;
            }
            public void SetName(string name)
            {
                this.name = name;
            }
            public void SetDescr(string descr)
            {
                this.descr = descr;
            }
            public double GetPrice()
            {
                return price;
            }
            public string GetCountry()
            {
                return country;
            }
            public string GetDate()
            {
                return date;
            }
            public string GetName()
            {
                return name;
            }
            public string GetDescr()
            {
                return descr;
            }


            public abstract string GetTerm();

            public abstract string GetMeasure();

            public abstract int GetCount();

            public abstract void SetTerm(string term);

            public abstract void SetMeasure(string measure);

            public abstract void SetCount(int count);
            public abstract int GetPages();

            public abstract string GetPublish();

            public abstract string GetAuth();

            public abstract void SetPages(int pages);

            public abstract void SetPublish(string publish);

            public abstract void SetAuth(string auth);
            

        }



        class Books : Goods
        {
            int pages;
            string publish, auth;
            public Books() { }
            public Books(double price,
            string country, string date, string name, string descr, string publish, string auth, int pages)
            {
                this.price = price;
                this.country = country;
                this.date = date;
                this.name = name;
                this.descr = descr;
                this.publish = publish;
                this.auth = auth;
                this.pages = pages;
            }
            public override int GetPages()
            {
                return pages;
            }
            public override string GetPublish()
            {
                return publish;
            }
            public override string GetAuth()
            {
                return auth;
            }
            public override void SetPages(int pages)
            {
                this.pages = pages;
            }
            public override void SetPublish(string publish)
            {
                this.publish = publish;
            }
            public override void SetAuth(string auth)
            {
                this.auth = auth;
            }
            public override string GetTerm()
            {
                return publish;
            }
            public override string GetMeasure()
            {
                return publish;
            }
            public override int GetCount()
            {
                return pages;
            }
            public override void SetTerm(string term)
            {

            }
            public override void SetMeasure(string measure)
            {

            }
            public override void SetCount(int count)
            {

            }
        }
        class Prod : Goods
        {
            string term, measure;
            int count;
            public Prod() { }
            public Prod(double price,
            string country, string date, string name, string descr, string term, string measure, int count)
            {
                this.price = price;
                this.country = country;
                this.date = date;
                this.name = name;
                this.descr = descr;
                this.term = term;
                this.measure = measure;
                this.count = count;
            }
            public override string GetTerm()
            {
                return term;
            }
            public override string GetMeasure()
            {
                return measure;
            }
            public override int GetCount()
            {
                return count;
            }
            public override void SetTerm(string term)
            {
                this.term = term;
            }
            public override void SetMeasure(string measure)
            {
                this.measure = measure;
            }
            public override void SetCount(int count)
            {
                this.count = count;
            }



            public override int GetPages()
            {
                return count;
            }
            public override string GetPublish()
            {
                return term;
            }
            public override string GetAuth()
            {
                return term;
            }
            public override void SetPages(int pages)
            {
                
            }
            public override void SetPublish(string publish)
            {
                
            }
            public override void SetAuth(string auth)
            {
                
            }
        }
        
        List<Goods> g = new List<Goods>();
       // Prod pr =new Prod(25,"India","25/04/2006","Banana","A beautiful banana","27/06/2009","kg",25);
        //g.Add(pr);
        //Goods[] g = new Goods[100];
        //int num = 0;
        public void addProd(double price, string country, string date, string name, string descr, string term, string measure, int count)
        {
            Prod temp=new Prod(price, country, date, name, descr, term, measure, count);
            g.Add(temp);
            dataGridView1.Rows.Add("Product", price, country, name, date, descr, term, count, measure,"-","-","-");
        }
        public void addBook(double price, string country, string date, string name, string descr, int pages ,string publish, string auth)
        {
            Books temp = new Books(price, country, date, name, descr, publish, auth, pages);
            g.Add(temp);
            dataGridView1.Rows.Add("Book", price, country, name, date, descr, "-", "-", "-", pages, publish, auth);
        }
        public Goodss()
        {
            InitializeComponent();
        }

        public void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == CheckColumn.TrueValue)
                {

                    a.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                }
            }*/
            
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Prod pr= new Prod();
            //g[num] = pr;
            //++num;
            g.Add(pr);
            dataGridView1.Rows.Add("Product");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                g.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a;
            a = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex);
            MessageBox.Show(a.ToString());
            switch (a)
            {
                case 1:
                    g[dataGridView1.CurrentRow.Index].SetPrice(Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value));
                    MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetPrice().ToString());
                    break;
                case 2:
                    g[dataGridView1.CurrentRow.Index].SetCountry(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                    MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetPrice().ToString());
                    break;
            }
            
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a;
                a = Convert.ToInt32(dataGridView1.CurrentCell.ColumnIndex);
                //MessageBox.Show(a.ToString());
                switch (a)
                {
                    case 1:
                        g[dataGridView1.CurrentRow.Index].SetPrice(Convert.ToDouble(dataGridView1.CurrentRow.Cells[1].Value));
                        //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetPrice().ToString());
                        break;
                    case 2:
                        g[dataGridView1.CurrentRow.Index].SetCountry(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                        //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetCountry().ToString());
                        break;
                    case 3:
                        g[dataGridView1.CurrentRow.Index].SetName(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                        //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetName().ToString());
                        break;
                    case 4:
                        g[dataGridView1.CurrentRow.Index].SetDate(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                        //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetDate().ToString());
                        break;
                    case 5:
                        g[dataGridView1.CurrentRow.Index].SetDescr(dataGridView1.CurrentRow.Cells[5].Value.ToString());
                        //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetDescr().ToString());
                        break;
                    case 6:
                        
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Product")
                        {
                            
                           g[dataGridView1.CurrentRow.Index] = (Prod)g[dataGridView1.CurrentRow.Index];
                            g[dataGridView1.CurrentRow.Index].SetTerm(dataGridView1.CurrentRow.Cells[6].Value.ToString());
                            //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetTerm().ToString());
                        }
                        else
                        {
                            MessageBox.Show("Not appropriate");
                        }
                        break;
                    case 7:
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Product")
                        {
                            g[dataGridView1.CurrentRow.Index].SetCount(Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value));
                            //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetCount().ToString());
                        }
                        else
                        {
                            MessageBox.Show("Not appropriate");
                        }
                        break;
                    case 8:
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Product")
                        {
                            g[dataGridView1.CurrentRow.Index].SetMeasure(dataGridView1.CurrentRow.Cells[8].Value.ToString());
                            //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetMeasure().ToString());
                        }
                        else
                        {
                            MessageBox.Show("Not appropriate");
                        }
                        break;
                    case 9:
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Book")
                        {
                            g[dataGridView1.CurrentRow.Index].SetPages(Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value));
                            //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetPages().ToString());
                        }
                        else
                        {
                            MessageBox.Show("Not appropriate");
                        }
                        break;
                    case 10:
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Book")
                        {
                            g[dataGridView1.CurrentRow.Index].SetPublish(dataGridView1.CurrentRow.Cells[10].Value.ToString());
                            //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetPublish().ToString());
                        }
                        else
                        {
                            MessageBox.Show("Not appropriate");
                        }
                        break;
                    case 11:
                        if (dataGridView1.CurrentRow.Cells[0].Value.ToString() == "Book")
                        {
                            g[dataGridView1.CurrentRow.Index].SetAuth(dataGridView1.CurrentRow.Cells[11].Value.ToString());
                            //MessageBox.Show(g[dataGridView1.CurrentRow.Index].GetAuth().ToString());
                        }
                        else
                        {
                            MessageBox.Show("Not appropriate");
                        }
                        break;
                }
            }
            catch
            {

            }
            

        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Books book = new Books();
            //g[num] = book;
            //++num;
            g.Add(book);
            dataGridView1.Rows.Add("Book");
        }

        private void Goodss_Load(object sender, EventArgs e)
        {
            addProd(25.7, "India", "25/04/2006", "Banana", "A beautiful banana", "27/06/2009", "kg", 25);
            addBook(4565.577, "Vietnam", "25/04/2006", "Book about life", "Just a book", 1, "VietnamBooks", "Min Hon Li");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        
    }
    
}