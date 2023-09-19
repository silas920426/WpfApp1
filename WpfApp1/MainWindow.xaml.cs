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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int number;
            List<int> primes = new List<int>();
            bool success = int.TryParse(textbox1.Text, out number);
            if(!success) 
            {
                MessageBox.Show("請輸入整數","輸入錯誤");
            }
            else if(number < 2)
            {
                MessageBox.Show($"輸入數值為{number}，小於2，請重新輸入", "輸入錯誤");
            }
            else
            {
                for(int i = 2; i <= number; i ++)
                {
                    if(IsPrime(i)) primes.Add(i);
                }
            }

            //顯示所有質數與倍數
            ListResult(primes, number);
        }

        private void ListResult(List<int> myprimes, int mynumber)
        {
            string primeList = $"小於等於{mynumber}的質數為：";
            string primeMultiple = "";

            foreach(int p in myprimes) 
            {
                primeList += $"，{p}  ";
                primeMultiple += $"{p}的倍數為:  ";
                int i = 1;
                while(p*i <= mynumber) 
                {
                    primeMultiple += $"，{p * i}";
                    i++;
                }
                primeMultiple += "\n";
            
            }
            textblock1.Text = primeList;
            textblock2.Text = primeMultiple;  
        }

        private bool IsPrime(int p)
        {
            //  判斷p是否為質數
            for(int i = 2; i < p; i++)
            {
                if (p % i == 0) return false;
            }
            return true;
        }
    }
}
