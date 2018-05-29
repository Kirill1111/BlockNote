using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Mes.Classes;
using Mes.Classes.Brush;
using Color = System.Windows.Media.Color;

namespace Mes.WindowList
{
    public partial class GlobalOptions : Window
    {

        public static int ComboBox1 = 1;
        public byte[] Buf;


        public GlobalOptions()
        {
            InitializeComponent();

            grid.DataContext = new Mes.Classes.Brush.BackBrush()._MyBrush;

            Combo1.SelectedIndex = ComboBox1;
            Logs.Log("Stop loading Log GlobalOptions", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public GlobalOptions(double Top, double Left, double Height, double Width, WindowState State)
        {
            Logs.Log("Start loading Log GlobalOptions", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);
            InitializeComponent();

            this.Top = Top;

            this.Left = Left;

            this.Height = Height;

            this.Width = Width;

            WindowState = State;

            if (WindowState == WindowState.Maximized)
            {
                this.Height = SystemParameters.PrimaryScreenHeight;
                this.Width = SystemParameters.PrimaryScreenWidth;
            }
            else
            {
                this.Height = Height;
                this.Width = Width;
            }

            grid.DataContext = new Mes.Classes.Brush.BackBrush()._MyBrush;

            Combo1.SelectedIndex = ComboBox1;
            Logs.Log("Stop loading Log GlobalOptions", "Info" , System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                Height = SystemParameters.PrimaryScreenHeight;
                Width = SystemParameters.PrimaryScreenWidth;
            }
            else
            {
                Height = 600;
                Width = 800;
            }
        }

        private void But2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Чёрная тема
            ComboBox1 = 0;
           new Mes.Classes.Brush.MainBrush()._Brush = new SolidColorBrush(Color.FromRgb(48, 48, 48));

            new Mes.Classes.Brush.BackBrush()._MyBrush = new SolidColorBrush(Color.FromRgb(0xEF , 0xEF , 0xF2));
                
            try
            {
                File.Delete("SaveInfo/SaveD.save");
                File.WriteAllText("SaveInfo/SaveD.save", "0");
            }catch(IOException ex)
            {
                Logs.Log("Error Work In File Log GlobalOptions", "FatalErr",ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }

        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public static void UpdateState()
        {
            // Обновление состояния
            try
            {
                ComboBox1 = Convert.ToInt32(File.ReadAllText("SaveInfo/SaveD.save"));
            }catch(IOException ex)
            {
                Logs.Log("Error Work In File Log GlobalOptions", "FatalErr",ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
                MessageBox.Show("Ошибка чтения файла");
            }
            switch(ComboBox1)
            {
                case 1:
                    new MainBrush()._Brush = new SolidColorBrush(Color.FromRgb(0xEF, 0xEF, 0xF2));
                    new Mes.Classes.Brush.BackBrush()._MyBrush = new SolidColorBrush(Color.FromRgb(48, 48, 48)); 
                    break;
                case 0:
                    new MainBrush()._Brush  = new SolidColorBrush(Color.FromRgb(48, 48, 48));
                    new Mes.Classes.Brush.BackBrush()._MyBrush = new SolidColorBrush(Color.FromRgb(0xEF, 0xEF, 0xF2));
                    break;
            }

        }

        private void But3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Светлая тема
                ComboBox1 = 1;
            new MainBrush()._Brush = new SolidColorBrush(Color.FromRgb(0xEF, 0xEF, 0xF2));
            new Mes.Classes.Brush.BackBrush()._MyBrush = new SolidColorBrush(Color.FromRgb(48, 48, 48)); 
            try
            {
                File.Delete("SaveInfo/SaveD.save");
                File.WriteAllText("SaveInfo/SaveD.save", "1");
            }
            catch (IOException ex)
            {
                Logs.Log("Error Work In File Log GlobalOptions", "FatalErr",ex, System.Reflection.MethodBase.GetCurrentMethod().Name);
            }
        }



    }
}

