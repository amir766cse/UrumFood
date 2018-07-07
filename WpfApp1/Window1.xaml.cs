using System;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<Class1> lstfood = new List<Class1>();
        string uname;
        string pass;
        public Window1(string user_name,string password)
        {
            uname = user_name;
            pass=password;
            InitializeComponent();
            lstfood.Add(new Class1() { ID = 1, foodname = "کباب" });
            lstfood.Add(new Class1() { ID = 1, foodname = "جوجه" });
            lstfood.Add(new Class1() { ID = 1, foodname = "سلطانی" });
            lstfood.Add(new Class1() { ID = 1, foodname = "بختیاری" });

            
        }
        

        
        private void btn_ud3_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item1 in lstfood)
            {
                ComboBoxItem cmb1 = new ComboBoxItem();
                cmb1.Content = item1.foodname;
                cmb_1.Items.Add(cmb1);
            }
        }

        private void btn_ud2_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item2 in lstfood)
            {
                ComboBoxItem cmb2 = new ComboBoxItem();
                cmb2.Content = item2.foodname;
                cmb_2.Items.Add(cmb2);
            }
        }

        private void btn_ud1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item3 in lstfood)
            {
                ComboBoxItem cmb3 = new ComboBoxItem();
                cmb3.Content = item3.foodname;
                cmb_3.Items.Add(cmb3);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.Show();
            this.Close();
        }

        private void addfood_Click(object sender, RoutedEventArgs e)
        {
            Window5 w5 = new Window5();
            w5.Show();
            
        }

        private void cmb_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cmb1 = new ComboBoxItem();
            string s = cmb_1.Items[cmb_1.SelectedIndex].ToString();
            MessageBox.Show(s);
            
        }
    }
}
