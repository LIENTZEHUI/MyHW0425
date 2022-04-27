
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmProducts : Form
    {
        public FrmProducts()
        {
            InitializeComponent();
            
            this.productsTableAdapter1.Fill(this.dataSetFrmProducts1.Products);

            this.bindingSource1.DataSource = this.dataSetFrmProducts1.Products;

            this.bindingNavigator1.BindingSource = this.bindingSource1;
        }

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position = 0;
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position = this.bindingSource1.Count - 1;
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position -= 1;
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            this.bindingSource1.Position += 1;
        }

        private void bindingSource1_CurrentChanged_1(object sender, EventArgs e)
        {
            this.label2.Text = $"{this.bindingSource1.Position + 1} / {this.bindingSource1.Count}";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string s = textBox3.Text;
            this.productsTableAdapter1.FillByProductName(this.dataSetFrmProducts1.Products, s);
            this.dataGridView1.DataSource = this.dataSetFrmProducts1.Products;

            this.dataGridView1.DataSource = this.dataSetFrmProducts1.Products;
            this.bindingSource1.DataSource = this.dataSetFrmProducts1.Products;
            this.dataGridView1.DataSource = this.bindingSource1;

            lblResult.Text = "結果" + this.bindingSource1.Count + "筆";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            this.productsTableAdapter1.FillByUnitPrice(this.dataSetFrmProducts1.Products, a, b);
            this.dataGridView1.DataSource = this.dataSetFrmProducts1.Products;
            this.bindingSource1.DataSource = this.dataSetFrmProducts1.Products;
            this.dataGridView1.DataSource = this.bindingSource1;
            lblResult.Text = "結果" + this.bindingSource1.Count + "筆";
        }

        //private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        //{
        //    this.bindingSource1.Position -= 1;
        //}

        //private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        //{
        //    this.bindingSource1.Position += 1;
        //}

        //private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        //{
        //    this.bindingSource1.Position =0;
        //}

        //private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        //{
        //    this.bindingSource1.Position = this.bindingSource1.Count - 1;
        //}
    }
}
