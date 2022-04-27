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
    public partial class FrmCustomers : Form
    {
        public FrmCustomers()
        {
            InitializeComponent();

            this.listView1.View = View.Details;
            LoadCountryToComboBox();
            CreateListViewColumns();

             

        }

        private void CreateListViewColumns()
        {

            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True"))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select * from Customers", conn);

                    SqlDataReader dataReader = command.ExecuteReader();




                    DataTable table = dataReader.GetSchemaTable();

                    

                    for (int i = 0; i <= table.Rows.Count - 1; i++)
                    {
                        this.listView1.Columns.Add(table.Rows[i][0].ToString());
                    }

                    this.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCountryToComboBox()
        {
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True"))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand("select distinct Country from Customers", conn);

                    SqlDataReader dataReader = command.ExecuteReader();

                    this.comboBox1.Items.Clear();
                    while (dataReader.Read())
                    {
                        this.comboBox1.Items.Add(dataReader["Country"]);
                        
                    }
                    this.comboBox1.Items.Add("All Country");
                    this.comboBox1.SelectedIndex = 0;

                } // Auto conn.Close()
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

 

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Select 
            try
            {
                if (comboBox1.SelectedItem != "All Country")
                {

                    using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True"))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"select * from Customers where country='{this.comboBox1.Text}'";
                        command.Connection = conn;

                        SqlDataReader dataReader = command.ExecuteReader();

                        this.listView1.Items.Clear();

                        Random r = new Random();
                        while (dataReader.Read())
                        {

                            ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());

                            lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);

                            if (lvi.Index % 2 == 0)
                            {
                                lvi.BackColor = Color.Orange;
                            }
                            else
                            {
                                lvi.BackColor = Color.LightGray;
                            }


                            for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                            {
                                if (dataReader.IsDBNull(i))
                                {
                                    lvi.SubItems.Add("空值");
                                }
                                else
                                {
                                    lvi.SubItems.Add(dataReader[i].ToString());
                                }

                            }
                        }
                    }


                }

                else
                    using (SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = Northwind; Integrated Security = True"))
                    {
                        conn.Open();
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"select * from Customers";
                        command.Connection = conn;

                        SqlDataReader dataReader = command.ExecuteReader();

                        this.listView1.Items.Clear();

                        Random r = new Random();
                        while (dataReader.Read())
                        {

                            ListViewItem lvi = this.listView1.Items.Add(dataReader[0].ToString());

                            lvi.ImageIndex = r.Next(0, this.ImageList1.Images.Count);

                            if (lvi.Index % 2 == 0)
                            {
                                lvi.BackColor = Color.Orange;
                            }
                            else
                            {
                                lvi.BackColor = Color.LightGray;
                            }


                            for (int i = 1; i <= dataReader.FieldCount - 1; i++)
                            {
                                if (dataReader.IsDBNull(i))
                                {
                                    lvi.SubItems.Add("空值");
                                }
                                else
                                {
                                    lvi.SubItems.Add(dataReader[i].ToString());
                                }

                            }
                        }
                    }

            }
            // Auto conn.Close()

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
