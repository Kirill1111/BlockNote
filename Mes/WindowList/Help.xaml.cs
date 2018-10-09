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

namespace Mes.WindowList
{
    /// <summary>
    /// Логика взаимодействия для Help.xaml
    /// </summary>
    public partial class Help : Window
    {
        private int pages = 1;
        private int maxpages = 3;

        public Help()
        {
            InitializeComponent();
            EditPages();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (pages <= 1) return;
            pages--;
            EditPages();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (pages >= maxpages) return;
            pages++;
            EditPages();
        }

        private void EditPages()
        {
                Image myImage3 = new Image();
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                bi3.UriSource = new Uri("../Resources/Image/Image"+pages+ ".png", UriKind.Relative);
                bi3.EndInit();
                myImage3.Stretch = Stretch.Fill;
                myImage3.Source = bi3;

                Img.Source = myImage3.Source;
            Classes.Logs.Log("Chandge pages", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

    }
}
