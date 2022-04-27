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
    public partial class FrmDataSet_結構cs : Form
    {
        public FrmDataSet_結構cs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.categoriesTableAdapter1.Fill(this.nwDataSet11.Categories);
            this.productsTableAdapter1.Fill(this.nwDataSet11.Products);
            this.customersTableAdapter1.Fill(this.nwDataSet11.Customers);


            this.dataGridView6.DataSource = this.nwDataSet11.Categories;
            this.dataGridView1.DataSource = this.nwDataSet11.Products;
            this.dataGridView7.DataSource = this.nwDataSet11.Customers;
            //==================================

            this.listBox2.Items.Clear();

            for (int i = 0; i <= this.nwDataSet11.Tables.Count - 1; i++)
            {
                DataTable table = this.nwDataSet11.Tables[i];
                this.listBox2.Items.Add(table.TableName);


                //table.Columns //column schema
                string s = "";
                for (int column = 0; column <= table.Columns.Count - 1; column++)
                {
                    s += table.Columns[column].ColumnName + " ";
                }
                this.listBox2.Items.Add(s);
                string p = "";





                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int j = 0; j < table.Columns.Count; j++)
                    {

                        p = p + table.Rows[row][j];


                    }

                    this.listBox2.Items.Add(p);
                    p = "";
                }





                ////================================
                ////table.Rows -Data
                ////TODO .....


                //for (int row = 0; row <= table.Rows.Count - 1; row++)
                //{
                //    //DataRow dr = table.Rows[row];
                //    this.listBox2.Items.Add(table.Rows[row][0]);
                //}





                this.listBox2.Items.Add("==========================");
            }
        }
    }
}
