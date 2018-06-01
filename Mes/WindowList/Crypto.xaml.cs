using System;
using System.Collections.Generic;
using System.IO;
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
using Mes.Unit;

namespace Mes.WindowList
{
    /// <summary>
    /// Логика взаимодействия для Crypto.xaml
    /// </summary>
    public partial class Crypto : Window
    {
        private string Key;
        private string Iv;
        private readonly string txt;
        private readonly Random rnd = new Random(DateTime.Now.Millisecond);

        public Crypto(string text)
        {
            InitializeComponent();
            txt = text;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Key = "";
            Key1.Text = "";

            for (var i = 0; i < 32; i++)
            {
                Key += Convert.ToChar(rnd.Next(33, 126));
            }

            Key1.Text = Key;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Iv  = "";
            IV1.Text = "";

            {
                for (var i = 0; i < 16; i++)
                {
                    Iv += Convert.ToChar(rnd.Next(33, 126));
                }

                IV1.Text = Convert.ToString(Iv);

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Key1.Text.Length == 32 && IV1.Text.Length == 16)
            {
                Key = Key1.Text;
                Iv = IV1.Text;
                Classes.Crypto.Write.WriteText(File.ReadAllText("SaveInfo/SaveText/" + txt + ".SAVE"),
                     "SaveInfo/SaveText/" + txt + ".SAVE", Key, Iv);
                Close();
            }
            else
            {
                MessageBox.Show("Неверный ключ или вектор инициализации.");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (Key1.Text.Length == 32 && IV1.Text.Length == 16)
            {
                Iv = IV1.Text;
                Key = Key1.Text;
                Classes.Crypto.Read.ReadText("SaveInfo/SaveText/" + txt + ".SAVE", Key, Iv);
                Close();
            }
            else
            {
                MessageBox.Show("Неверный ключ или вектор инициализации.");
            }
}
    }
}



