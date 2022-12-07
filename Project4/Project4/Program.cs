using System.Text.Json.Serialization;
using System.Text.Json;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Project4
{

    //base class of the json file
    public class Conf
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Term { get; set; }
        public string Topic { get; set; }
        public string Organizer { get; set; }
        public string Place { get; set; }
        public int Price { get; set; }
        public Conf(int id, string name, string term, string topic, string org, string place, int price)
        {
            ID = id;
            Name = name;
            Term = term;
            Topic = topic;
            Organizer = org;
            Place = place;
            Price = price;
        }
        public Conf() { }
    }
    //class to work with JSON file
    public class JSON
    {
        public int iserror = 0;
        async public void Ser(DataGridView dg, Helper help)
        {
            if (help.SameId(dg) == true) {MessageBox.Show("Items can't have the same Id", null, MessageBoxButtons.OK, MessageBoxIcon.Error); iserror = 1;}
            if (help.HaveNull(dg) == true) {MessageBox.Show("Fill all the fields", null, MessageBoxButtons.OK, MessageBoxIcon.Error); iserror=1;}
            else
            {
                try
                {
                    using (FileStream fs = new FileStream(help.path, FileMode.Create))
                    {
                        var opt = new JsonSerializerOptions
                        {
                            WriteIndented = true,
                            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
                        };
                        var conf = new List<Conf>();
                        for (int i = 0; i < Convert.ToInt32(dg.Rows.Count) - 1; i++)
                        {
                            try
                            {
                                conf.Add(new Conf(Convert.ToInt32(dg.Rows[i].Cells[0].Value), dg.Rows[i].Cells[1].Value.ToString(), dg.Rows[i].Cells[2].Value.ToString(), dg.Rows[i].Cells[3].Value.ToString(), dg.Rows[i].Cells[4].Value.ToString(), dg.Rows[i].Cells[5].Value.ToString(), Convert.ToInt32(dg.Rows[i].Cells[6].Value)));
                                //MessageBox.Show("Successfuly saved");
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("ID and Price must be numbers", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                iserror = 1;
                            }
                            catch
                            {
                                MessageBox.Show("Fill all the fields", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                iserror = 1;
                            }

                        }

                        //conf.Add(new Conf(1,"123", "24.5-03.6", "Math", "Mark.L", "Kyiv", 200));
                        //conf.Add(new Conf(2,"123", "24.5-03.6", "Math", "Mark.L", "Kyiv", 200));
                        if (iserror == 0) await JsonSerializer.SerializeAsync(fs, conf, opt);
                        else
                        {
                            byte[] bytes = Encoding.UTF8.GetBytes("[]"); fs.Write(bytes, 0, bytes.Length);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Choose a JSON file", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    iserror = 1;
                }
                finally
                {
                    if (iserror == 0) MessageBox.Show("Successfuly saved");
                }
            }
        }
        async public void DeSer(DataGridView dg, Helper help)
        {
            try
            {
                using (FileStream fs = new FileStream(help.path, FileMode.OpenOrCreate))
                {

                    try
                    {
                        var conf = await JsonSerializer.DeserializeAsync<List<Conf>>(fs);
                        help.ClearTable(dg);
                        foreach (var c in conf)
                        {
                            //MessageBox.Show($"{c.ID} - {c.Name} - {c.Term} - {c.Topic} - {c.Organizer} - {c.Place} - {c.Price}");
                            //dg.Rows[i].Cells[0].Value = c.ID;
                            dg.Rows.Add(c.ID, c.Name, c.Term, c.Topic, c.Organizer, c.Place, c.Price);

                        }
                    }
                    catch
                    {
                        MessageBox.Show("Error", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        iserror = 1;
                    }
                    
                }
            }
            catch
            {
                MessageBox.Show("Choose a JSON file", null, MessageBoxButtons.OK, MessageBoxIcon.Information);
                iserror=1;
            }
            finally
            {
                if (iserror == 0) MessageBox.Show("Successfuly loaded");
            }
        }
    }
    /*public class Rep_Form
    {
        public int iserror = 0;
        public void DeSer_Form(DataGridView dg)
        {
            //iserror = 0;
            try
            {
                JSON j = new JSON();
                
                j.DeSer(dg);
                //MessageBox.Show("fgfgfg" + iserror.ToString());
                //iserror = j.iserror;
                
                
            }
            catch
            {
                MessageBox.Show("Error");
                iserror = 1;
            }
            if (iserror==0) MessageBox.Show("Successfuly loaded");

        }
        public void Ser_Form(DataGridView dg)
        {
            //iserror=0;
            try
            {
                JSON j = new JSON();
                j.Ser(dg);
                iserror = j.iserror;

            }
            catch
            {
                MessageBox.Show("Error");
                iserror= 1;
            }
            if (iserror == 0) MessageBox.Show("Successfuly saved");
        }
    }*/

    //class with additional func
    public class Helper
    {
        public int time {get; set; }
        private static int freeper = 420;
        private int freeperavaliable;
        private bool startkey=false;
        public string path;
        public RegistryKey regkey;
        public bool license=false;
        public Helper()
    {
            time = 0;
            regkey = Registry.CurrentUser.CreateSubKey("JSON");
        }

        //timer
        public void IncreaseTime()
        {
            time++;
        }

        //open JSON file
        public void OpenFile(OpenFileDialog of)
        {
            of.FileName = null;
            //while ((of.FileName.ToString().Contains(".json") == false))
            //{
                //MessageBox.Show(of.ToString());
                of.Filter = "JSON files|*.json";
                of.ShowDialog();
                //if (of.FileName.ToString().Contains(".json") == false) MessageBox.Show("Choose a JSON file");
            //}
            if (of.FileName.ToString().Contains(".json") == true) this.path = of.FileName.ToString();
        }

        //checks if some rows have the same id
        public bool SameId(DataGridView dg)
        {
            List<int> temp = new List<int>();
            try
            {
                for (int i = 0; i < dg.Rows.Count-1; i++) temp.Add(Convert.ToInt32(dg.Rows[i].Cells[0].Value));
                
            }
            catch { return false; }
            var hasDuplicates = temp.GroupBy(x => x).Any(g => g.Count() > 1);
            return hasDuplicates;

        }

        //clears the datagrid
        public void ClearTable(DataGridView dg)
        {
            //MessageBox.Show(dg.Rows.Count.ToString());
            /*bool flag = false;
            while (dg.Rows.Count > 0 && flag==false)
            {
                try { dg.Rows.Remove(dg.Rows[dg.Rows.Count - 2]); }
                catch { flag = true; }
            }*/
            dg.Rows.Clear();
        }


        //checks if a row has some empty cells
        public bool HaveNull(DataGridView dg)
        {
            bool res = false;
            for (int i = 0; i < Convert.ToInt32(dg.Rows.Count) - 1; i++)
            {
                for (int j = 0; j <= 6; ++j)
                    if ((dg.Rows[i].Cells[j].Value == null)) res = true;
                
            }
            return res;
          }
        public void update_free_time()
        {
            freeperavaliable = Convert.ToInt32(regkey.GetValue("seconds").ToString());
        }
        public void registr()
        {
            regkey.SetValue("isregistred", license);
            regkey.SetValue("seconds", (freeperavaliable-time).ToString());
            
        }
        public void cancel_license(int freetime)
        {
            regkey.SetValue("isregistred", false);
            regkey.SetValue("seconds", freetime.ToString());
            regkey.SetValue("isstarted", false);
        }
        public bool isreg()
        {
            return bool.Parse(regkey.GetValue("isregistred").ToString());
        }
        public int seconds()
        {
            return Convert.ToInt32(regkey.GetValue("seconds").ToString());
        }
        public void activate_license()
        {
            regkey.SetValue("isregistred", true);
        }
        public void update_license()
        {
            license = bool.Parse(regkey.GetValue("isregistred").ToString());
        }
        public bool set_regstart_key()
        {

            try
            {
                startkey = bool.Parse(regkey.GetValue("isstarted").ToString());
                if (startkey == false) return false;
                else return true;
                //return startkey;
            }
            catch { regkey.SetValue("isstarted", true); return false; }
            
                //
            }
        public void first_reg()
        {
            regkey.SetValue("isregistred", false);
            regkey.SetValue("seconds", freeper.ToString());
        }
        public bool isstarted()
        {
            try { if (bool.Parse(regkey.GetValue("isstarted").ToString()) == true) return true; else return false; }
            catch { return false; }
        }
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            Helper help = new Helper();
            
            Application.Run(new Form1(help));
            
        }
    }
}