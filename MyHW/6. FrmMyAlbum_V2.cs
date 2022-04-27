using MyHW.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyHW
{
    public partial class FrmMyAlbum_V1 : Form
    {
        public FrmMyAlbum_V1()
        {
            InitializeComponent();
            LoadCategoriesToComboBox();
            LoadCategoriesToComboBox2();


            this.flowLayoutPanel3.AllowDrop = true;
            this.flowLayoutPanel3.DragEnter += PictureBox1_DragEnter;
            this.flowLayoutPanel3.DragDrop += PictureBox1_DragDrop;

            this.myCategoryTableAdapter1.Fill(this.photoDataSet11.MyCategory);
            this.myPhotoTableAdapter1.Fill(this.photoDataSet11.MyPhoto);
            this.bindingSource1.DataSource = this.photoDataSet11.MyPhoto;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.myPhotoDataGridView.DataSource = this.bindingSource1;

            DataTable dt = photoDataSet11.MyCategory;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LinkLabel x = new LinkLabel();

                x.Text = dt.Rows[i]["CategoryName"].ToString();
                x.Left = 5;
                x.Top = 25 * i + 5;
                x.Tag = dt.Rows[i]["Categoryid"];  //ID

                x.Click += X_Click;
                flowLayoutPanel2.Controls.Add(x);
            }




        }



        private void X_Click(object sender, EventArgs e)
        {
            this.myPhotoTableAdapter1.Fill(this.photoDataSet11.MyPhoto);
            DataTable dp = photoDataSet11.MyPhoto;
            PictureBox pictureBox = new PictureBox();

            dataGridView1.DataSource = dp;

            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select * from  Myphoto", conn);

                    SqlDataReader dataReader = command.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dataReader);

                    //while (dataReader.Read())

                    this.dataGridView1.DataSource = dt;



                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            for (int i = 0; i < dp.Rows.Count; i++)
            {
                if (dp.Rows != null)
                {

                    pictureBox.Image=(Image)dp.Rows[i]["picture"];
                    this.flowLayoutPanel3.Controls.Add(pictureBox);
                    pictureBox.Size = new Size(300, 300);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                else
                {

                    pictureBox.Image = null;
                }

                try
                {
                    using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = $"select Picture from MyPhoto where categoryid={((LinkLabel)sender).Tag}";
                        command.Connection = conn;

                        conn.Open();
                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            //=======================
                            dataReader.Read();

                            byte[] bytes = (byte[])dataReader["Picture"];
                            System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                            pictureBox.Image = Image.FromStream(ms);

                            //=======================
                        }
                        else
                        {
                            MessageBox.Show("No Record");
                        }
                    } // Auto conn.Close()
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                    pictureBox.Image = pictureBox.ErrorImage;
                }





            }



        }




        private void LoadCategoriesToComboBox()
        {
            string a = this.comboBox1.Text;
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select CategoryName from  MyCategory", conn);

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

        private void LoadCategoriesToComboBox2()
        {
            string b = this.comboBox2.Text;
            //Select 
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand($"select CategoryName from  MyCategory", conn);

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

        //List<string> fileNames = new List<string>();
        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "(*.jpg)|*.jpg|(*.bmp)|*.bmp|Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //this.pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);

            }




        }

        private void Pic_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void myCategoryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.myCategoryBindingSource.EndEdit();

        }



        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

        }
        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);



            for (int i = 0; i < files.Length; i++)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Image.FromFile(files[i]);
                this.flowLayoutPanel3.Controls.Add(pictureBox);
                pictureBox.Size = new Size(300, 300);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;


                try
                {

                    using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                    {
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "Insert into MyPhoto(picture,categoryid) values ( @picture,@categoryid)";
                        command.Connection = conn;
                        //=============================
                        byte[] bytes = null;//= { 1, 3 };

                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        bytes = ms.GetBuffer();

                        //=============================

                        command.Parameters.Add("@Picture", SqlDbType.Image).Value = bytes;
                        command.Parameters.AddWithValue("@categoryid", this.comboBox1.SelectedIndex + 1);

                        conn.Open();
                        command.ExecuteNonQuery();

                        //MessageBox.Show("Insert Image successfully");


                    } // Auto conn.Close()
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //try
                //{
                //    using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                //    {
                //        conn.Open();
                //        SqlCommand command = new SqlCommand($"select * from  Myphoto", conn);

                //        SqlDataReader dataReader = command.ExecuteReader();
                //        DataTable dt = new DataTable();
                //        dt.Load(dataReader);

                //        //while (dataReader.Read())

                //            this.dataGridView1.DataSource = dt;



                //    } // Auto conn.Close()
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}



            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //強制回應 DialogBox - ShowDialog()
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                MessageBox.Show("OK " + this.openFileDialog1.FileName);

                this.pictureBox2.Image = Image.FromFile(this.openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Cancel");
            }





        }

        private void FrmMyAlbum_V1_Load(object sender, EventArgs e)
        {
            this.myCategoryTableAdapter1.Fill(this.photoDataSet11.MyCategory);


        }



        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {

        }
    }
}

       


