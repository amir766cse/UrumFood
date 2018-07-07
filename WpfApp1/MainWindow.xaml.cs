using System;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1

{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con1 = new SqlConnection();
        public MainWindow()
        {
            InitializeComponent();
            con1.ConnectionString = "server=localhost ; database = UrumFood ; integrated security = true";
        }
        
        private void btn_sbt_Click(object sender, RoutedEventArgs e)
        {
           
            if ((txt_fname.Text == "") || (txt_lname.Text == "") || (txt_rname.Text == "") || (txt_rnumb.Text == null) || (txt_raddr.Text == null) || (txt_tnumbb.Text == null) || (txt_passw.Text == null) || (txt_rpassw.Text == null))
            {
                MessageBox.Show("اطلاعات کامل وارد نشده است ");
                e.Handled = true;
            }
            else
            {
                try
                {
                    con1.Open();
                    SqlCommand AddRestuarant = new SqlCommand();
                    AddRestuarant.Connection = con1;
                    AddRestuarant.CommandText = "  Execute RestaurantEnrollment @R#, @Rname, @ROFname, @ROLname, @Raddress ,@Rnumber, @RPass";
                    AddRestuarant.Parameters.AddWithValue("@R#", txt_tnumbb.Text);
                    AddRestuarant.Parameters.AddWithValue("@Rname",txt_rname.Text);
                    AddRestuarant.Parameters.AddWithValue("@ROFname",txt_fname.Text);
                    AddRestuarant.Parameters.AddWithValue("@ROLname", txt_lname.Text);
                    AddRestuarant.Parameters.AddWithValue("@Rnumber", txt_rnumb.Text) ;
                    AddRestuarant.Parameters.AddWithValue("@Raddress", txt_raddr.Text);
                    AddRestuarant.Parameters.AddWithValue("@Rpass", txt_rpassw.Text);
                    AddRestuarant.ExecuteNonQuery();
                    Window1 w1 = new Window1(txt_tnumbb.Text,txt_rpassw.Text);
                    w1.Show();
                    MessageBox.Show("ثبت شد");
                    con1.Close();
                    this.Close();
                }
                catch 
                {
                    con1.Close();
                    MessageBox.Show("خطا در ورود اطلاعات");
                }
                /*  catch
                  {
                      MessageBox.Show("مشکلی در انطباق اطلاعات وجود دارد !!!امکان شماره تکراری");

                  }*/
            }
            
           
                
        }

        private void txt_passw_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int pw;
            if (int.TryParse(e.Text, out pw) == false)
                e.Handled=true;
        }

        private void btn_gb_Click(object sender, RoutedEventArgs e)
        {
            Window4 w4 = new Window4();
            w4.Show();
            this.Close();
        }

        private void Frame_Navigated(object sender, NavigationEventArgs e)
        {
        }
    }
}
