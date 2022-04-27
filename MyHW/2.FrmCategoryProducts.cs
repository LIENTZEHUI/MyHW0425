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
    public partial class FrmCategoryProducts : Form
    {
        public FrmCategoryProducts()
        {
            InitializeComponent();
            LoadCategoriesToComboBox();
            LoadCategoriesToComboBox2();
        }

        private void LoadCategoriesToComboBox2()
        {
            string a = this.comboBox1.Text;
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True"))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select CategoryID, CategoryName from  Categories", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox2.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.comboBox2.Items.Add(dataReader["CategoryName"].ToString());
                    }


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void  LoadCategoriesToComboBox()
        {
            string a = this.comboBox1.Text;
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True"))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select CategoryID, CategoryName from  Categories" , conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.comboBox1.Items.Add(dataReader["CategoryName"].ToString());
                    }
                  

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   //Step 1: SqlConnection
            //Step 2: SqlCommand
            //Step 3: SqlDataReader
            //Step 4: UI Control

            //Select 
            string a = this.comboBox1.Text;
            SqlConnection conn = null;

            try
            {
                conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                conn.Open();

                SqlCommand command = new SqlCommand($"select b.CategoryID, ProductName,UnitPrice,CategoryName from Products a join Categories b  on a.CategoryID = b.CategoryID where CategoryName = '{a}'", conn);

                // new SqlDataReader();
                SqlDataReader dataReader = command.ExecuteReader();

                this.listBox1.Items.Clear();

                while (dataReader.Read())
                {
                    // syntax sugar 語法糖 for  string.Format(..)
                    string s = $"{dataReader["ProductName"],-40} - {dataReader["UnitPrice"]:c2}";
                    this.listBox1.Items.Add(s);
                }
                //ex.Message  "當目前沒有資料時，嘗試讀取無效。"  
                //MessageBox.Show(dataReader["ProductName"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    //....
                }


            }

                // this.comboBox1.Text
                //Step 1: SqlConnection
                //Step 2: SqlCommand
                //Step 3: SqlDataReader
                //Step 4: UI Control

                //SqlConnection conn = null;
                //try
                //{
                //    conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
                //    conn.Open();

                //    int c = comboBox1.SelectedIndex;
                //    c = c + 1;


                //    SqlCommand command = new SqlCommand("select b.CategoryID, ProductName," +
                //        "CategoryName from Products a join Categories b  on a.CategoryID=b.CategoryID where a.CategoryID= " + c, conn);
                //    // new SqlDataReader();
                //    SqlDataReader dataReader = command.ExecuteReader();

                //    this.comboBox1.Items.Clear();

                //    while (dataReader.Read())
                //    {
                //        string k = $"{dataReader["CategoryID"]}";
                //        this.comboBox1.Items.Add(k);


                //        // syntax sugar 語法糖 for  string.Format(..)

                //        string s = $"{dataReader["CategoryID"]} - {dataReader["ProductName"]:c2}";



                //        this.listBox1.Items.Add(s);






                //    }
                //}

                ////ex.Message  "當目前沒有資料時，嘗試讀取無效。"  
                ////MessageBox.Show(dataReader["ProductName"].ToString());
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}

                //finally
                //{
                //    if (conn != null)
                //    {
                //        conn.Close();
                //        //....
                //    }
                //}



            }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            //SqlCommand command = new SqlCommand($"select b.CategoryID, ProductName,UnitPrice,CategoryName from Products a join Categories b  on a.CategoryID = b.CategoryID where CategoryName = '{a}'", conn);
            //DataSet ds = this.nwDataSet11.Products.DataSet;
            //this.productPhotoTableAdapter1.FillBy1(this.awDataSet11.ProductPhoto, this.comboBox1.Text);
            //this.dataGridView1.DataSource = this.awDataSet11.ProductPhoto;


            SqlConnection _connection = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True");
            SqlDataAdapter adapter = new SqlDataAdapter($"select   ProductName,UnitPrice  from Products a join Categories b  on a.CategoryID = b.CategoryID where CategoryName = '{this.comboBox2.Text}'",_connection);
            DataTable _table = new DataTable();
            adapter.Fill(_table);
            _connection.Close();

            string s = "";

            listBox2.Items.Clear();

            for (int row = 0; row < _table.Rows.Count; row++)
            {
                for (int j = 0; j < _table.Columns.Count; j++)
                {

                    s = s + _table.Rows[row][j];


                }

                this.listBox2.Items.Add(s);
                s = "";
            }
            listBox2.Items.Add(s);

        }
    }
}



