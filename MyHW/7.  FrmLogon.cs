using MyHW.Properties;
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
    public partial class FrmLogon : Form
    {
        public FrmLogon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert 
            try
            {
                string userName = this.UsernameTextBox.Text;
                string password = this.PasswordTextBox.Text;

                using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                {
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "Insert into MyTable(UserName, Password) values (@UserName,@Password)";
                    command.Connection = conn;

                    command.Parameters.Add("@UserName", SqlDbType.NVarChar, 16).Value = userName;
                    command.Parameters.Add("@Password", SqlDbType.NVarChar, 40).Value = password;

                    //SqlParameter p1 = new SqlParameter();
                    //p1.ParameterName = "@Password";
                    //p1.SqlDbType = SqlDbType.NVarChar;
                    //p1.Size = 40;
                    //p1.Value = password;
                    //p1.Direction = ParameterDirection.Input;

                   // command.Parameters.Add(p1);

                    conn.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show("Insert Member successfully");


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            //Select
            string userName = this.UsernameTextBox.Text;
            string password = this.PasswordTextBox.Text;
            try
            {
                using (SqlConnection conn = new SqlConnection(Settings.Default.MySettingConnectionString))
                {

                    SqlCommand command = new SqlCommand();
                    command.CommandText = $"select * from MyTable where UserName='{userName}' and Password='{password}'";
                    command.Connection = conn;

                    MessageBox.Show(command.CommandText);

                    conn.Open();
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("會員登入成功");
                        
                        FrmMain frmMain = new FrmMain();
                        frmMain.Show();

                    }
                    else
                    {
                        MessageBox.Show("會員登入失敗");
                    }


                } // Auto conn.Close()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
