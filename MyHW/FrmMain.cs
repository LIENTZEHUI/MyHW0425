using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MyHW
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Frm標準練習cs form1 = new Frm標準練習cs();
            form1.TopLevel = false;
            form1.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(form1);
            form1.Show();


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            FrmCategoryProducts form2 = new FrmCategoryProducts();
            form2.TopLevel = false;
            form2.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(form2);
            form2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
             

            FrmProducts form3 = new FrmProducts();
            form3.TopLevel = false;
            form3.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(form3);
            form3.Show();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            FrmDataSet_結構cs form4 = new FrmDataSet_結構cs();
            form4.TopLevel = false;
            form4.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(form4);
            form4.Show();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmAdventureWorks frmAdventure = new FrmAdventureWorks();
            frmAdventure.TopLevel = false;
            frmAdventure.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(frmAdventure);
            frmAdventure.Show();

             
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmMyAlbum_V1 frmMyAlbum = new FrmMyAlbum_V1 ();
            frmMyAlbum.TopLevel = false;
            frmMyAlbum.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(frmMyAlbum);
            frmMyAlbum.Show();

           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FrmCustomers frmCustomers = new FrmCustomers();
            frmCustomers.TopLevel = false;
            frmCustomers.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(frmCustomers);
            frmCustomers.Show();

            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
           

            FrmLogon frmLogon = new FrmLogon();
            frmLogon.TopLevel = false;
            frmLogon.AutoScroll = true;
            splitContainer2.Panel2.Controls.Add(frmLogon);
            frmLogon.Show();

        }
    }
}
