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
    /// Логика взаимодействия для ReName.xaml
    /// </summary>
    public partial class ReName : Window
    {
        //Информация о имени выбранного файла
        private string NameFile;

        public string Name
        {
            get => NameFile;
        }

        public ReName()
        {
            InitializeComponent();
        }

        //Запоминание выбранного имени
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Box.Text!=null)
         NameFile = Box.Text;
            Classes.Logs.Log("Save selected name", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
            this.Close();
        }

    }
}
