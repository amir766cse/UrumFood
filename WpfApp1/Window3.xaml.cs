using System;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        string entr;
        SqlConnection con = new SqlConnection();
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if ((txt_uname.Text == "") || (psw_pass.Password == ""))
                MessageBox.Show("اطلاعات خواسته شده کامل نیست");
            else
            {
                con.ConnectionString = "server=localhost ; database = UrumFood ; integrated security = true";
                SqlCommand log_in = new SqlCommand();
                log_in.Connection = con;
                log_in.CommandText = "execute log_in @uname , @pass , @enter";
                SqlParameter enter = new SqlParameter();
                enter.ParameterName = "@rtrn";
                enter.Direction = ParameterDirection.ReturnValue;
                log_in.Parameters.Add(enter);
                log_in.Parameters.AddWithValue("@uname", txt_uname.Text);
                log_in.Parameters.AddWithValue("@pass", psw_pass.Password);
                con.Open();
                log_in.ExecuteNonQuery();
                con.Close();
                entr = log_in.Parameters["@enter"].Value.ToString();
                MessageBox.Show(entr);
                if (entr=="true")
                {
                    Window1 w1 = new Window1(txt_uname.Text,psw_pass.Password);
                    w1.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("نام کاربری یا رمز عبور اشتباه است");
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
