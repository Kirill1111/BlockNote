using System.Reflection;
using System.Windows;
using Mes.Classes;

namespace Mes.WindowList
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Window
    {

        public Info(double Top,double Left,double Height,double Width,WindowState State)
        {
            //Создание окна
            Logs.Log("Start loading Log Info", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);

            DataContext = Mes.Classes.Brush.BackBrush._MyBrush;

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

            Logs.Log("Stop loading Log Info", "Info", System.Reflection.MethodBase.GetCurrentMethod().Name);

            lb.Content += Assembly.GetExecutingAssembly().GetName().Version.ToString();

            }

            private void But_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
