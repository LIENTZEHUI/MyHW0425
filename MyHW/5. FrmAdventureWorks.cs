using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmAdventureWorks : Form
    {
        public FrmAdventureWorks()
        {
            InitializeComponent();
            LoadYearToCombobox();
            CreateListViewColumns();
            
            this.bindingSource1.DataSource = this.awDataSet11.ProductPhoto;
            this.bindingNavigator1.BindingSource = this.bindingSource1;

        }

       

        private void LoadYearToCombobox()
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection("Data Source =.; Initial Catalog = AdventureWorks2019; Integrated Security = True"))
                {
                    Conn.Open();

                    SqlCommand command = new SqlCommand("select distinct DATEPART(year,ModifiedDate) as Year from Production.ProductPhoto ", Conn);
                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox1.Items.Clear();
                    //dataReader.Read();


                    while (dataReader.Read())
                    {
                        this.comboBox1.Items.Add(dataReader["Year"]);
                    }

                    //new sqldataReader



                    

                    this.comboBox1.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CreateListViewColumns()
        {
            //Select 

            this.productPhotoTableAdapter1.FillBy1(this.awDataSet11.ProductPhoto, this.comboBox1.Text);
            this.dataGridView1.DataSource = this.awDataSet11.ProductPhoto;

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.productPhotoTableAdapter1.FillBy2(this.awDataSet12.ProductPhoto);
            //this.comboBox1.DataSource = this.awDataSet12.ProductPhoto;

            //string f = "";
            //for (int i = 0; i < awDataSet12.ProductPhoto.Rows.Count; i++)
            //{
            //    f += awDataSet12.ProductPhoto.Rows[i][0].ToString();
            //    this.comboBox1.Items.Add(f);

            //}
            //string a = this.comboBox1.Text;
            //SqlConnection conn = null;

            //conn = new SqlConnection("Data Source =.; Initial Catalog = AdventureWorks2019; Integrated Security = True");
            //conn.Open();

            //SqlCommand command = new SqlCommand("Select*from Production.ProductPhoto convert(char(4),ModifiedDate,102)= '{a}'", conn);




            








        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.FillBy(this.awDataSet11.ProductPhoto, dateTimePicker1.Value, dateTimePicker2.Value);
            this.dataGridView1.DataSource = this.awDataSet11.ProductPhoto;
            this.bindingSource1.DataSource = this.awDataSet11.ProductPhoto;
            this.dataGridView1.DataSource = this.bindingSource1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.Fill(this.awDataSet11.ProductPhoto);
            this.dataGridView1.DataSource = this.awDataSet11.ProductPhoto;
            this.bindingSource1.DataSource = this.awDataSet11.ProductPhoto;
            this.dataGridView1.DataSource = this.bindingSource1;


        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position -= 1;
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position += 1;
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.bindingSource1.Count - 1;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.FillBy1(this.awDataSet11.ProductPhoto, this.comboBox1.Text);
            this.dataGridView1.DataSource = this.awDataSet11.ProductPhoto;
        }
    }
}
